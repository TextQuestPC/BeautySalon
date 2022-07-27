using Character;
using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CreatorManager", menuName = "Managers/CreatorManager")]
    public class CreatorManager : BaseManager
    {
        [SerializeField] private Player playerPrefab;

        private GameObject objectsParent;

        private Vector3 startSpawnPosition = new Vector3(0, 0, 0);

        public override void OnInitialize()
        {
            objectsParent = new GameObject(NamesData.OBJECTS);
        }

        public Player CreatePlayer()
        {
            Vector3 spawnPos = PositionsOnScene.Instance.GetSpawnPlayerPos.transform.position;

            Player player = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            player.gameObject.name = NamesData.PLAYER_NAME;
            player.transform.SetParent(objectsParent.transform);
            player.OnInitialize();

            return player;
        }
    }
}