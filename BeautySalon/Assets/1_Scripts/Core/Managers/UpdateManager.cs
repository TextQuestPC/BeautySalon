using System.Collections.Generic;
using SystemMove;
using SystemShoot;
using UnityEngine;
using GameUpdate;

namespace Core
{
    [CreateAssetMenu(fileName = "UpdateManager", menuName = "Managers/UpdateManager")]
    public class UpdateManager : BaseManager
    {
        private UpdateGame updateGame;

        private List<IMove> moveObjects = new List<IMove>();
        private List<IShoot> shootObjects = new List<IShoot>();
        private TimeManager timer;

        private bool canMove;
        private bool timeGo;

        #region INITIALIZE

        public override void OnInitialize()
        {
            GameObject newObject = new GameObject();
            newObject.name = NamesData.UPDATE_MANAGER;

            updateGame = newObject.gameObject.AddComponent<UpdateGame>();

            timer = BoxManager.GetManager<TimeManager>();

            GameManager.ChangeCanMove += (bool canMove) => { this.canMove = canMove; };
            GameManager.ChangeTimeGo += (bool timeGo) => { this.timeGo = timeGo; };
        }

        public override void OnStart()
        {
            updateGame.SubscribeOnUpdate(NewFrame);
        }

        #endregion INITIALIZE

        private void NewFrame()
        {
            if (canMove)
            {
                foreach (var moveObject in moveObjects)
                {
                    moveObject.Move();
                }
            }

            if (timeGo)
            {
                if (timer != null)
                {
                    timer.TickTimer();
                }
            }
        }

        #region ADD/REMOVE_SUBSCRIBERS

        public void AddMoveObject(IMove moveObject)
        {
            moveObjects.Add(moveObject);
        }

        public void RemoveMoveObject(IMove moveObject)
        {
            if (moveObjects.Contains(moveObject))
            {
                moveObjects.Remove(moveObject);
            }
        }

        public void AddShootObject(IShoot shootObject)
        {
            shootObjects.Add(shootObject);
        }

        public void RemoveShootObject(IShoot shootObject)
        {
            if (shootObjects.Contains(shootObject))
            {
                shootObjects.Remove(shootObject);
            }
        }

        #endregion ADD/REMOVE_SUBSCRIBERS
    }
}