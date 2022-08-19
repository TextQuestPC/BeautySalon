using UnityEngine;

namespace SystemMove
{
    public class MoveCameraComponent : MoveComponent
    {
        private Vector3 nextPos;
        private Transform targetTransform;

        private void Start()
        {
            speedMove = 30f;
        }

        protected override void Move()
        {
            nextPos = targetTransform.position;
            nextPos.y += 15f;
            nextPos.z -= 10f;
            nextPos.x -= 10f;

            transform.position = Vector3.Lerp(transform.position, nextPos, speedMove * Time.deltaTime);
        }

        public void SetNextTarget(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
            canMove = true;
        }
    }
}