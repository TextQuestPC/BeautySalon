using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ServicesManager", menuName = "Managers/ServicesManager")]
    public class ServicesManager : BaseManager
    {
        private List<Service> services = new List<Service>();
        private RestZone restZone;
        private CashService cashService;

        public RestZone GetRestZone { get => restZone; }
        public CashService GetCashService { get => cashService; }

        public override void OnInitialize()
        {
            services.Add(BoxManager.GetManager<CreatorManager>().CreateService(TypeService.Haircut));
            restZone = BoxManager.GetManager<CreatorManager>().CreateRestZone();
            //cashService = BoxManager.GetManager<CreatorManager>().CreateRestZone();
        }

        public bool CheckFreeService(TypeService typeService)
        {
            foreach (var service in services)
            {
                if(service.GetTypeService == typeService)
                {
                    if (service.GetIsFree)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Service GetFreeService(TypeService typeService)
        {
            foreach(var service in services)
            {
                if (service.GetTypeService == typeService)
                {
                    if (service.GetIsFree)
                    {
                        return service;
                    }
                }
            }

            Debug.Log($"<color=red>Not service! But CheckFreeService say TRUE!</color>");
            return null;
        }
    }
}