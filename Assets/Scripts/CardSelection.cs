using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardSelection : MonoBehaviour
{
    public GameObject ElectionScreen;
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

    public Inventory inventory;

    public bool isCardsTriggered = false;
    bool Continue = true;


    void Start()
    {

        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();
        
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(false);

        

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("patata");
        if (other.gameObject.tag == "Player" && Continue == true)
        {
            Continue = false;
            StartCards();
            
        }

    }

    void Update()
    {

        if (!isCardsTriggered && !cameraScript.inDialog)
        {

            ElectionScreen.SetActive(false);
            DiceScreen.SetActive(false);


            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            if (playerScript != null)
            {
                playerScript.speed = 5;
            }
            if (cameraScript != null)
            {
                cameraScript.sensitivity = 2;
                cameraScript.inCards = false;

            }
        }


    }

    void StartCards()
    {
        conversationManager.anchoredPosition = new Vector2 (0, -200);

        isCardsTriggered = true;
        
        if (isCardsTriggered && !cameraScript.inDialog)
        {
            ConversationManager.Instance.StartConversation(BattleDialogue1);
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            ElectionScreen.SetActive(true);
           

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

        
    }

    public void GoToDiceScreen()
    {
        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "10";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void GoToDiceScreen2()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string  objectiveNum = "15";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void RollDice()
    {
        yourRoll = Random.Range(1, 20);

        TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();

        tirada.text = yourRoll.ToString();

        if(yourRoll >= 10 && objectiveDice.text == "10")
        {
            ConversationManager.Instance.StartConversation(BattleDialogue2);
        }
        else if (yourRoll < 10 && objectiveDice.text == "10")
        {
            ConversationManager.Instance.StartConversation(BattleDialogue3);
        }

    }

    public void EndCards()
    {
        isCardsTriggered = false;
        Continue = false;

        conversationManager.anchoredPosition = new Vector2(0, 0);
        ConversationManager.Instance.EndConversation();
    }



}
