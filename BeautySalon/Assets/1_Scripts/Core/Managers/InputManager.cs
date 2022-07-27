using System.Collections.Generic;
using Core;
using InputSystem;
using UnityEngine;

public class InputManager : BaseManager
{
    private List<IWaitJoystick> listenerJoystick = new List<IWaitJoystick>();

    public void AddListenerJoystick(IWaitJoystick listener)
    {
        if (listenerJoystick.Contains(listener))
        {
            Debug.Log($"<color=red>Уже добавлен listener {listener}!!!</color>");
        }
        else
        {
            listenerJoystick.Add(listener);
        }
    }

    public void SwipeJoyStick(float horizontal, float vertical)
    {
        foreach (var listener in listenerJoystick)
        {
            listener.SwipeJoystick(horizontal, vertical);
        }
    }
}
