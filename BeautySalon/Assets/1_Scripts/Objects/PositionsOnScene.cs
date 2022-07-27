using UnityEngine;

namespace ObjectsOnScene
{
    public class PositionsOnScene : Singleton<PositionsOnScene>, IInitialize
    {
        [SerializeField] private GameObject spawnPlayerPos;

        public GameObject GetSpawnPlayerPos { get => spawnPlayerPos; }

        public void OnInitialize()
        {
        }

        public void OnStart() { }
    }
}