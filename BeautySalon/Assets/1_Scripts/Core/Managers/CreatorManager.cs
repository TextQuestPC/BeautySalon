using ObjectsOnScene;
using SystemEffect;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CreatorManager", menuName = "Managers/CreatorManager")]
    public class CreatorManager : BaseManager
    {
        private GameObject someParent;

        public override void OnInitialize()
        {
            someParent = new GameObject(NamesData.SOME_NAME);
        }

        //public Tower CreateTower(Tower towerPrefab, Tile tileForSpawn)
        //{
        //    Vector3 positionSpawn = tileForSpawn.transform.position;
        //    Quaternion rotationSpawn = Quaternion.Euler(0, 0, 0);
        //    positionSpawn.y += offsetYTower;

        //    Tower tower = Instantiate(towerPrefab, positionSpawn, rotationSpawn);

        //    tower.tag = NamesData.TagTower;
        //    tower.transform.SetParent(towersParent.transform);
        //    tower.OnInitialize();

        //    return tower;
        //}
    }
}