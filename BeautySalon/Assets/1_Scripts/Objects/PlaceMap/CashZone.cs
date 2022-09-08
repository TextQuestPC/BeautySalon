using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    public class CashZone : InteractionObject
    {
        [SerializeField] private GameObject moneyPosition;

        private Visitor waitVisitor = null;
        public Visitor SetWaitVisitor
        {
            set
            {
                waitVisitor = value;

                if(player != null)
                {
                    CashVisitor();
                }
            }
        }

        protected override void PlayerInCollider(Player player)
        {
            if (waitVisitor != null) // Расчитываем посетителя
            {
                CashVisitor();
            }
        }

        protected override void PlayerOutCollider(Player player){}

        private void CashVisitor()
        {
            Money money = BoxManager.GetManager<CreatorManager>().CreateItem(TypeItem.Money) as Money;

            money.SetCountMoney = waitVisitor.GetMoneyForServices;
            money.transform.position = moneyPosition.transform.position;

            waitVisitor.CalculateVisitor();
            waitVisitor = null;
        }
    }
}