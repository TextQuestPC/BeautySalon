using UnityEngine;

namespace SystemMove
{
    public class MovePlayerComponent : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5f;

        private bool canMove = false;

        public bool SetCanMove { set => canMove = value; }

        private float angle;

        public void ChangeRotate(float value)
        {
            transform.rotation = Quaternion.Euler(0,value,0);
            angle = value;
        }

        private void Update()
        {
            if (canMove)
            {
                transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            }
        }
    }
}
