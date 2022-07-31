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
        [SerializeField] private Item[] itemsPrefabs;

        private GameObject objectsParent;
        private GameObject parentPlaceSpawn;
        private GameObject parentItems;

        public override void OnInitialize()
        {
            objectsParent = new GameObject(NamesData.OBJECTS);
            parentPlaceSpawn = new GameObject(NamesData.PLACE_SPAWN);
            parentItems = new GameObject(NamesData.ITEMS);

            parentPlaceSpawn.transform.SetParent(objectsParent.transform);
            parentItems.transform.SetParent(objectsParent.transform);
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
                    break;
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

        public Item CreateItem(TypeItem typeItem)
        {
            Vector3 spawnPos = PositionsOnScene.Instance.GetSpawnItemsPos.transform.position;
            Item currentItemPrefab = null;

            foreach (var itemPrefab in itemsPrefabs)
            {
                if(itemPrefab.GetTypeItem == typeItem)
                {
                    currentItemPrefab = itemPrefab;
                    break;
                }
            }

            if(currentItemPrefab == null)
            {
                Debug.Log($"<color=red>Нет префаба Item типа {typeItem}</color>");
            }

            Item item = Instantiate(currentItemPrefab, spawnPos, Quaternion.identity);
            item.gameObject.name = NamesData.ITEM + $" {typeItem}";
            item.transform.SetParent(objectsParent.transform);

            return item;
        }
    }
}