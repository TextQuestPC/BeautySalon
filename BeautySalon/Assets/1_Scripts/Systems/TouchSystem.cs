using SystemMove;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSystem : Singleton<TouchSystem>, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MovePlayerComponent move;

    private bool down;
        

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
            float x = Input.mousePosition.x - Screen.width / 2;
            float y = Input.mousePosition.y - Screen.height / 3;

            float angle = Mathf.Atan2(x, y);
            float finalAngle = 360 * angle / (2 * Mathf.PI);

            move.Rotate(finalAngle);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        down = false;
    }
}
