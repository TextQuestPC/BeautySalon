using Core;
using InputSystem;
using ObjectsOnScene;
using SystemMove;

public class Player : ObjectScene, IWaitJoystick
{
    private MoveObjectSystem moveSystem;


    public override void OnInitialize()
    {
        moveSystem = new MoveObjectSystem();
        BoxManager.GetManager<InputManager>().AddListenerJoystick(this);
    }

    public void SwipeJoystick(float horizontal, float vertical)
    {
        throw new System.NotImplementedException();
    }
}