using UnityEngine;

namespace ObjectsOnScene
{
    public class AllObjectsInScene : Singleton<AllObjectsInScene>, IInitialize
    {
        //[SerializeField] private GameObject spawnEnemyPosition;
        //[SerializeField] private ObjectScene[] enemyPositions;

        //public GameObject GetSpawnEnemyPosition { get => spawnEnemyPosition; }

        public void OnInitialize()
        {
        }

        public void OnStart() { }

        //public ObjectScene GetEnemyPosition(int numberPos, out bool endPos)
        //{
        //    if (enemyPositions.Length > numberPos)
        //    {
        //        endPos = false;
        //        return enemyPositions[numberPos];
        //    }
        //    else
        //    {
        //        endPos = true;
        //        return null;
        //    }
        //}
    }
}