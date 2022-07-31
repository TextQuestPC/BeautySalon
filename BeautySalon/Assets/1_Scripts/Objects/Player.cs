using Core;
using ObjectsOnScene;
using System.Collections.Generic;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Player : ObjectScene
    {
        [SerializeField] private GameObject positionItem;

        private MovePlayerComponent moveComponent;

        private List<Item> items = new List<Item>();
        private int maxCountItems = 3;

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MovePlayerComponent>();
        }

        public void StopSwipe()
        {
        }

        public bool CheckCanGetItem()
        {
            return items.Count < maxCountItems;
        }

        public void GetItemFromPlace(TypeItem typeItem)
        {
            Item item = BoxManager.GetManager<CreatorManager>().CreateItem(typeItem);
            item.transform.position = positionItem.transform.position;
            item.transform.SetParent(positionItem.transform);

            items.Add(item);
        }
    }
}