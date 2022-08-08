using Core;
using UnityEngine;

namespace InputSystem
{
    public class FocusSystem : MonoBehaviour
    {
        private void OnApplicationFocus(bool focus)
        {
            if (BoxManager.GetIsLogging)
            {
                Debug.Log($"Application on focus = {focus}");
            }

            BoxManager.GetManager<StateGameManager>().ChangeFocusApplication(focus);
        }
    }
}