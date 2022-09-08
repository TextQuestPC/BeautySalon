using Characters;
using Core;
using NaughtyAttributes;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class InteractionObject : ObjectScene
    {
        [BoxGroup("Positions")]
        [SerializeField] private GameObject visitorPosition, visitorLookPosition;

        public GameObject GetVisitorPosition { get => visitorPosition; }
        public GameObject GetLookPosition { get => visitorLookPosition; }

        protected Player player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == NamesData.PLAYER_NAME)
            {
                other.TryGetComponent(out Player player);

                if (player != null)
                {
                    this.player = player;
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
                    this.player = null;
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