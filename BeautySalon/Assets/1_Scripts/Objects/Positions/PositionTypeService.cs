using UnityEngine;

namespace ObjectsOnScene 
{
    public class PositionTypeService : MonoBehaviour
    {
        [SerializeField] private TypeService typeService;

        public TypeService GetTypeService { get => typeService; }
    }
}