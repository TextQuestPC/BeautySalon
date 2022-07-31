using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    public class PlaceSpawnItem : ObjectScene
    {
        [SerializeField] private TypePlaceSpawnItem typePlace;
        [SerializeField] private TypeItem typeItem;

        public TypePlaceSpawnItem GetTypePlace { get => typePlace; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.PLAYER_NAME)
            {
                BoxManager.GetManager<GameManager>().PlayerTyGetItem(typeItem);
            }
        }
    }
}