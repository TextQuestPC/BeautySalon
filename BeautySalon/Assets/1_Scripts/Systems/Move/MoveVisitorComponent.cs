using UnityEngine;
using UnityEngine.Events;

namespace SystemMove
{
    public class MoveVisitorComponent : MoveComponent
    {
        [HideInInspector]
        public UnityEvent EndMove;

        private Vector3 nextPos;

        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speedMove * Time.deltaTime);

            if(transform.position == nextPos)
            {
                canMove = false;

                EndMove?.Invoke();
            }
        }

        public void SetNewPos(Vector3 newPos)
        {
            newPos.y = transform.position.y;
            nextPos = newPos;

            canMove = true;
        }
    }
}
