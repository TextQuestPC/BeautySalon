using Core;
using ObjectsOnScene;
using System.Collections.Generic;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Player : Character
    {
        [SerializeField] private GameObject positionItem;
        [SerializeField] private GameObject cameraPosition;

        private List<Item> items = new List<Item>();
        private int maxCountItems = 3;

        public MovePlayerComponent GetMove { get => moveComponent as MovePlayerComponent; }
        public GameObject GetCameraPosition { get => cameraPosition; }

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MovePlayerComponent>();
        }

        #region CHANGE_MOVE

        public void ChangeAngleMove(float angle)
        {
            moveComponent.ChangeRotate(angle);

            cameraPosition.transform.rotation = Quaternion.Euler(cameraPosition.transform.rotation.x, angle, cameraPosition.transform.rotation.z);
        }       

        #endregion

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

            Debug.Log($"Try delete item. Not have item, type = {typeItem}");
        }

        #endregion ITEMS
    }
}