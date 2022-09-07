using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    public class CashZone : InteractionObject
    {
        [SerializeField] private GameObject moneyPosition;

        private Visitor waitVisitor = null;
        public Visitor SetWaitVisitor { set => waitVisitor = value; }

        protected override void PlayerInCollider(Player player)
        {
            не сработало, когда player уже был здесь, а visitor еще нет
            if (waitVisitor != null) // Расчитываем посетителя
            {
                Money money = BoxManager.GetManager<CreatorManager>().CreateItem(TypeItem.Money) as Money;

                money.SetCountMoney = waitVisitor.GetMoneyForServices;
                money.transform.position = moneyPosition.transform.position;

                waitVisitor.CalculateVisitor();
                waitVisitor = null;
            }
    }

        protected override void PlayerOutCollider(Player player)
        {
        }
    }
}