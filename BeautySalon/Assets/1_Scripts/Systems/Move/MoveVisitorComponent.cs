using UnityEngine;
using UnityEngine.Events;

namespace SystemMove
{
    public class MoveVisitorComponent : MoveComponent
    {
        [HideInInspector]
        public delegate void EndMove();
        public event EndMove AfterEndMove;

        private Vector3 nextPos;

        private void Start()
        {
            speedMove = 5f;
        }

        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speedMove * Time.deltaTime);

            if (transform.position == nextPos)
            {
                SetCanMove = false;

                AfterEndMove?.Invoke();
            }
        }

        public void SetNewTargetMove(Transform target)
        {
            nextPos = target.position;
            nextPos.y = transform.position.y;
        }

        public void LookAt(Transform target)
        {
            Vector3 targetVector = target.transform.position;

            transform.LookAt(targetVector);
        }
    }
}
