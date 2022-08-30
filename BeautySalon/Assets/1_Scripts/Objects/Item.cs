using Characters;
using UnityEngine;

namespace ObjectsOnScene
{
    public class Item : InteractionObject
    {
        [SerializeField] private TypeItem typeItem;

        public TypeItem GetTypeItem { get => typeItem; }

        protected override void PlayerInCollider(Player player)
        {
            Debug.Log("TAke money");
        }

        protected override void PlayerOutCollider(Player player)
        {
        }
    }
}