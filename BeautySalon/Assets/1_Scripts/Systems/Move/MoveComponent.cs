using UnityEngine;

namespace SystemMove
{
    public class MoveComponent : MonoBehaviour
    {
        protected bool canMove;
        protected float speedMove = 5f;

        public bool SetCanMove { set => canMove = value; }

        private void Update()
        {
            if (canMove)
            {
                Move();
            }
        }

        public void ChangeRotate(float value)
        {
            transform.rotation = Quaternion.Euler(0, value, 0);
        }

        protected virtual void Move() { }
    }
}