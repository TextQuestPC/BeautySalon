using Core;
using ObjectsOnScene;
using System.Collections;
using SystemMove;
using UI;
using UnityEngine;
using VisitorSystem;

namespace Characters
{
    public class Visitor : Character
    {
        private WishCanvas wishCanvas;

        private DataVisit[] dataVisit;
        private int counterDataVisit = 0;
        private StateVisitor stateVisitor = StateVisitor.StartInDoor;

        public DataVisit[] SetDataVisit { set => dataVisit = value; }
        public TypeItem GetCurrentTypeItem { get => dataVisit[counterDataVisit].GetTypeItem; }
        public TypeService GetCurrentTypeService { get => dataVisit[counterDataVisit].GetTypeService; }
        public StateVisitor StateVisitor { get => stateVisitor; set => stateVisitor = value; }
       
        private Service currentService;
        private int moneyForServices = 50; // TODO: расчитывать от стоимости полученных услуг

        public int GetMoneyForServices { get => moneyForServices; }

        #region INIT

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MoveVisitorComponent>();
            wishCanvas = GetComponentInChildren<WishCanvas>();
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

        public void CompleteCurrentProcedure()
        {
            wishCanvas.HideWish();
            counterDataVisit++;

            if(counterDataVisit < dataVisit.Length)
            {
                stateVisitor = StateVisitor.WaitProcedure;
            }
            else
            {
                stateVisitor = StateVisitor.CompleteAllProcedure;
            }

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
            currentService.VisitorIsCame(this);
            ShowAnimation(TypeAnimationCharacter.SitLeft);

            (moveComponent as MoveVisitorComponent).LookAt(currentService.GetLookPosition.transform);
            transform.position = currentService.GetVisitorPosition.transform.position;

            wishCanvas.ShowWish(BoxManager.GetManager<DataManager>().GetDataItemUI(GetCurrentTypeItem).SpriteItem);
        }

        public void CompleteAllProcedure()
        {
            BoxManager.GetManager<VisitorsManager>().ChooseNextActionVisitor(this);
        }

        public void StandAroundCash()
        {
            wishCanvas.ShowWish(BoxManager.GetManager<DataManager>().GetDataItemUI(TypeItem.Money).SpriteItem);
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