using Core;
using InputSystem;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;

public class Player : ObjectScene, IWaitJoystick
{
    private MoveObjectComponent moveSystem;

    public override void OnInitialize()
    {
        moveSystem = gameObject.AddComponent<MoveObjectComponent>();
        BoxManager.GetManager<InputManager>().AddListenerJoystick(this);
    }

    public void SwipeJoystick(Vector3 positionMove)
    {
        moveSystem.SetNextPosition(positionMove);
    }
}