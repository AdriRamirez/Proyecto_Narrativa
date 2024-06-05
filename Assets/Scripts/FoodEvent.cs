using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodEvent : MonoBehaviour
{

    public GameObject DiceScreen;

    public GameObject numDado;
    public GameObject yourResult;

    public NPCConversation BattleDialogue1;
    public NPCConversation BattleDialogue2;
    public NPCConversation BattleDialogue3;

    public GameObject player;
    public GameObject camera;

    public int yourRoll;

    public RectTransform conversationManager;

    public Transform cameraTarget;

    FirstPersonMovement playerScript;
    FirstPersonLook cameraScript;

    TextMeshProUGUI objectiveDice;

    public CardSelection cardSelection;

    public bool inFoodEvent;
    public bool ContinueFood;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();

        DiceScreen.SetActive(false);
        inFoodEvent = false;
        ContinueFood = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToDiceScreen()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent =true;
        DiceScreen.SetActive(true);

        if (!cameraScript.inDialog)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;

            if (playerScript != null)
            {
                playerScript.speed = 0;
            }
            if (cameraScript != null)
            {
                cameraScript.sensitivity = 0;
                cameraScript.inCards = true;
                camera.transform.LookAt(cameraTarget);

            }

        }

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "2";
       
        objectiveDice.text = objectiveNum;
    }

    public void RollDice()
    {

        if(cardSelection.isCardsTriggered == false)
        {
            yourRoll = Random.Range(1, 20);

            TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();

            tirada.text = yourRoll.ToString();

            if (yourRoll >= 2 && objectiveDice.text == "2")
            {
                ConversationManager.Instance.StartConversation(BattleDialogue2);
            }
            else if (yourRoll < 2 && objectiveDice.text == "2")
            {
                ConversationManager.Instance.StartConversation(BattleDialogue3);
            }
        }
      

    }
}
