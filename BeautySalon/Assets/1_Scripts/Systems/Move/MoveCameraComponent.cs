using UnityEngine;

namespace SystemMove
{
    public class MoveCameraComponent : MonoBehaviour
    {
        private bool moveNow;

        private float speedMove = 10f;
        private Vector3 nextPos;
        private Transform targetTransform;

        private void Update()
        {
            if (moveNow)
            {
                nextPos = targetTransform.position;
                nextPos.y += 6.5f;
                nextPos.z -= 5f;
                nextPos.x -= 5f;

                transform.position = Vector3.MoveTowards(transform.position, nextPos, speedMove * Time.deltaTime);
            }
        }

        public void SetNextTarget(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
            moveNow = true;
        }
    }
}