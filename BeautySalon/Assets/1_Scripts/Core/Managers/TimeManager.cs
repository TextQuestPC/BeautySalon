using System.Collections.Generic;
using UnityEngine;
using TimerSystem;

namespace Core
{
    [CreateAssetMenu(fileName = "TimeManager", menuName = "Managers/TimeManager")]
    public class TimeManager : BaseManager, IWaitTimer
    {
        private List<IWaitTimer> waitingObjects = new List<IWaitTimer>();

        public void AddWaitingObject(IWaitTimer waitingObject)
        {
            waitingObjects.Add(waitingObject);
        }

        public void RemoveWaitingObject(IWaitTimer waitingObject)
        {
            if (waitingObjects.Contains(waitingObject))
            {
                waitingObjects.Remove(waitingObject);
            }
        }

        public void TickTimer()
        {
            if (waitingObjects.Count > 0)
            {
                for (int i = 0; i < waitingObjects.Count; i++)
                {
                    waitingObjects[i].TickTimer();
                }
            }
        }
    }
}