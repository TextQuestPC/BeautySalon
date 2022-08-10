using System.Collections.Generic;
using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StorageManager", menuName = "Managers/StorageManager")]
    public class StorageManager : BaseManager
    {
        private List<Storage> storages = new List<Storage>();

        public override void OnInitialize()
        {
            storages.Add(BoxManager.GetManager<CreatorManager>().CreateStorage());
        }
    }
}