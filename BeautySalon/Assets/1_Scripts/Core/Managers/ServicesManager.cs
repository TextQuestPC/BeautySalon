using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ServicesManager", menuName = "Managers/ServicesManager")]
    public class ServicesManager : BaseManager
    {
        private List<Service> services = new List<Service>();

        public override void OnInitialize()
        {
            services.Add(BoxManager.GetManager<CreatorManager>().CreateService(TypeService.Haircut));
        }

        public bool CheckFreeService(TypeService typeService)
        {
            return true;
            foreach (var service in services)
            {

            }
        }
    }
}