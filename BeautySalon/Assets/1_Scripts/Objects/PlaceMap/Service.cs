using Characters;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Service : InteractionObject
    {
        [SerializeField] private TypeService typeService;

        protected bool isFree = true;
        protected Visitor myVisitor;
        private Player player;

        public bool GetIsFree { get => isFree; }
        public TypeService GetTypeService { get => typeService; }
        public TypeItem GetTypeNeedItem { get => myVisitor.GetCurrentTypeItem; }

        public void VisitorIsCame(Visitor visitor)
        {
            isFree = false;
            myVisitor = visitor;

            if(player != null)
            {
                CheckStartProcedure();
            }
        }

        #region TRIGGER

        protected override void PlayerInCollider(Player player)
        {
            this.player = player;

            if (!isFree)
            {
                if (myVisitor != null)
                {
                    CheckStartProcedure();   
                }
                else
                {
                    Debug.Log($"<color=red>Not visitor! But service is not free!</color>");
                }
            }
        }

        private void CheckStartProcedure()
        {
            if (player.CheckHaveItem(GetTypeNeedItem))
            {
                StartProcedure();

                player.StartProcedure();
            }
        }

        protected abstract void StartProcedure();

        protected override void PlayerOutCollider(Player player)
        {
            player = null;
        }

        #endregion TRIGGER
    }
}