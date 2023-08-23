using System;
using System.Collections;
using System.Collections.Generic;
using Ash.Scripts.Dialogue;
using Cinemachine;
using UnityEngine;
using Cinemachine;
public class CameraControl : MonoBehaviour
{
    
    public List<CinemachineVirtualCamera> vcamList = new List<CinemachineVirtualCamera>();
    private GameObject StateDriven;
    public GameObject TargetOne;
    public GameObject TargetFour;
    public GameObject alexo;
    public Dialogue dscript;

    public GameObject colour;
    public GameObject black;
    
    private void Awake()
    {
        
        StateDriven = GameObject.FindGameObjectWithTag("StateDriven");
        foreach (Transform child in StateDriven.transform)
        {
            if (child.gameObject.CompareTag("Virtual Camera"))
            {
                vcamList.Add(child.gameObject.GetComponent<CinemachineVirtualCamera>());
            }
        }
        
    }

    private void Start()
    {
        dscript = GameObject.FindWithTag("Wisp").GetComponent<Dialogue>();
    }

    private void OnEnable()
    {
       
        for (int i = 0; i < vcamList.Count; i++)
        {
            
            CameraSwitcher.Register(vcamList[i]); 
            print(vcamList[i].name);
        }
        CameraSwitcher.SwitchCamera(vcamList[0]);
       
    }

    private void OnDisable()
    {
        for (int i = 0; i < vcamList.Count; i++)
        {
            CameraSwitcher.Unregister(vcamList[i]);
        }
    }
    
    public bool dollyOneGo;
    void DollyOneControl()
    {
        bool dollyB = true;
        
        if (dollyOneGo)
        {
            var dolly = vcamList[1].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 25 * Time.deltaTime / 4;
            
               
            
           
            
            if (dolly.m_PathPosition <= 150)
            {
                vcamList[1].m_LookAt = TargetOne.transform;
            }

            if (dolly.m_PathPosition >= 160)
            {
                alexo.SetActive(true);
                alexo.GetComponent<Animator>().SetBool("Walking", true);
                alexo.SendMessage("moveWisp");
            }
        }
    }

    public GameObject TreePeople;
    public GameObject Wisp1;
    private bool dollyTwoGo;
    void DollyTwoControl()
    {
        if (dollyTwoGo)
        {
            var dolly = vcamList[2].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 25 * Time.deltaTime / 2;
           
            /*if (dolly.m_PathPosition > 220)
            {
                TreePeople.SetActive(true);
                // Wisp1.SetActive(false);
            }*/
        }
    }

    private bool dollyThreeGo;
    void DollyThreeControl()
    {
        if (dollyThreeGo)
        {
            var dolly = vcamList[3].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 25 * Time.deltaTime / 2;
        }
    }

    private bool dollyFourGo;
    void DollyFourControl()
    {
        if (dollyFourGo)
        {
            var dolly = vcamList[4].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 25 * Time.deltaTime / 2;
            
            if (dolly.m_PathPosition > 175)
            {
                dollySixGo = true;
            }
        }
    }

    private bool dollySixGo;
    void DollySixControl()
    {
        
        
        if (dollySixGo)
        {CameraSwitcher.SwitchCamera(vcamList[6]);
            var dolly = vcamList[6].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 25 * Time.deltaTime / 2;
           
            if (dolly.m_PathPosition > 17
                )
            {
                
                dollyFiveGo = true;
            }

            if (dolly.m_PathPosition >= 30)
            {
                TreePeople.SetActive(true);
               // turnOnColour();
               // Wisp1.SetActive(false);
            }
        }
    }
    private bool dollyFiveGo;
    void DollyFiveControl()
    {
       
        if (dollyFiveGo)
        {
            CameraSwitcher.SwitchCamera(vcamList[5]);
            var dolly = vcamList[5].GetCinemachineComponent<CinemachineTrackedDolly>();
            dolly.m_PathPosition += 35 * Time.deltaTime / 2;
           
        }
    }
    void ControlBoard()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            dollyOneGo = true;
            CameraSwitcher.SwitchCamera(vcamList[1]);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            dollyTwoGo = true;
            CameraSwitcher.SwitchCamera(vcamList[2]);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            dollyThreeGo = true;
            CameraSwitcher.SwitchCamera(vcamList[3]);
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            dollyFourGo = true;
            CameraSwitcher.SwitchCamera(vcamList[4]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        DollySixControl();
        DollyFiveControl();
        DollyFourControl();
        DollyThreeControl();
        DollyTwoControl();
        DollyOneControl();
        ControlBoard();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            black.SetActive(true);
        }
    }

    void dolly1()
    {
        dollyOneGo = true;
        CameraSwitcher.SwitchCamera(vcamList[1]);
        
    }

    IEnumerator secondPara()
    {
        dscript.SendMessage("SecondParagraph");
        yield return null;
    }

    void turnOffColour()
    {
        colour.SetActive(false);
    }

    void turnOnColour()
    {
        colour.SetActive(true);
    }
}
