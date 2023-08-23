using UnityEngine;

namespace Ash.Scripts
{
    public class DoorController : MonoBehaviour
    {
        public Animator door = null;

        /*public bool openTrigger = false;
    public bool closeTriger = false;
    public bool doorOpen = false;*/
        public int doorNo;



        private void Update()
        {
            if (doorNo == 1)
            {
                door.SetBool("IsOpen", true);

            }
            else if (doorNo == 0)
            {
                door.SetBool("IsOpen", false);
            }
        }

        public void OpenDoor()
        {



            if (doorNo == 1)
            {
                doorNo = 0;
            }
            else
            {
                doorNo = 1;
            }


        }

    }
}
