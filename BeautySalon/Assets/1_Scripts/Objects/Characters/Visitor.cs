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
        private TypeItem typeNeedItem = TypeItem.HaircutConsumable;
        private StateVisitor stateVisitor = StateVisitor.StartInDoor;

        public TypeService GetTypeService { get => typeNeedServices; }
        public TypeItem GetTypeItem { get => typeNeedItem; }
        public StateVisitor StateVisitor { get => stateVisitor; set => stateVisitor = value; }

        private Service currentService;
        private int moneyForServices = 50; // TODO: расчитывать от стоимости полученных услуг

        public int GetMoneyForServices { get => moneyForServices; }

        #region INIT

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MoveVisitorComponent>();
        }

        public void SetDataVisit(TypeService typeService, TypeItem typeItem)
        {
            typeNeedServices = typeService;
            typeNeedItem = typeItem;
        }

        #endregion INIT

        #region ACTIONS

        public void GoToTargetTransform(Transform targetTransform)
        {
            MoveToNewPosition(targetTransform);
        }
        public void GoToTargetService(Service targetService)
        {
            currentService = targetService;

            MoveToNewPosition(targetService.GetVisitorPosition.transform);
        }

        public void StandUpFromChair()
        {
            StartCoroutine(CoStandUpFromChair());
        }

        private IEnumerator CoStandUpFromChair()
        {
            ShowAnimation(TypeAnimationCharacter.StandLeft);

            yield return new WaitForSeconds(1f);

            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        public void SitDownOnChair()
        {
            Debug.Log("sit down"); у ебучего блять сука амиматора не включается анимация.
                Сука блять включается дважды move анимация
            currentService.VisitorIsCame(this);
            ShowAnimation(TypeAnimationCharacter.SitLeft);

            (moveComponent as MoveVisitorComponent).LookAt(currentService.GetLookPosition.transform);
            transform.position = currentService.GetVisitorPosition.transform.position;
        }

        public void CompleteProcedure()
        {
            stateVisitor = StateVisitor.CompleteProcedure;

            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        public void CalculateVisitor()
        {
            stateVisitor = StateVisitor.GetMoney;

            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        public void LookAt(Transform targetTransform)
        {
            (moveComponent as MoveVisitorComponent).LookAt(targetTransform);
        }

        private void MoveToNewPosition(Transform targetTransform)
        {
            (moveComponent as MoveVisitorComponent).AfterEndMove += AfterMoveToTarget;
            (moveComponent as MoveVisitorComponent).LookAt(targetTransform);
            (moveComponent as MoveVisitorComponent).SetNewTargetMove(targetTransform);

            ChangeMove(true);
        }

        private void AfterMoveToTarget()
        {
            ChangeMove(false);

            (moveComponent as MoveVisitorComponent).AfterEndMove -= AfterMoveToTarget;
            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        #endregion ACTIONS
    }
}