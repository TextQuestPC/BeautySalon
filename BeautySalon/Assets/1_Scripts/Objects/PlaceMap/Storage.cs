using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Storage : InteractionObject
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        public TypeService GetTypeService { get => typeService; }

        protected override void PlayerInCollider(Player player)
        {
            BoxManager.GetManager<GameManager>().PlayerTryGetItem(typeItem);
        }

        protected override void PlayerOutCollider(Player player) { }
    }
}