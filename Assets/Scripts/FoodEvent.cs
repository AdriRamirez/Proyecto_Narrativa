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

    public NPCConversation Lemons_Win;
    public NPCConversation Lemons_Lose;

    public NPCConversation Deer_Win;
    public NPCConversation Deer_Lose;

    public NPCConversation Water_Win;
    public NPCConversation Water_Lose;

    public NPCConversation Persuade_Win;
    public NPCConversation Persuade_Lose;

    public NPCConversation Robar_Win;
    public NPCConversation Robar_Lose;

    public NPCConversation Refuge;


    public bool rolled = false;
  
    public int lemonRoll;
  
    public int deerRoll;
    
    public int waterRoll;
  
    public int stealRoll;

    public int persuadeRoll;

    public int refugioRoll;

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

    //Lemons
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

    //Deer
    public void GoToDiceScreen2()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent = true;
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

        string objectiveNum = "10";

        objectiveDice.text = objectiveNum;
    }

    //Water
    public void GoToDiceScreen3()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent = true;
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

        string objectiveNum = "3";

        objectiveDice.text = objectiveNum;
    }

    //Robar
    public void GoToDiceScreen4()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent = true;
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

        string objectiveNum = "13";

        objectiveDice.text = objectiveNum;
    }

    //Persuadir
    public void GoToDiceScreen5()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent = true;
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

        string objectiveNum = "8";

        objectiveDice.text = objectiveNum;
    }

    public void GoToDiceScreen6()
    {
        conversationManager.anchoredPosition = new Vector2(0, -200);
        inFoodEvent = true;
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

        string objectiveNum = "0";

        objectiveDice.text = objectiveNum;


    }



    public void RollDice()
    {
        lemonRoll = 0;
        deerRoll = 0;
        waterRoll = 0;
        rolled = true;
        if (cardSelection.isCardsTriggered == false)
        {
            yourRoll = Random.Range(1, 20);

            TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();

            tirada.text = yourRoll.ToString();

            if (yourRoll >= 2 && objectiveDice.text == "2")
            {
                ConversationManager.Instance.StartConversation(Lemons_Win);
                lemonRoll = yourRoll;
                
            }
            else if (yourRoll < 2 && objectiveDice.text == "2")
            {
                ConversationManager.Instance.StartConversation(Lemons_Lose);
                lemonRoll = yourRoll;

            }
            else if (yourRoll >= 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(Deer_Win);
                deerRoll = yourRoll;

            }
            else if (yourRoll < 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(Deer_Lose);
                deerRoll = yourRoll;
            }
            else if (yourRoll >= 3 && objectiveDice.text == "3")
            {
                ConversationManager.Instance.StartConversation(Water_Win);
                waterRoll = yourRoll;
            }
            else if (yourRoll < 3 && objectiveDice.text == "3")
            {
                ConversationManager.Instance.StartConversation(Water_Lose);
                waterRoll = yourRoll;
            }
            else if (yourRoll >= 13 && objectiveDice.text == "13")
            {
                ConversationManager.Instance.StartConversation(Robar_Win);
                waterRoll = yourRoll;
            }
            else if (yourRoll < 13 && objectiveDice.text == "13")
            {
                ConversationManager.Instance.StartConversation(Robar_Lose);
                waterRoll = yourRoll;
            }
            else if (yourRoll >= 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(Persuade_Win);
                waterRoll = yourRoll;
            }
            else if (yourRoll < 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(Persuade_Lose);
                waterRoll = yourRoll;
            }
            else if (yourRoll > 0 && objectiveDice.text == "0")
            {
                ConversationManager.Instance.StartConversation(Refuge);
                refugioRoll = yourRoll;
            }

        }
      

    }
}
