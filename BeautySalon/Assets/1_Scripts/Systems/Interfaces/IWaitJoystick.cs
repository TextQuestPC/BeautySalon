using UnityEngine;

namespace InputSystem
{
    public interface IWaitJoystick
    {
        public void SwipeJoystick(Vector3 positionMove);
        public void StopSwipe();
    }
}