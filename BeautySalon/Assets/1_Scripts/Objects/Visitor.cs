using ObjectsOnScene;
using SystemMove;
using VisitorSystem;

namespace Characters
{
    public class Visitor : ObjectScene, IInitialize
    {
        private TypeService typeNeedServices = TypeService.Haircut;
        private TypeItem typeNeedItem = TypeItem.Scissors;
        private StateVisitor stateVisitor = StateVisitor.StartInDoor;

        private MoveVisitorComponent moveComponent;

        public TypeService GetTypeService { get => typeNeedServices; }
        public TypeItem GetTypeItem { get => typeNeedItem; }
        public StateVisitor GetState { get => stateVisitor; }

        public override void OnInitialize()
        {
            moveComponent = new MoveVisitorComponent();
        }

        public void SetDataVisit(TypeService typeService, TypeItem typeItem)
        {
            typeNeedServices = typeService;
            typeNeedItem = typeItem;
        }
    }
}