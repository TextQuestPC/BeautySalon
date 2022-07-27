using Core;
using InputSystem;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;

public class Player : ObjectScene, IWaitJoystick
{
    private MoveObjectSystem moveSystem;


    public override void OnInitialize()
    {
        moveSystem = new MoveObjectSystem();
        BoxManager.GetManager<InputManager>().AddListenerJoystick(this);
    }

    public void SwipeJoystick(Vector2 positionMove)
    {
        Debug.Log("move player");
    }
}