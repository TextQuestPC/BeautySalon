using Characters;
using UnityEngine;

namespace ObjectsOnScene
{
    public class RestZone : InteractionObject
    {
        protected override void PlayerInCollider(Player player) { }

        protected override void PlayerOutCollider(Player player) { }
    }
}