using ObjectsOnScene;
using SystemMove;

namespace Characters
{
    public class Player : ObjectScene
    {
        private MovePlayerComponent moveComponent;

        public override void OnInitialize()
        {
            moveComponent = gameObject.AddComponent<MovePlayerComponent>();
        }

        public void StopSwipe()
        {
        }
    }
}