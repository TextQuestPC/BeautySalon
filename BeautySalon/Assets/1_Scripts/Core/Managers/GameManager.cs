using Characters;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        private Player player;

        public Player GetPlayer { get => player; }

        public override void OnStart()
        {
            player = BoxManager.GetManager<CreatorManager>().CreatePlayer();
            Camera.main.GetComponent<MoveCameraComponent>().SetNextTarget(player.transform);
        }

        #region ACTIONS_GAME

        public void PlayerTyGetItem(TypeItem typeItem)
        {
            if (player.CheckCanGetItem())
            {
                player.GetItemFromPlace(typeItem);
            }
        }

        public void CompleteProcedure(Chair chair)
        {
            player.RemoveItem(chair.GetTypeNeedItem);
        }

        #endregion ACTIONS_GAME
    }
}