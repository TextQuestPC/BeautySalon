using UnityEngine;

namespace SystemMove
{
    public class MovePlayerComponent : MoveComponent
    {
        public bool SetCanMove { set => canMove = value; }

        private void Start()
        {
            speedMove = 5f;
        }

        public void ChangeRotate(float value)
        {
            transform.rotation = Quaternion.Euler(0,value,0);
        }

        protected override void Move()
        {
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
        }
    }
}
