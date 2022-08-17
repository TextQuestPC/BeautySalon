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

        private Visitor currentVisitor;

        public override void OnStart()
        {
            serviceManager = BoxManager.GetManager<ServicesManager>();

            CreateVisitor();
        }

        public void ChooseNextActionVisitor(Visitor visitor)
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
            currentVisitor = visitor;
            StateVisitor state = visitor.GetState;

            if (state == StateVisitor.StartInDoor)
            {
                VisitorCameInSalon();
            }
            if (state == StateVisitor.StandByStartMove)
            {
                SetService();
            }
            else if (state == StateVisitor.StandByService)
            {
                visitor.SetDown();
            }
            else if (state == StateVisitor.CompleteProcedure)
            {
                // TODO: check - have any procedure ???
                VisitorEndProcedure();
            }
            else if (state == StateVisitor.GoToCash)
            {
                visitor.GoToCash(serviceManager.GetFreeService(TypeService.Cash));
            }
        }

        private void VisitorCameInSalon()
        {
            TypeService typeService = currentVisitor.GetTypeService;

            if (serviceManager.CheckFreeService(currentVisitor.GetTypeService))
            {
                float zValueService = serviceManager.GetFreeService(currentVisitor.GetTypeService).transform.position.z;
                GameObject startMovePos;

                if (zValueService > currentVisitor.transform.position.z)
                {
                    startMovePos = PositionsOnScene.Instance.GetLeftStartMovePos;
                }
                else
                {
                    startMovePos = PositionsOnScene.Instance.GetRightStartMovePos;
                }

                currentVisitor.GoToStartMove(startMovePos.transform);
            }
            else // If service is not free
            {
                RestZone restZone = serviceManager.GetRestZone;

                currentVisitor.GoToRestZone(restZone);
            }
        }

        private void VisitorEndProcedure()
        {
            GameObject startMovePos;

            if (currentVisitor.transform.position.z > 0)
            {
                startMovePos = PositionsOnScene.Instance.GetLeftStartMovePos;
            }
            else
            {
                startMovePos = PositionsOnScene.Instance.GetRightStartMovePos;
            }

            currentVisitor.GoToEndProcedure(startMovePos.transform);
        }

        private void SetService()
        {
            Service service = serviceManager.GetFreeService(currentVisitor.GetTypeService);

            if (service != null)
            {
                currentVisitor.GoToService(service);
                return;
            }
        }
    }
}