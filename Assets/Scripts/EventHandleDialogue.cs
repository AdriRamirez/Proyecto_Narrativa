using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.TextCore.Text;
using static UnityEditor.Profiling.RawFrameDataView;

public class EventHandleDialogue : MonoBehaviour
{
    public NPCConversation Conversation1;
    public NPCConversation Conversation2;
    public NPCConversation Conversation3;
    public KeyCode DialogKey = KeyCode.E;

    public GameObject player;
    public GameObject camera;

    public GameObject hud;
    public GameObject door;


    public Transform cameraTarget;

    FirstPersonMovement playerScript;
    FirstPersonLook cameraScript;

    public bool isDialogTriggered = false;

    bool isDialog1 = false;
    bool isDialog2 = false;
    bool isDialog3 = false;

    public GameObject interactText;

    private void Start()
    {


        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (!isDialogTriggered)
        {
            interactText.SetActive(true);
        }
       

        if (other.gameObject.tag == "Player" && Input.GetKey(DialogKey))
        {
            StartDialog();
            interactText.SetActive(false);

        }

        


    }
    private void Update()
    {

       

        if (!ConversationManager.Instance.IsConversationActive && isDialogTriggered && !cameraScript.inCards)
        {
            isDialogTriggered = false;
            Cursor.lockState = CursorLockMode.Locked;

            if (playerScript != null)
            {
                playerScript.speed = 5;
            }
            if (cameraScript != null)
            {
                cameraScript.sensitivity = 2;
                cameraScript.inDialog = false;
                
            }
        }
    }

    private void StartDialog()
    {
        Cursor.lockState = CursorLockMode.Confined;
        isDialog1 = true;

        //Player movemente restrictions
        if (playerScript != null)
        {
            playerScript.speed = 0;
        }
        if (cameraScript != null)
        {
            cameraScript.sensitivity = 0;
            camera.transform.LookAt(cameraTarget);
            cameraScript.inDialog = true;
        }

        //Dialogue trigger script
        if(!isDialogTriggered && !cameraScript.inCards) 
        {
            if (Conversation1 != null && isDialog1)
            {
                ConversationManager.Instance.StartConversation(Conversation1);
                isDialogTriggered = true;
                
            }

            if (Conversation2 != null && isDialog2)
            {
                ConversationManager.Instance.StartConversation(Conversation2);
                isDialogTriggered = true;
  
            }
            
            if (Conversation3 != null && isDialog3)
            {
                ConversationManager.Instance.StartConversation(Conversation3);
                isDialogTriggered = true;
                
            }
        }
        
    }

    public void TriggerDialogue2()
    {
        door.SetActive(false);
        hud.SetActive(true);
        isDialog2 = true;
    }
    public void TriggerDialogue3()
    {
        
        isDialog3 = true;
    }
}
