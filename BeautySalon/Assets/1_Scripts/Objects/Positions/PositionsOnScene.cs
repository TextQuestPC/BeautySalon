using UnityEngine;

namespace ObjectsOnScene
{
    public class PositionsOnScene : Singleton<PositionsOnScene>, IInitialize
    {
        [SerializeField] private GameObject spawnPlayerPos,spawnItemsPos, spawnVisitorPos;
        [SerializeField] private GameObject restZonePos, leftStartMovePos, rightStartMovePos;

        [SerializeField] private PositionTypeService[] positionsServices;
        [SerializeField] private PositionTypeService[] positionsStorages;

        public GameObject GetSpawnPlayerPos { get => spawnPlayerPos; }
        public GameObject GetSpawnItemsPos { get => spawnItemsPos; }
        public GameObject GetSpawnVisitorPos { get => spawnVisitorPos; }
        public GameObject GetRestZonePos { get => restZonePos; }
        public GameObject GetLeftStartMovePos { get => leftStartMovePos; }
        public GameObject GetRightStartMovePos { get => rightStartMovePos; }

        public GameObject GetPositionService(TypeService typeService)
        {
            foreach (var position in positionsServices)
            {
                if (position.GetTypeService == typeService)
                {
                    return position.gameObject;
                }
            }

            Debug.Log($"<color=red>Not find position service {typeService}</color>") ;

            return null;
        }

        public GameObject GetPositionStorage(TypeService typeService)
        {
            foreach (var position in positionsStorages)
            {
                if (position.GetTypeService == typeService)
                {
                    return position.gameObject;
                }
            }

            Debug.Log($"<color=red>Not find position storage {typeService}</color>");

            return null;
        }

        public void OnInitialize()
        {
        }

        public void OnStart()
        {
        }
    }
}