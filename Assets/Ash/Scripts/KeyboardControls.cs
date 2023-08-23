using UnityEngine;

namespace Ash.Scripts
{
    public class KeyboardControls : MonoBehaviour
    {
        public GameObject petals;
        public Dialogue.Dialogue dlg;
        public bool canTalk = true;
        public AlexoDialogue aDlg;
        public GameObject colour;

        public void Start()
        {
            dlg = GameObject.FindWithTag("Wisp").GetComponent<Dialogue.Dialogue>();
            aDlg = GameObject.Find("DialogueManagers").GetComponent<AlexoDialogue>();
        }

        private void Update()
        {
            Petals();
            StartFirstPara();
            StartSecondPara();
            StartThirdParagraph();
            StartFourthParagraph();
            StartFithParagraph();
            StartSixthParagraph();
            StartAlexoFirst();
            StartWisp();
            if (Input.GetKeyDown(KeyCode.O))
            {
                colour.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                colour.SetActive(false);
            }
        }

        void Petals()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                petals.SetActive(false);
            }
        }

        public void StartFirstPara()
        {
            if (Input.GetKeyUp(KeyCode.Z) && canTalk)
            {
                canTalk = false;
                dlg.SendMessage("FirstParagraph");
            }
            else
            {
                canTalk = true;
            }
        
        }
        public void StartSecondPara()
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                dlg.SendMessage("SecondParagraph");
            }
        }

        public void StartThirdParagraph()
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                dlg.SendMessage("ThirdParagraph");
            }
        }

        public void StartFourthParagraph()
        {
            if (Input.GetKeyUp(KeyCode.V))
            {
                dlg.SendMessage("FourthParagraph");
            }
        }

        public void StartFithParagraph()
        {
            if (Input.GetKeyUp(KeyCode.B))
            {
                dlg.SendMessage("FithParagraph");
            }
        }

        public void StartSixthParagraph()
        {
            if (Input.GetKeyUp(KeyCode.N))
            {
                dlg.SendMessage("SixthParagraph");
            }
        }

        public void StartAlexoFirst()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                aDlg.SendMessage("FirstParagraph");
            }
        }

        public void StartWisp()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                dlg.SendMessage("StartParagraph");
            }
        }
        
        
        
    
    
    }
}
