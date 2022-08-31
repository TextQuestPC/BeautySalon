using Characters;
using Core;

namespace ObjectsOnScene
{
    public class Money : Item
    {
        private int countMoney = 50;

        public int SetCountMoney { set => countMoney = value; }

        protected override void PlayerInCollider(Player player)
        {
            BoxManager.GetManager<ValuesManager>().AddMoney(countMoney);
            Death();
        }

        protected override void PlayerOutCollider(Player player)
        {
            
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }
}
