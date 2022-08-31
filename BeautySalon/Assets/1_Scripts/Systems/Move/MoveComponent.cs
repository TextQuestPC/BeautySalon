using UnityEngine;

namespace SystemMove
{
    public class MoveComponent : MonoBehaviour
    {
        protected bool moveNow;
        protected float speedMove = 5f;

        public bool SetMoveNow { set => moveNow = value; }

        private void Update()
        {
            if (moveNow)
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