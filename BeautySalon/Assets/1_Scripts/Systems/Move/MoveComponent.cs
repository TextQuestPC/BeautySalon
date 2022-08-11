using UnityEngine;

namespace SystemMove
{
    public class MoveComponent : MonoBehaviour
    {
        protected bool canMove;
        protected float speedMove = 10f;

        private void Update()
        {
            if (canMove)
            {
                Move();
            }
        }

        protected virtual void Move() { }
    }
}