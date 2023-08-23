using System;
using System.Collections;
using Ash.Scripts.Waypoints;
using TMPro;
using UnityEngine;

namespace Ash.Scripts
{
  public class AlexoDialogue : MonoBehaviour
  {
    public TextMeshProUGUI textDisplay;
    //public string[] firstSentences,walkToHouse,inHouse;
    public string[] firstParagraph;
    public string[] secondParagraph;
    public string[] thirdParagraph;
    public string[] fourthParagraph;
    public string[] fithParagraph;
    public string[] sixthParagraph;
  
    private int index;
    public float typingSpeed;
    public bool canContinue = false;
    public GameObject box;

    private PlayerMovement pScript;
    private WispMovement wMove;
    public GameObject parent;

    public string[] currentSentences;
    public bool walkTo;
    public bool canMove;
    public int canMoveIndex;
    public bool stateBool;
    public KeyboardControls kB;
    public StartOfScene scene;
    public Dialogue.Dialogue wisp;
  
    // grabs player movement script to change states
    // turns the dialogue box off
    private void Start()
    {
      GetCurrentSentences(firstParagraph);
   
      pScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
      wMove = GameObject.Find("WispParent").GetComponent<WispMovement>();
      scene = GameObject.FindWithTag("DialogueManagers").GetComponent<StartOfScene>();
      wisp = GameObject.FindWithTag("Wisp").GetComponent<Dialogue.Dialogue>();
      kB = GameObject.FindWithTag("DialogueManagers").GetComponent<KeyboardControls>();

      //box.SetActive(false);
    }
  

    private void Update()
    {
    
      // if the text has written out then you can continue
      if (textDisplay.text == currentSentences[index])
      {
        canContinue = true;
      }
            
      if (Input.GetKeyDown(KeyCode.E) && canContinue)
      {
        NextSentence();
      }

      if (canMoveIndex == 0)
      {
        stateBool = true;
      }
      if (canMoveIndex == 1)
      {
        stateBool = false;
//        parent.SendMessage("moveWisp");
      }
      //WalkToHouse();
    
    
    
    }

    // types out the text at a given speed
    IEnumerator Type()
    {
      foreach (var letter in currentSentences[index].ToCharArray())
      {
        textDisplay.text += letter;
        yield return new WaitForSeconds(typingSpeed);
      }
    }

    // main part for starting a conversation, sets player state, turns on dialogue box and starts the typing out. 
    public void GenerateSentence()
    {
      // if you want the character to not move
      if (stateBool)
      {
        pScript.state = PlayerMovement.State.Talking;
        stateBool = false;
      }
    
      box.SetActive(true);
      StartCoroutine(Type());
    
    }
  
    // moves onto next dialogue box, also resets the player back to normal and turns the box off. 
    public void NextSentence()
    {
      canContinue = false;
      if (index < currentSentences.Length - 1)
      {
        index++;
        textDisplay.text = "";
        StartCoroutine(Type());
      }
      else
      {
        textDisplay.text = "";
        box.SetActive(false);
        pScript.state = PlayerMovement.State.Normal;
        StartCoroutine(GrabSeconds());
        index = 0;
        kB.canTalk = true;
       
        wisp.SendMessage("StartParagraph");
       
        canMoveIndex = 1;
       

      }
    
    
    }

 

    public void GetCurrentSentences(string[] current)
    {
      Array.Resize(ref currentSentences, current.Length);
      for (int i = 0; i < current.Length; i++)
      {    
        Array.Clear(currentSentences,i,1);
        currentSentences[i] = current[i];
      }
    }

    public void WalkToHouse()
    {
      if (walkTo)
      {
        //GetCurrentSentences(walkToHouse);
        GenerateSentence();
        walkTo = false;
      }
    }

    public void FirstParagraph()
    {
      GetCurrentSentences(firstParagraph);
      GenerateSentence();
    }

    public void SecondParagraph()
    {
      GetCurrentSentences(secondParagraph);
      GenerateSentence();
    }

    public void ThirdParagraph()
    {
      GetCurrentSentences(thirdParagraph);
      GenerateSentence();
    }

    public void FourthParagraph()
    {
      GetCurrentSentences(fourthParagraph);
      GenerateSentence();
    }

    public void FithParagraph()
    {
      GetCurrentSentences(fithParagraph);
      GenerateSentence();
    }

    public void SixthParagraph()
    {
      GetCurrentSentences(sixthParagraph);
      GenerateSentence();
    }
   
  
    IEnumerator GrabSeconds()
    {
      yield return new WaitForSeconds(3);
      pScript.grab = true;
    }
    
  
  }
  
}

