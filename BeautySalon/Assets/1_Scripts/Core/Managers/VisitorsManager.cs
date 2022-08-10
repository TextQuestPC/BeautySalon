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

        public override void OnStart()
        {
            Visitor visitor = BoxManager.GetManager<CreatorManager>().CreateVisitor();
            visitor.SetDataVisit(TypeService.Haircut, TypeItem.Scissors);
            visitors.Add(visitor);
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


        }
    }
}