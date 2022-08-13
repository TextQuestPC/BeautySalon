using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class PlaceMap : ObjectScene
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                other.TryGetComponent(out Player player);

                if (player != null)
                {
                    PlayerInCollider(player);
                }
                else
                {
                    Debug.Log($"<color=red>Component player not find!</color>");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                other.TryGetComponent(out Player player);

                if (player != null)
                {
                    PlayerOutCollider(player);
                }
                else
                {
                    Debug.Log($"<color=red>Component player not find!</color>");
                }
            }
        }

        protected abstract void PlayerInCollider(Player player);
        protected abstract void PlayerOutCollider(Player player);
    }
}