using UnityEngine;

namespace Ash.Scripts.Waypoints
{
    public class MoveToHouse : MonoBehaviour
    {
        private LayerMask wisp;
        public Dialogue.Dialogue dlg;

        private void Start()
        {
   
            dlg = GameObject.FindWithTag("Wisp").GetComponent<Dialogue.Dialogue>();
        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("WispParent"))
            {
                dlg.walkTo = true;
            }
        }
    }
}
