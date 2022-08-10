using Core;
using UnityEngine;

namespace CollidersSystem
{
    [RequireComponent(typeof(BoxCollider))]
    public class StopCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.STOP_COLLIDER)
            {
                other.GetComponent<CheckStopCollider>().StopMove();
            }    
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == NamesData.STOP_COLLIDER)
            {
                other.GetComponent<CheckStopCollider>().StartMove();
            }
        }
    }
}