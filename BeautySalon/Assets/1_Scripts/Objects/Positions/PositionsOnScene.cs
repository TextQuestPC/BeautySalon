using UnityEngine;

namespace ObjectsOnScene
{
    public class PositionsOnScene : Singleton<PositionsOnScene>, IInitialize
    {
        [SerializeField] private GameObject spawnPlayerPos;
        [SerializeField] private PositionPlaceSpawn[] positionsPlaceSpawn;

        public GameObject GetSpawnPlayerPos { get => spawnPlayerPos; }

        public GameObject GetPositionPlaceSpawn(TypePlaceSpawnItem typePlaceSpawn)
        {
            foreach (var position in positionsPlaceSpawn)
            {
                if (position.GetTypePlaceSpawn == typePlaceSpawn)
                {
                    return position.gameObject;
                }
            }

            Debug.Log($"<color=red>Нет позиции PlaceSpawn с типом {typePlaceSpawn}</color>") ;

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