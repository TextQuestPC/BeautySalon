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
        [SerializeField] private GameObject model;

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

        #region CHECK

        public bool CheckHaveItem(TypeItem typeItem)
        {
            foreach (var item in items)
            {
                if(item.GetTypeItem == typeItem)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckCanGetItem()
        {
            return items.Count < maxCountItems;
        }

        #endregion CHECK

        #region ITEMS

        public void GetItemFromPlace(TypeItem typeItem)
        {
            Item item = BoxManager.GetManager<CreatorManager>().CreateItem(typeItem);
            item.transform.position = positionItem.transform.position;
            item.transform.SetParent(positionItem.transform);

            items.Add(item);
        }

        public void RemoveItem(TypeItem typeItem)
        {
            foreach (var item in items)
            {
                if(item.GetTypeItem == typeItem)
                {
                    items.Remove(item);
                    Destroy(item.gameObject);
                    return;
                }
            }

            Debug.Log($"Нужно удалить Item, которого нет у Player. Тип {typeItem}");
        }

        #endregion ITEMS
    }
}