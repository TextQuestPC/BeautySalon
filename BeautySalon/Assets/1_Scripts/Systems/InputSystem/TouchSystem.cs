using Characters;
using UnityEngine;

namespace InputSystem
{
    public class TouchSystem : Singleton<TouchSystem>
    {
        private Player player;

        public Player SetPlayer { set => player = value; }

        private bool move = false;
        private bool mouseDown = false;

        public bool GetMouseDown { get => mouseDown; }

        private void ChangeMovePlayer(bool move)
        {
            this.move = move;
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
                mouseDown = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                ChangeMovePlayer(false);
                mouseDown = false;
            }

            if (move)
            {
                ChangeAngleRotation(Input.mousePosition);
            }
        }
    }
}