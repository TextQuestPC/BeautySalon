using Characters;
using GameUpdate;
using InputSystem;
using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CreatorManager", menuName = "Managers/CreatorManager")]
    public class CreatorManager : BaseManager
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Service[] placesSpawnPrefabs;
        [SerializeField] private Item[] itemsPrefabs;
        [SerializeField] private Visitor visitorPrefab;

        private GameObject objectsParent, singletonsParent, parentPlaceSpawn, parentItems, parentVisitors;

        public override void OnInitialize()
        {
            objectsParent = new GameObject(NamesData.OBJECTS);
            singletonsParent = new GameObject(NamesData.SINGLETONS);
            singletonsParent.transform.SetParent(objectsParent.transform);

            parentPlaceSpawn = new GameObject(NamesData.SERVICE);
            parentItems = new GameObject(NamesData.ITEMS);
            parentVisitors = new GameObject(NamesData.VISITORS);

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

        public Service CreateService(TypeService typeService)
        {
            Vector3 position = PositionsOnScene.Instance.GetPositionService(typeService).transform.position;
            Service prefab = null;

            foreach (var place in placesSpawnPrefabs)
            {
                if(place.GetTypeService == typeService)
                {
                    prefab = place;
                    break;
                }
            }

            if (prefab == null)
            {
                Debug.Log($"<color=red>Нет префаба PlaceSpawn типа {typeService}</color>");
            }

            Service service = Instantiate(prefab, position, Quaternion.identity);
            prefab.gameObject.name = NamesData.SERVICE + $" {typeService}";
            service.transform.SetParent(parentPlaceSpawn.transform);

            return service;
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

        public Visitor CreateVisitor()
        {
            Vector3 spawnPos = PositionsOnScene.Instance.GetSpawnVisitorPos.transform.position;

            Visitor visitor = Instantiate(visitorPrefab, spawnPos, Quaternion.identity);
            visitor.gameObject.name = NamesData.VISITOR;
            visitor.transform.SetParent(parentVisitors.transform);
            visitor.OnInitialize();

            return visitor;
        }

        public TouchSystem CreateTouchSystem()
        {
            GameObject newObject = new GameObject(NamesData.TOUCH_SYSTEM);
            newObject.transform.SetParent(singletonsParent.transform);
            return newObject.AddComponent<TouchSystem>();
        }

        public FocusSystem CreateFocusSystem()
        {
            GameObject newObject = new GameObject(NamesData.FOCUS_SYSTEM);
            newObject.transform.SetParent(objectsParent.transform);
            return newObject.AddComponent<FocusSystem>();
        }

        public UpdateGame CreateUpdateGame()
        {
            GameObject newObject = new GameObject(NamesData.UPDATE_MANAGER);
            newObject.transform.SetParent(objectsParent.transform);
            return newObject.AddComponent<UpdateGame>();
        }
    }
}