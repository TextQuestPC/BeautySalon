using UnityEngine;

namespace ObjectsOnScene
{
    public class CashService : MonoBehaviour
    {
        [SerializeField] private GameObject payPosition;

        public GameObject GetPayPosition { get => payPosition; }
    }
}