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
                //if(myVisitor != null)
                //{
            Debug.Log("GET MONEY");
            Item money = BoxManager.GetManager<CreatorManager>().CreateItem(TypeItem.Money);
            money.transform.position = moneyPosition.transform.position;
            //}
        }

        protected override void PlayerOutCollider(Player player)
        {
        }
    }
}