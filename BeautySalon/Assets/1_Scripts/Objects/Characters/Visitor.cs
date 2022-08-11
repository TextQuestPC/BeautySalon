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

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MoveVisitorComponent>();
        }

        public void SetDataVisit(TypeService typeService, TypeItem typeItem)
        {
            typeNeedServices = typeService;
            typeNeedItem = typeItem;
        }

        #region CHANGE_STATE

        public void GoToService(Service service)
        {
            stateVisitor = StateVisitor.GoToService;

            MoveToNewPosition(service.transform);
        }

        public void GoToRestZone(RestZone restZone)
        {
            stateVisitor = StateVisitor.GoToRestZone;

            MoveToNewPosition(restZone.transform);
        }

        private void MoveToNewPosition(Transform visitorTransform)
        {
            (moveComponent as MoveVisitorComponent).AfterEndMove += AfterMove;
            (moveComponent as MoveVisitorComponent).SetNewTargetMove(visitorTransform);

            ChangeMove(true);
        }

        private void AfterMove()
        {
            ChangeMove(false);

            (moveComponent as MoveVisitorComponent).AfterEndMove -= AfterMove;
            BoxManager.GetManager<VisitorsManager>().VisitorEndMove(this);
        }

        #endregion
    }
}