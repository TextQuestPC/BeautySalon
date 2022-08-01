using UnityEngine;

namespace ObjectsOnScene 
{
    public class PositionPlaceSpawn : MonoBehaviour
    {
        [SerializeField] private TypeService typeService;

        public TypeService GetTypeService { get => typeService; }
    }
}