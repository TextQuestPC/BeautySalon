using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class StopCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.PLAYER_NAME)
            {

            }    
        }
    }
}