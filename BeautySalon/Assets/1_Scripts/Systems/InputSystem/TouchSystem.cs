using Core;
using UnityEngine;

namespace InputSystem
{
    public class TouchSystem : MonoBehaviour
    {
        private Touch touch;

        private Vector3 startPos;
        private Vector3 nextPos;

        private InputManager inputManager;

        [SerializeField] private float speedModifier;

        private void Start()
        {
            inputManager = BoxManager.GetManager<InputManager>();
        }

        private void Update()
        {
//#if UNITY_EDITOR
//            if(Input.GetMouseButtonDown())
//#endif
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
        }
    }
}