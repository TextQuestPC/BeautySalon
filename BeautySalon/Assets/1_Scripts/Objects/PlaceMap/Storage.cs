using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Storage : PlaceMap
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        protected override void PlayerInCollider(Player player)
        {
            BoxManager.GetManager<GameManager>().PlayerTryGetItem(typeItem);
        }

        protected override void PlayerOutCollider(Player player) { }
    }
}