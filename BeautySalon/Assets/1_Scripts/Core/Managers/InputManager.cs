using System.Collections.Generic;
using InputSystem;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager")]
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

        public void SwipeJoyStick(Vector3 positionMove)
        {
            foreach (var listener in listenerJoystick)
            {
                listener.SwipeJoystick(positionMove);
            }
        }
    }
}