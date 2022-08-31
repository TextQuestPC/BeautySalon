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

        public bool GetIsFree { get => isFree; }
        public TypeService GetTypeService { get => typeService; }
        public TypeItem GetTypeNeedItem { get => myVisitor.GetTypeItem; }

        public void VisitorIsCame(Visitor visitor)
        {
            isFree = false;
            myVisitor = visitor;
        }

        #region TRIGGER

        protected override void PlayerInCollider(Player player)
        {
            if (!isFree)
            {
                if (myVisitor != null)
                {
                    if (player.CheckHaveItem(GetTypeNeedItem))
                    {
                        StartProcedure();

                        player.StartProcedure();
                    }
                }
                else
                {
                    Debug.Log($"<color=red>Not visitor! But service is not free!</color>");
                }
            }
        }

        protected abstract void StartProcedure();

        protected override void PlayerOutCollider(Player player) { }

        #endregion TRIGGER
    }
}