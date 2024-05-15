using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.TextCore.Text;

public class EventHandleDialogue : MonoBehaviour
{
    public NPCConversation Conversation;
    public KeyCode DialogKey = KeyCode.E;

    public GameObject player;
    public GameObject camera;
    

    public Transform cameraTarget;

    FirstPersonMovement playerScript;
    FirstPersonLook cameraScript;

    public bool isDialogTriggered = false;

    private void Start()
    {
        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(DialogKey))
        {
            StartDialog();

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
        if(Conversation != null && !isDialogTriggered && !cameraScript.inCards)
        {
            ConversationManager.Instance.StartConversation(Conversation);
            isDialogTriggered = true;

            Cursor.lockState = CursorLockMode.Confined;

            if (playerScript != null)
            {
                playerScript.speed = 0;
            }
            if (cameraScript != null)
            {
                cameraScript.sensitivity = 0;
                cameraScript.inDialog = true;
                camera.transform.LookAt(cameraTarget);
                

            }

        }
    
    }
}
