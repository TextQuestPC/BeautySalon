using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    public class Chair : ObjectScene
    {
        [SerializeField] private TypeItem typeNeedItem;

        public TypeItem GetTypeNeedItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                StartProcedure();
            }
        }

        private void StartProcedure()
        {

        }
    }
}