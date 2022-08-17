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
            StateVisitor state = visitor.StateVisitor;

            if (state == StateVisitor.StartInDoor)
            {
                VisitorCameInSalon();
            }
            if (state == StateVisitor.StandByStartMove)
            {
                ChooseService();
            }
            else if (state == StateVisitor.StandByService)
            {
                visitor.SitDownOnChair();
            }
            else if (state == StateVisitor.CompleteProcedure)
            {
                visitor.StateVisitor = StateVisitor.StandByServiceAfterProcedure;
                visitor.StandUpFromChair();
            }
            else if (state == StateVisitor.StandByServiceAfterProcedure)
            {
                // TODO: check - have any procedure ???
                VisitorEndProcedure();
            }
            else if (state == StateVisitor.GoToCash)
            {
                currentVisitor.StateVisitor = StateVisitor.StandByCash;
                visitor.GoToTargetService(serviceManager.GetFreeService(TypeService.Cash));
            }
            else if (state == StateVisitor.StandByCash)
            {
                visitor.LookAt(serviceManager.GetFreeService(TypeService.Cash).GetLookPosition.transform);
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

                currentVisitor.StateVisitor = StateVisitor.StandByStartMove;
                currentVisitor.GoToTargetTransform(startMovePos.transform);
            }
            else // If service is not free
            {
                RestZone restZone = serviceManager.GetRestZone;

                currentVisitor.StateVisitor = StateVisitor.StandByRestZone;
                currentVisitor.GoToTargetTransform(restZone.transform);
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

            currentVisitor.StateVisitor = StateVisitor.GoToCash;
            currentVisitor.GoToTargetTransform(startMovePos.transform);
        }

        private void ChooseService()
        {
            Service service = serviceManager.GetFreeService(currentVisitor.GetTypeService);

            if (service != null)
            {
                currentVisitor.StateVisitor = StateVisitor.StandByService;

                currentVisitor.GoToTargetService(service);
                return;
            }
        }
    }
}