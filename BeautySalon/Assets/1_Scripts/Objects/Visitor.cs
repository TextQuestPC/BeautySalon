using Core;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;
using VisitorSystem;

namespace Characters
{
    public class Visitor : ObjectScene, IInitialize
    {
        private TypeService typeNeedServices = TypeService.Haircut;
        private TypeItem typeNeedItem = TypeItem.Scissors;
        private StateVisitor stateVisitor = StateVisitor.StartInDoor;

        private MoveVisitorComponent moveComponent;

        public TypeService GetTypeService { get => typeNeedServices; }
        public TypeItem GetTypeItem { get => typeNeedItem; }
        public StateVisitor GetState { get => stateVisitor; }

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MoveVisitorComponent>();
            Debug.Log("init " + moveComponent);

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

            MoveToNewPosition(service.transform.position);
        }

        public void GoToRestZone(RestZone restZone)
        {
            stateVisitor = StateVisitor.GoToRestZone;

            MoveToNewPosition(restZone.transform.position);
        }

        private void MoveToNewPosition(Vector3 position)
        {
            Debug.Log("MoveToNewPosition  " + moveComponent);
            moveComponent.EndMove.AddListener(AfterMove);
            moveComponent.SetNewPos(position);
        }

        private void AfterMove()
        {
            moveComponent.EndMove.RemoveListener(AfterMove);

            BoxManager.GetManager<VisitorsManager>().VisitorEndMove(this);
        }

        #endregion
    }
}