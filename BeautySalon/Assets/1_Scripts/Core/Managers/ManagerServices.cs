using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ManagerServices", menuName = "Managers/ManagerServices")]
    public class ManagerServices : BaseManager
    {
        private List<Service> placesSpawn = new List<Service>();

        public override void OnInitialize()
        {
            placesSpawn.Add(BoxManager.GetManager<CreatorManager>().CreateService(TypeService.Haircut));
        }
    }
}