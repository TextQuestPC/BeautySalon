using Characters;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class TouchSystem : Singleton<TouchSystem>, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Player player;

        public Player SetPlayer { set => player = value; }

        private bool down;

        public void OnPointerDown(PointerEventData eventData)
        {
            down = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            ChangeAngleRotation(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            down = false;
        }

        private void ChangeAngleRotation(Vector3 positionTouch)
        {
            float x = positionTouch.x - Screen.width / 2;
            float y = positionTouch.y - Screen.height / 3;

            float angle = Mathf.Atan2(x, y);
            float finalAngle = 360 * angle / (2 * Mathf.PI);

            player.ChangeAngleMove(finalAngle);
        }

#if UNITY_EDITOR
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                down = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                down = false;
            }

            if (down)
            {
                ChangeAngleRotation(Input.mousePosition);
            }
        }
#endif

    }
}