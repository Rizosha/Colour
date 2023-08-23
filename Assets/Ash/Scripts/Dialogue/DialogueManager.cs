using UnityEngine;

namespace Ash.Scripts.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private bool triggerActive = false;
        public GameObject dialogueText;
    
        // when collided with player the trigger is active
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = true;
            }
        }
        // trigger not active
        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = false;
            }
        }

        private void Update()
        {
            // this needs to change because it keeps re sending  the trigger and bugs out text. 
            // some sort of check is needed to stop this 
            if (triggerActive && Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("talking here");
                // dialogueText.GetComponent<Dialogue>().GenerateSentence();
            }
        }
    
    
    }
}
