using Characters;
using UnityEngine;

namespace CollidersSystem
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class CheckStopCollider : MonoBehaviour
    {
        private Player player;

        private void Start()
        {
            player = GetComponentInParent<Player>();
        }

        public void StopMove()
        {
            player.ChangeMove(false);
        }

        public void StartMove()
        {
            player.ChangeMove(true);
        }
    }
}