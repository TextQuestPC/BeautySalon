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

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                StartProcedure();
            }
        }

        private void StartProcedure()
        {
            leftTimeProcedure = 0;
            sliderProcedure.SetMaxValue = timeProcedure;
            sliderProcedure.gameObject.SetActive(true);

            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        public void TickTimer()
        {
            leftTimeProcedure += Time.deltaTime;

            sliderProcedure.ChangeValue(leftTimeProcedure);

            if (leftTimeProcedure >= timeProcedure)
            {
                sliderProcedure.gameObject.SetActive(false);
                Debug.Log("End procedure");
            }
        }
    }
}