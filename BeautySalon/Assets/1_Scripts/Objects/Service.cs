using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Service : ObjectScene
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        public TypeService GetTypeService { get => typeService; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.PLAYER_NAME)
            {
                BoxManager.GetManager<GameManager>().PlayerTyGetItem(typeItem);
            }
        }
    }
}