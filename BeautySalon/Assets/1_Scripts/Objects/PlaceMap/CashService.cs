using Characters;
using UnityEngine;

namespace ObjectsOnScene
{
    public class CashService : Service
    {
        [SerializeField] private GameObject moneyPosition;

        private Visitor waitVisitor;

        protected override void StartProcedure()
        {
            if(myVisitor != null)
            {

            }
        }
    }
}