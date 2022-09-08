using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using ObjectsOnScene;

namespace Core
{
    [CreateAssetMenu(fileName = "DataManager", menuName = "Managers/DataManager")]
    public class DataManager : BaseManager
    {
        [SerializeField] private DataItemUI[] dataItemsUI;

        public DataItemUI GetDataItemUI(TypeItem typeItem)
        {
            foreach (var dataItem in dataItemsUI)
            {
                if(dataItem.TypeItem == typeItem)
                {
                    return dataItem;
                }
            }

            Debug.Log($"<color=red>Not have DataItemUI - {typeItem}</color>");
            return null;
        }
    }
}