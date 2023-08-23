using System;
using System.Collections;
using System.Collections.Generic;
using Ash.Scripts;
using Ash.Scripts.Dialogue;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _charVelocity;
    private Vector3 _charMove;
    private float _cameraVerticalAngle;

    private Dialogue dlg;
    public bool grab = true;
    private DoorController door;
    
    [Header("Character Settings",order = 1)]
    [Range(0,50)]public float _CharSpeed = 10f;
    [Range(0, 10)] public int interactionDistance;

    [Header("Camera Settings",order = 2)]
    public Camera mainCamera;
    [SerializeField]private Camera _CameraStack;
    public Vector2 _cameraSpeedMuliplier = new Vector2(0, 0);
    [Range(0,90)]public float _CamMaxY = 70f;
    [Range(0,-90)]public float _CamMinY = -70f;
    
    [Header("Gravity Settings",order = 3)]
    public float gravity = -9.71f;
    [Range(0, 100)] public float Gravity_Multiplier; // just changed to 100 because 5* is slow for me, might be refresh rate? i also use Vsync
    public float gizmo;
    private bool groundCheck;
    public GameObject ground;
    public LayerMask groundMask;


    // added a State so we can freeze camera and movement when talking
    public State state;
    
   
    // the states he can be in
    public enum State
    {
        Normal,
        Talking
    }

    private void Awake()
    {
        //starts in the normal state
        state = State.Talking;
        grab = true;
        //Locks Cursor to Window and Disables visibility
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();
        door = GameObject.FindWithTag("Door").GetComponent<DoorController>();
    }


    private void PlayerGrab()
    {
        if (grab && Input.GetKey(KeyCode.E))
        {
            Debug.DrawRay(mainCamera.transform.position,  mainCamera.transform.forward * interactionDistance);
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {
                if (hit.transform.gameObject.CompareTag("Interactable"))
                {
                    //PUT FUNCTION HERE TO ACTIVE TEXT ON SPECIFIC THINGS
                    //THE GAME OBJECT ALSO NEEDS A COLLIDER
                    //THE GAME OBJECT MUST HAVE THE "Interactable" TAG
                    Debug.Log("*Takes a Massive Shit*");
                }

                if (hit.transform.gameObject.CompareTag("Wisp"))
                { 
                    hit.transform.gameObject.GetComponent<Dialogue>().GenerateSentence();
                    grab = false;
                    Debug.Log("hit wisp");
                }

                if (hit.transform.gameObject.CompareTag("Door"))
                {
                    door.OpenDoor();
                }

                
            } 
        }
    }
    
    private void Update()
    {
        /*
         The state machine with the functions 
         Here we should think about adding some sort of camera function that looks at the player when
         in the talking state 
         */
        
        //TODO We can use Cinemachine to do some kind of cinematic camera thing if needs be, or
        // TODO: OR we can just have the main camera focus on the Character the player is talking to?

        switch (state)
        {
            default:

            case State.Normal:
                HandleCameraMovement();
                HandleGroundMovement();
                break;
            case State.Talking:
               
                // add a function to look at wisp
                // also need to make player not move, current bug, is that the player can glide if moving and talking sometimes...
                
                //Charlie
                //You could freeze movement and rotation on the player rigidbody while talking!
                break;
           
        }
        //_charVelocity += Vector3.down * (gravity * Time.deltaTime * Gravity_Multiplier );
        groundCheck = Physics.CheckSphere(ground.transform.position, gizmo, groundMask);

        if (groundCheck && _charVelocity.y < 0f)
        {
            _charVelocity.y = -2f;
        }
        _charVelocity.y += gravity * Time.deltaTime * Gravity_Multiplier;
    
        _characterController.Move(_charVelocity * Time.deltaTime);
    }

    

    void HandleCameraMovement()
    {
       PlayerGrab();
        
       //input from axes
        Vector2 inputAxes = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        //multiplies the input speed
        inputAxes.Scale(_cameraSpeedMuliplier);
        
        transform.Rotate(Vector3.up, inputAxes.x, Space.Self);

        _cameraVerticalAngle -= inputAxes.y;
        
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, _CamMinY, _CamMaxY);

        _CameraStack.transform.localEulerAngles = new Vector3(_cameraVerticalAngle, 0f, 0f);
    }
    private void HandleGroundMovement()
    {
        //input from movement axes
        Vector2 inputAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        //converts Vector2 Co-ords to Vector3 Co-ords  //Ash: Don't forget to .normalized or else diagonal movement will be faster!
        Vector3 inputSpaceMovement = new Vector3(inputAxes.x, 0f, inputAxes.y).normalized * _CharSpeed;

        //uses inputSpaceMovement to transform the player
        Vector3 worldSpaceMovement = transform.TransformVector(inputSpaceMovement);
        
        _charVelocity = worldSpaceMovement;
    }
    
    IEnumerator GrabSeconds()
    {
        yield return new WaitForSeconds(3);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ground.transform.position, gizmo);
    }
}
