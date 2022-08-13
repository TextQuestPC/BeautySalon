using Characters;
using Core;
using TimerSystem;
using UI;
using UnityEngine;

namespace ObjectsOnScene
{
    public class ServiceWithTime : Service, IWaitTimer
    {
        [SerializeField] private CanvasService canvasService;
        [SerializeField] private float timeProcedure = 2f;

        private float leftTimeProcedure;
        private bool procedureNow = false;

        protected override void PlayerOutCollider(Player player)
        {
            if (procedureNow)
            {
                StopProcedure();
            }
        }

        #region PROCEDURE

        protected override void StartProcedure()
        {
            leftTimeProcedure = 0;
            canvasService.SetMaxValue = timeProcedure;
            canvasService.gameObject.SetActive(true);

            procedureNow = true;
            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        public void TickTimer()
        {
            if (procedureNow)
            {
                leftTimeProcedure += Time.deltaTime;
                canvasService.ChangeValue(leftTimeProcedure);

                if (leftTimeProcedure >= timeProcedure)
                {
                    StopProcedure();
                    CompleteProcedure();
                }
            }
        }

        private void StopProcedure()
        {
            procedureNow = false;
            canvasService.gameObject.SetActive(false);

            BoxManager.GetManager<TimeManager>().RemoveWaitingObject(this);
        }

        private void CompleteProcedure()
        {
            isFree = true;

            BoxManager.GetManager<GameManager>().CompleteProcedure(this);
            myVisitor.CompleteProcedure();
        }

        #endregion PROCEDURE
    }
}
