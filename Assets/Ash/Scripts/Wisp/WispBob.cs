using UnityEngine;

namespace Ash.Scripts.Wisp
{
    public class WispBob : MonoBehaviour
    {
    
        public float min;
        public float max;
        public float bobValue;
        private Vector3 wispPos;
        public GameObject wispP;
    
    
        // Update is called once per frame
        private void Start()
        {
       
        }

        void Update()
        {
            wispPos = wispP.transform.position;
            bobValue = Mathf.Lerp(wispPos.y + 3f, wispPos.y + 4f, Mathf.PingPong(Time.time, 1));
            gameObject.transform.position = new Vector3(wispPos.x, bobValue, wispPos.z);
        
       
        }
    }
}
