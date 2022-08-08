using InputSystem;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager")]
    public class InputManager : BaseManager
    {
        private FocusSystem focusSystem;
        private TouchSystem touchSystem;

        public override void OnStart()
        {
            focusSystem = BoxManager.GetManager<CreatorManager>().CreateFocusSystem();
            touchSystem = BoxManager.GetManager<CreatorManager>().CreateTouchSystem();
            touchSystem.SetPlayer = BoxManager.GetManager<GameManager>().GetPlayer.GetMove;
        }
    }
}