using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Storage : ObjectScene
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.PLAYER_NAME)
            {
                BoxManager.GetManager<GameManager>().PlayerTryGetItem(typeItem);
            }
        }
    }
}