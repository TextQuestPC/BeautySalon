using Characters;
using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CreatorManager", menuName = "Managers/CreatorManager")]
    public class CreatorManager : BaseManager
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private PlaceSpawnItem[] placesSpawnPrefabs;

        private GameObject objectsParent;
        private GameObject parentPlaceSpawn;

        private Vector3 startSpawnPosition = new Vector3(0, 0, 0);

        public override void OnInitialize()
        {
            objectsParent = new GameObject(NamesData.OBJECTS);
            parentPlaceSpawn = new GameObject(NamesData.PLACE_SPAWN);
            parentPlaceSpawn.transform.SetParent(objectsParent.transform);
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

        public PlaceSpawnItem CreatePlaceSpawn(TypePlaceSpawnItem typePlaceSpawn)
        {
            Vector3 position = PositionsOnScene.Instance.GetPositionPlaceSpawn(typePlaceSpawn).transform.position;
            PlaceSpawnItem prefab = null;

            foreach (var place in placesSpawnPrefabs)
            {
                if(place.GetTypePlace == typePlaceSpawn)
                {
                    prefab = place;
                }
            }

            if (prefab == null)
            {
                Debug.Log($"<color=red>Нет префаба PlaceSpawn типа {typePlaceSpawn}</color>");
            }

            PlaceSpawnItem placeSpawn = Instantiate(prefab, position, Quaternion.identity);
            prefab.gameObject.name = NamesData.PLACE_SPAWN + $" {typePlaceSpawn}";
            placeSpawn.transform.SetParent(parentPlaceSpawn.transform);

            return placeSpawn;
        }
    }
}