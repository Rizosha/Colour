using System.Collections;
using Ash.Scripts.Waypoints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ash.Scripts
{
  public class StartOfScene : MonoBehaviour
  {
    public GameObject blackout;
   
    private WispMovement wMove;

    public GameObject colour;
    public AlexoDialogue sc2;
    public int sequenceIndex;
    public Dialogue.Dialogue wisp;
    public bool ColourToggle;
    // grabs player movement script to change states
    // turns the dialogue box off
    private void Start()
    {
   
      //wMove = GameObject.Find("WispParent").GetComponent<WispMovement>();
      sc2 = GameObject.Find("DialogueManagers").GetComponent<AlexoDialogue>();
      wisp = GameObject.FindWithTag("Wisp").GetComponent<Dialogue.Dialogue>();

      //colour.SetActive(ColourToggle);
      blackout.SetActive(true);

      sc2.SendMessage("FirstParagraph");
    }

    
    private void Update()
    {
      

      /*if (sequenceIndex == 1)
      {
        wisp.SendMessage("StartParagraph");
      }

      if (sequenceIndex == 2)
      {
        blackout.SetActive(false);
      }*/

    }

    public void sequence()
    {
      sequenceIndex++;
    }

  }
}
