using UnityEngine;

namespace SystemMove
{
    public class MovePlayerComponent : MoveComponent
    {
        private void Start()
        {
            speedMove = 5f;
        }

        protected override void Move()
        {
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
        }
    }
}
