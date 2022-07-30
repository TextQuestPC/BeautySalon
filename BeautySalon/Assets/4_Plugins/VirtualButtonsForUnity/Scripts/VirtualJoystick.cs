using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public enum VirtualJoystickType { Fixed, Floating }

namespace JoyStick
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform centerArea = null;
        [SerializeField] private RectTransform handle = null;
        [InputControl(layout = "Vector2")]
        [SerializeField] private string stickControlPath;
        [SerializeField] private float movementRange = 100f;

        private bool hideOnPointerUp = false;
        private bool centralizeOnPointerUp = true;
        private Canvas canvas;
        private RectTransform baseRect = null;
        private OnScreenStick handleStickController = null;
        private CanvasGroup bgCanvasGroup = null;
        private Vector2 initialPosition = Vector2.zero;

        protected virtual void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            baseRect = GetComponent<RectTransform>();
            bgCanvasGroup = centerArea.GetComponent<CanvasGroup>();
            handleStickController = handle.gameObject.AddComponent<OnScreenStick>();
            handleStickController.movementRange = movementRange;
            handleStickController.controlPath = stickControlPath;

            Vector2 center = new Vector2(0.5f, 0.5f);
            centerArea.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;

            initialPosition = centerArea.anchoredPosition;

            if (hideOnPointerUp)
            {
                bgCanvasGroup.alpha = 0;
            }
            else
            {
                bgCanvasGroup.alpha = 1;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerEventData constructedEventData = new PointerEventData(EventSystem.current);
            constructedEventData.position = handle.position;
            handleStickController.OnPointerDown(constructedEventData);

            centerArea.anchoredPosition = GetAnchoredPosition(eventData.position);

            if (hideOnPointerUp)
            {
                bgCanvasGroup.alpha = 1;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            handleStickController.OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (centralizeOnPointerUp)
            {
                centerArea.anchoredPosition = initialPosition;
            }

            if (hideOnPointerUp)
            {
                bgCanvasGroup.alpha = 0;
            }
            else
            {
                bgCanvasGroup.alpha = 1;
            }

            PointerEventData constructedEventData = new PointerEventData(EventSystem.current);
            constructedEventData.position = Vector2.zero;

            handleStickController.OnPointerUp(constructedEventData);
        }

        protected Vector2 GetAnchoredPosition(Vector2 screenPosition)
        {
            Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceCamera) ? canvas.worldCamera : null;
            Vector2 localPoint = Vector2.zero;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, cam, out localPoint))
            {
                Vector2 pivotOffset = baseRect.pivot * baseRect.sizeDelta;
                return localPoint - (centerArea.anchorMax * baseRect.sizeDelta) + pivotOffset;
            }

            return Vector2.zero;
        }
    }
}