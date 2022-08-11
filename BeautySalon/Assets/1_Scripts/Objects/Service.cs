using Characters;
using Core;
using TimerSystem;
using UI;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Service : ObjectScene, IWaitTimer
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private CanvasService canvasService;
        [SerializeField] private float timeProcedure = 2f;
        [SerializeField] private GameObject chairPosition;        

        private float leftTimeProcedure;
        private bool procedureNow = false;
        private bool isFree = true;

        private Visitor myVisitor;

        public bool GetIsFree { get => isFree; }
        public TypeService GetTypeService { get => typeService; }
        public TypeItem GetTypeNeedItem { get => myVisitor.GetTypeItem; }
        public GameObject GetChairPosition { get => chairPosition; }

        public void VisitorIsCame(Visitor visitor)
        {
            isFree = false;
            myVisitor = visitor;
        }

        #region TRIGGER

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                if (!isFree)
                {
                    if (myVisitor != null)
                    {
                        if (other.GetComponent<Player>().CheckHaveItem(GetTypeNeedItem))
                        {
                            StartProcedure();
                        }
                    }
                    else
                    {
                        Debug.Log($"<color=red>Not visitor! But service is not free!</color>");
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                if (procedureNow)
                {
                    if (other.tag == NamesData.PLAYER_NAME)
                    {
                        StopProcedure();
                    }
                }
            }
        }

        #endregion TRIGGER

        #region PROCEDURE

        private void StartProcedure()
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

        #endregion PROCEDURE

        private void CompleteProcedure()
        {
            BoxManager.GetManager<GameManager>().CompleteProcedure(this);
        }
    }
}