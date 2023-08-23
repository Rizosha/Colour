using UnityEngine;
using UnityEngine.AI;

namespace Ash.Scripts.Waypoints
{
    public class WispMovement : MonoBehaviour
    {
        /*//list of waypoints
    [SerializeField] private List<Waypoint> waypoints;
    //index
    public int index;
    //navmesh 
    [SerializeField] NavMeshAgent _navMeshAgent;
    //waiting bool
    public bool waiting;
   
   
   

    //if waiting is true, dont do anything and wait for talking

    //if waiting is false, set a destination with a waypoint on navmesh and move to it
    private void Update()
    {
       
        
        if (!waiting)
        {
            Vector3 targetVector = waypoints[index].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            //transform.LookAt(targetVector);
        }
        
        
        
    }*/

        // add 1 to the index for the new destination, this is for if we want the wisp to move multiple points.
    
        [SerializeField] public Transform[] waypoints;
        private Transform target;
        public int waypointindex;
        public NavMeshAgent agent;
        public Dialogue.Dialogue dlg;
        public bool waiting;
        public GameObject wisp;
        public int remDist;
    
        public State state;
        public Rigidbody wispRb;
        public GameObject alexo;
        public WispMovement wispParent;
        private Animator alexoAnim;
    
        public enum State
        {
            start,
            firstwaypoint,
        }

        private void Awake()
        {
            dlg = GameObject.FindWithTag("Wisp").GetComponent<Dialogue.Dialogue>();
            wispRb = GameObject.FindWithTag("Wisp").GetComponent<Rigidbody>();
            wispParent = GameObject.FindWithTag("WispParent").GetComponent<WispMovement>();
            alexoAnim = GameObject.FindWithTag("Boy2").GetComponent<Animator>();
            state = State.start;
        }


        void Update () 
        {
        
            switch (state)
            {
                default:

                case State.start:
                
                    break;
                case State.firstwaypoint:
                
                
                    Vector3 targetVector = waypoints[waypointindex].transform.position; 
                    agent.SetDestination(targetVector);
                  
           
                    break;
           
            }

            if (waypointindex == 8)
            {
                wispRb.detectCollisions = true;
                //dlg.GetCurrentSentences(dlg.inHouse);
            }

            

        }
        void moveWisp()
        {
            state = State.firstwaypoint;
        }

        void nextPoint()
        {
            waypointindex++;
            Vector3 targetVector = waypoints[waypointindex].transform.position; 
            agent.SetDestination(targetVector);
       
        }

        public void Corner()
        {
            waypointindex = 1;
        }
    }
}
