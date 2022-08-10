using UnityEngine;

namespace ObjectsOnScene
{
    public class PositionsOnScene : Singleton<PositionsOnScene>, IInitialize
    {
        [SerializeField] private GameObject spawnPlayerPos;
        [SerializeField] private GameObject spawnItemsPos;
        [SerializeField] private GameObject spawnVisitorPos;
        [SerializeField] private PositionTypeService[] positionsServices;
        [SerializeField] private GameObject positionStorage;

        public GameObject GetSpawnPlayerPos { get => spawnPlayerPos; }
        public GameObject GetSpawnItemsPos { get => spawnItemsPos; }
        public GameObject GetSpawnVisitorPos { get => spawnVisitorPos; }

        public GameObject GetPositionService(TypeService typeService)
        {
            foreach (var position in positionsServices)
            {
                if (position.GetTypeService == typeService)
                {
                    return position.gameObject;
                }
            }

            Debug.Log($"<color=red>??? ??????? PlaceSpawn ? ????? {typeService}</color>") ;

            return null;
        }

        public GameObject GetPositionStorage()
        {
            return positionStorage;
        }

        public void OnInitialize()
        {
        }

        public void OnStart()
        {
        }
    }
}