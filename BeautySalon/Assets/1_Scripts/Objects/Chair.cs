using Characters;
using Core;
using TimerSystem;
using UI;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Chair : ObjectScene, IWaitTimer
    {
        [SerializeField] private TypeItem typeNeedItem;
        [SerializeField] private CanvasChair sliderProcedure;
        [SerializeField] private float timeProcedure = 2f;

        public TypeItem GetTypeNeedItem { get => typeNeedItem; }

        private float leftTimeProcedure;
        private bool procedureNow = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                if (other.GetComponent<Player>().CheckHaveItem(typeNeedItem))
                {
                    StartProcedure();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (procedureNow)
            {
                if (other.tag == NamesData.PLAYER_NAME)
                {
                    StopProcedure();
                }
            }
        }

        private void StartProcedure()
        {
            leftTimeProcedure = 0;
            sliderProcedure.SetMaxValue = timeProcedure;
            sliderProcedure.gameObject.SetActive(true);

            procedureNow = true;
            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        public void TickTimer()
        {
            if (procedureNow)
            {
                leftTimeProcedure += Time.deltaTime;
                sliderProcedure.ChangeValue(leftTimeProcedure);

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
            sliderProcedure.gameObject.SetActive(false);

            BoxManager.GetManager<TimeManager>().RemoveWaitingObject(this);
        }

        private void CompleteProcedure()
        {
            BoxManager.GetManager<GameManager>().CompleteProcedure(this);
        }
    }
}