using System.Collections;
using System.Collections.Generic;
using SystemMove;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSystem : Singleton<TouchSystem>, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MovePlayerComponent move;

    private bool down;
    private float rotateDrag;

    public void OnPointerDown(PointerEventData eventData)
    {
        down = true;
    }

    public void Update()
    {
        rotateDrag =  Mathf.Atan2(Input.mousePosition.y - move.transform.position.y, Input.mousePosition.x - move.transform.position.x) * Mathf.Rad2Deg;
        move.Rotate(rotateDrag);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
