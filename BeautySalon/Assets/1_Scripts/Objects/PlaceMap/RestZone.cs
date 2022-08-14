using Characters;
using UnityEngine;

namespace ObjectsOnScene
{
    public class RestZone : PlaceMap
    {
        protected override void PlayerInCollider(Player player) { }

        protected override void PlayerOutCollider(Player player) { }
    }
}