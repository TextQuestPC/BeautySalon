using ObjectsOnScene;
using SystemMove;

namespace Characters
{
    public class Visitor : ObjectScene, IInitialize
    {
        private TypeService typeNeedServices = TypeService.Haircut;
        private TypeItem typeNeedItem = TypeItem.Scissors;

        private MoveVisitorComponent moveComponent;

        public override void OnInitialize()
        {
            moveComponent = new MoveVisitorComponent();
        }


    }
}