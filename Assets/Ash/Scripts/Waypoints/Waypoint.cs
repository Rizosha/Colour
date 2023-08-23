using UnityEngine;

namespace Ash.Scripts.Waypoints
{
    public class Waypoint : MonoBehaviour
    {
        public float gizmo;
        private LayerMask wisp;
        public WispMovement wMove;
        public Transform nextPoint;
        private Rigidbody wRb;
        public WispMovement boyC;
    
        private void Start()
        {
            wMove = GameObject.FindWithTag("WispParent").GetComponent<WispMovement>();
            wRb = GameObject.FindWithTag("Wisp").GetComponent<Rigidbody>();
            boyC = GameObject.FindWithTag("Boy2").GetComponent<WispMovement>();


        }
    
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, gizmo);
       
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("WispParent"))
            {
                wMove.waypointindex += 1;
                wRb.detectCollisions = false;
            }

            if (other.gameObject.CompareTag("Boy2"))
            {
                boyC.SendMessage("Corner");
            }
        }
        
    }
}
