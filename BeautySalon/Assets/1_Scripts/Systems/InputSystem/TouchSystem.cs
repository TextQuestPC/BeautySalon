using Characters;
using UnityEngine;

namespace InputSystem
{
    public class TouchSystem : Singleton<TouchSystem>
    {
        [SerializeField] private Player player;

        public Player SetPlayer { set => player = value; }

        private bool canMove = false;

        private void ChangeMovePlayer(bool move)
        {
            canMove = move;
            player.ChangeMove(move);
        }

        private void ChangeAngleRotation(Vector3 positionTouch)
        {
            float x = positionTouch.x - Screen.width / 2;
            float y = positionTouch.y - Screen.height / 3.5f;

            float angle = Mathf.Atan2(x, y);
            float finalAngle = 360 * angle / (2 * Mathf.PI) + 45;

            player.ChangeAngleMove(finalAngle);
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeMovePlayer(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                ChangeMovePlayer(false);
            }

            if (canMove)
            {
                ChangeAngleRotation(Input.mousePosition);
            }
        }
    }
}