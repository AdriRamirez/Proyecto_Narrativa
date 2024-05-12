using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EventHandleDialogue : MonoBehaviour
{
    public NPCConversation Conversation;
    public KeyCode DialogKey = KeyCode.E;

    public GameObject player;
    public GameObject camera;

    public bool isDialogTriggered = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(DialogKey))
        {
            StartDialog();

        }

    }
    private void Update()
    {
        var playerScript = player.GetComponent<BasicBehaviour>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
        var cameraScript = camera.GetComponent<ThirdPersonOrbitCamBasic>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar

        if (!ConversationManager.Instance.IsConversationActive && isDialogTriggered)
        {
            isDialogTriggered = false;

            if (playerScript != null)
            {
                playerScript.enabled = true;
            }
            if (cameraScript != null)
            {
                cameraScript.enabled = true;
            }
        }
    }

    private void StartDialog()
    {
        if(Conversation != null && !isDialogTriggered)
        {
            ConversationManager.Instance.StartConversation(Conversation);
            isDialogTriggered = true;

            var playerScript = player.GetComponent<BasicBehaviour>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
            var cameraScript = camera.GetComponent<ThirdPersonOrbitCamBasic>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar

            if (playerScript != null)
            {
                playerScript.enabled = false;
            }
            if (cameraScript != null)
            {
                cameraScript.enabled = false;
            }

        }
    
    }
}
