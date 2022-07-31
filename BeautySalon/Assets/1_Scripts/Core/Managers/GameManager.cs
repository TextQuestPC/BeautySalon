using Characters;
using ObjectsOnScene;
using System;
using SystemMove;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        #region ACTIONS

        public static event Action PausedApplication;
        public static event Action UnpausedApplication;
        public static event Action FocusedApplication;
        public static event Action UnfocusedApplication;

        #endregion ACTIONS

        #region STATES_GAME

        public static event Action<bool> ChangeCanMove;
        public static event Action<bool> ChangeCanSpawn;
        public static event Action<bool> ChangeTimeGo;

        private bool CanMove
        {
            set => ChangeCanMove?.Invoke(value);
        }

        private bool CanSpawn
        {
            set => ChangeCanSpawn?.Invoke(value);
        }

        private bool TimeGo
        {
            set => ChangeTimeGo?.Invoke(value);
        }

        #endregion STATES_GAME

        private Player player;

        public override void OnStart()
        {
            CanMove = true;
            CanSpawn = true;
            TimeGo = true;

            SpawnObjects();
        }

        private void SpawnObjects()
        {
            player = BoxManager.GetManager<CreatorManager>().CreatePlayer();
            Camera.main.GetComponent<MoveCameraComponent>().SetNextTarget(player.transform);
        }

        #region DO_ACTIONS

        private void OnApplicationPause(bool pause)
        {
            if (BoxManager.GetIsLogging)
            {
                Debug.Log($"Application on pause = {pause}");
            }

            if (pause)
            {
                PausedApplication?.Invoke();
            }
            else
            {
                UnpausedApplication?.Invoke();
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (BoxManager.GetIsLogging)
            {
                Debug.Log($"Application on focus = {focus}");
            }

            if (focus)
            {
                FocusedApplication?.Invoke();
            }
            else
            {
                UnfocusedApplication?.Invoke();
            }
        }

        #endregion DO_ACTIONS

        #region ACTIONS_GAME

        public void PlayerTyGetItem(TypeItem typeItem)
        {
            if (player.CheckCanGetItem())
            {
                player.GetItemFromPlace(typeItem);
            }
        }

        #endregion ACTIONS_GAME
    }
}