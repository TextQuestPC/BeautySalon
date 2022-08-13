using Core;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;
using VisitorSystem;

namespace Characters
{
    public class Visitor : Character
    {
        private TypeService typeNeedServices = TypeService.Haircut;
        private TypeItem typeNeedItem = TypeItem.Scissors;
        private StateVisitor stateVisitor = StateVisitor.StartInDoor;

        public TypeService GetTypeService { get => typeNeedServices; }
        public TypeItem GetTypeItem { get => typeNeedItem; }
        public StateVisitor GetState { get => stateVisitor; }

        private Service currentService;

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MoveVisitorComponent>();
        }

        public void SetDataVisit(TypeService typeService, TypeItem typeItem)
        {
            typeNeedServices = typeService;
            typeNeedItem = typeItem;
        }

        #region ACTIONS

        public void GoToService(Service service)
        {
            currentService = service;
            stateVisitor = StateVisitor.GoToService;

            MoveToNewPosition(service.GetSitPosition.transform);
        }

        public void GoToRestZone(RestZone restZone)
        {
            stateVisitor = StateVisitor.GoToRestZone;

            MoveToNewPosition(restZone.transform);
        }

        public void GoToCash(Transform cashTransform)
        {

        }

        public void SetDown()
        {
            currentService.VisitorIsCame(this);
            animator.SetTrigger("Sit");

            (moveComponent as MoveVisitorComponent).LookAt(currentService.transform);
            transform.position = currentService.GetSitPosition.transform.position;
        }

        public void CompleteProcedure()
        {
            stateVisitor = StateVisitor.EndProcedure;

            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        private void MoveToNewPosition(Transform targetTransform)
        {
            (moveComponent as MoveVisitorComponent).AfterEndMove += AfterMove;
            (moveComponent as MoveVisitorComponent).LookAt(targetTransform);
            (moveComponent as MoveVisitorComponent).SetNewTargetMove(targetTransform);

            ChangeMove(true);
        }

        private void AfterMove()
        {
            ChangeMove(false);
            ChangeState();

            (moveComponent as MoveVisitorComponent).AfterEndMove -= AfterMove;
            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        private void ChangeState()
        {
            if(stateVisitor == StateVisitor.GoToService)
            {
                stateVisitor = StateVisitor.StandByService;
            }
        }

        #endregion ACTIONS
    }
}