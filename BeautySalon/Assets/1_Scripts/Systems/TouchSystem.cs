using SystemMove;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSystem : Singleton<TouchSystem>, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private MovePlayerComponent move;

    private bool down;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        down = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        CreateAngleRotation(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        down = false;
    }

    private void CreateAngleRotation(Vector3 positionTouch)
    {
        float x = positionTouch.x - Screen.width / 2;
        float y = positionTouch.y - Screen.height / 3;

        float angle = Mathf.Atan2(x, y);
        float finalAngle = 360 * angle / (2 * Mathf.PI);

        move.Rotate(finalAngle);
    }

#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = FindObjectOfType<MovePlayerComponent>();
            down = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            down = false;
        }

        if (down)
        {
            CreateAngleRotation(Input.mousePosition);
        }
    }
#endif

}
