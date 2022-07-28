using Core;
using UnityEngine;

namespace InputSystem
{
    public class TouchSystem : MonoBehaviour
    {
        [SerializeField] private float speedModifier;

        private Touch touch;
        private Vector3 nextPos, prevPos;

        private InputManager inputManager;

        private bool dragNow = false;

        Camera mainCamera;

        private void Start()
        {
            inputManager = BoxManager.GetManager<InputManager>();
            mainCamera = Camera.main;

            nextPos = prevPos = new Vector3(0, 0, 0);
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                dragNow = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                dragNow = false;
            }

            if (dragNow)
            {
                Vector3 newPos = Input.mousePosition;

                nextPos = new Vector3(
                        transform.position.x + newPos.x * speedModifier,
                        transform.position.y,
                        transform.position.x + newPos.y * speedModifier);

                BoxManager.GetManager<InputManager>().SwipeJoyStick(nextPos);
            }
#else
            if (Input.touchCount > 0)
            {
                Debug.Log($"touch > 0");

                touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Moved)
                {
                    nextPos = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speedModifier,
                        transform.position.y,
                        transform.position.x + touch.deltaPosition.y * speedModifier);

                    Debug.Log($"set move = {nextPos}");

                    inputManager.SwipeJoyStick(nextPos);
                }
            }
#endif

        }
    }
}