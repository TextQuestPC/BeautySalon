using System.Collections.Generic;
using Characters;
using ObjectsOnScene;
using UnityEngine;
using VisitorSystem;

namespace Core
{
    [CreateAssetMenu(fileName = "VisitorsManager", menuName = "Managers/VisitorsManager")]
    public class VisitorsManager : BaseManager
    {
        private List<Visitor> visitors = new List<Visitor>();

        private ServicesManager serviceManager;

        public override void OnStart()
        {
            serviceManager = BoxManager.GetManager<ServicesManager>();

            CreateVisitor();
        }

        public void VisitorEndMove(Visitor visitor)
        {
            ChooseActionForVisitor(visitor);
        }

        private void CreateVisitor()
        {
            Visitor visitor = BoxManager.GetManager<CreatorManager>().CreateVisitor();
            visitor.SetDataVisit(TypeService.Haircut, TypeItem.Scissors);
            visitors.Add(visitor);

            ChooseActionForVisitor(visitor);
        }

        private void ChooseActionForVisitor(Visitor visitor)
        {
            StateVisitor state = visitor.GetState;

            if(state == StateVisitor.StartInDoor)
            {
                SetGoToServiceForVisitor(visitor);
            }
        }

        private void SetGoToServiceForVisitor(Visitor visitor)
        {
            TypeService typeService = visitor.GetTypeService;

            if (serviceManager.CheckFreeService(visitor.GetTypeService))
            {
                Service service = serviceManager.GetFreeService(visitor.GetTypeService);

                if (service != null)
                {
                    visitor.GoToService(service);
                    return;
                }
            }

            // If service == null || service is not free
            RestZone restZone = serviceManager.GetRestZone;

            visitor.GoToRestZone(restZone);
        }
    }
}