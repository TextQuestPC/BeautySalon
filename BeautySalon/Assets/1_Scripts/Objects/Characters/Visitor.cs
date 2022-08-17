using Core;
using ObjectsOnScene;
using System.Collections;
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

        public void GoToStartMove(Transform startMoveTransform)
        {
            stateVisitor = StateVisitor.StandByStartMove;

            MoveToNewPosition(startMoveTransform);
        }

        public void GoToService(Service service)
        {
            currentService = service;
            stateVisitor = StateVisitor.StandByService;

            MoveToNewPosition(service.GetVisitorPosition.transform);
        }

        public void GoToRestZone(RestZone restZone)
        {
            stateVisitor = StateVisitor.GoToRestZone;

            MoveToNewPosition(restZone.transform);
        }

        public void GoToCash(Service service)
        {
            currentService = service;
            stateVisitor = StateVisitor.StandByCash;

            MoveToNewPosition(service.GetVisitorPosition.transform);
        }

        public void GoToEndProcedure(Transform transform)
        {
            stateVisitor = StateVisitor.GoToCash;

            MoveToNewPosition(transform);
        }

        public void SetDown()
        {
            currentService.VisitorIsCame(this);
            animator.SetTrigger("SitLeft");

            (moveComponent as MoveVisitorComponent).LookAt(currentService.transform);
            transform.position = currentService.GetVisitorPosition.transform.position;
        }

        public void CompleteProcedure()
        {
            stateVisitor = StateVisitor.CompleteProcedure;

            StartCoroutine(CoGetUpFromChair());
        }

        private IEnumerator CoGetUpFromChair()
        {
            animator.SetTrigger("Idle");

            yield return new WaitForSeconds(1f);

            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        private void MoveToNewPosition(Transform targetTransform)
        {
            animator.SetTrigger("Move");

            (moveComponent as MoveVisitorComponent).AfterEndMove += AfterMove;
            (moveComponent as MoveVisitorComponent).LookAt(targetTransform);
            (moveComponent as MoveVisitorComponent).SetNewTargetMove(targetTransform);

            ChangeMove(true);
        }

        private void AfterMove()
        {
            ChangeMove(false);

            (moveComponent as MoveVisitorComponent).AfterEndMove -= AfterMove;
            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        #endregion ACTIONS
    }
}