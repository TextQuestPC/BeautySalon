using ObjectsOnScene;
using SystemMove;
using UnityEngine;

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