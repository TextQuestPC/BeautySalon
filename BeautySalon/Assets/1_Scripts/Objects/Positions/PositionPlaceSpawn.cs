using UnityEngine;

namespace ObjectsOnScene 
{
    public class PositionPlaceSpawn : MonoBehaviour
    {
        [SerializeField] private TypePlaceSpawnItem typePlaceSpawn;

        public TypePlaceSpawnItem GetTypePlaceSpawn { get => typePlaceSpawn; }
    }
}