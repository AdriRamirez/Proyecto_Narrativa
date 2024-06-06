using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardSelection : MonoBehaviour
{
    public GameObject ElectionScreen;
    public GameObject ElectionScreen_Stone;
    public GameObject ElectionScreen_Run;
    public GameObject ElectionScreen_Food;
    public GameObject ElectionScreen_Spear;
    Transform Election_Spear_child;
    public GameObject DiceScreen;
    Transform continueButton;
    public GameObject numDado;
    public GameObject yourResult;

    public NPCConversation StartDescription;

    [System.Serializable]
    public class StoneOptions
    {
        public NPCConversation Stone_Suc_1;
        public NPCConversation Stone_Fail_1;
        public NPCConversation Stone_Suc_2;
        public NPCConversation Stone_Fail_2;
    }
    public StoneOptions stoneOptions;

    [System.Serializable]
    public class RunOptions
    {
        public NPCConversation Run_Suc_1;
        public NPCConversation Run_Fail_1;
        public NPCConversation Run_Suc_2;
        public NPCConversation Run_Fail_2;
    }
    public RunOptions runOptions;

    [System.Serializable]
    public class SpearOptions
    {
        public NPCConversation Spear_Suc_1;
        public NPCConversation Spear_Fail_1;
        public NPCConversation Spear_Suc_2;
        public NPCConversation Spear_Fail_2;
    }
    public SpearOptions spearOptions;

    [System.Serializable]
    public class FoodOptions
    {
        public NPCConversation Food_Suc_1;
        public NPCConversation Food_Fail_1;
        public NPCConversation Food_Suc_2;
        public NPCConversation Food_Fail_2;
    }
    public FoodOptions foodOptions;


    public GameObject player;
    public GameObject camera;

    [HideInInspector]
    public int yourRoll;

    public RectTransform conversationManager;

    public Transform cameraTarget;

    FirstPersonMovement playerScript;
    FirstPersonLook cameraScript;

    TextMeshProUGUI objectiveDice;

    public bool isCardsTriggered = false;
    bool Continue = true;
    bool isFinalFase = false;

    public FoodEvent foodEvent;

    void Start()
    {

        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();
        
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(false);

        Election_Spear_child = ElectionScreen_Spear.transform.Find("Button3");
        continueButton = DiceScreen.transform.Find("Continue");

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

        if (!isCardsTriggered && !cameraScript.inDialog && !foodEvent.inFoodEvent)
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
            ConversationManager.Instance.StartConversation(StartDescription);
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

    public void DiceScreen_stone()
    {
        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "10";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void DiceScreen_run()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string  objectiveNum = "15";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void DiceScreen_spear()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "5";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void DiceScreen_food()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "8";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void RollDice()
    {
        //FIRST FASE
        if(isCardsTriggered && !isFinalFase)
        {
            yourRoll = Random.Range(1, 20);

            TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();

            tirada.text = yourRoll.ToString();

            //Stone Option
            if (yourRoll >= 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(stoneOptions.Stone_Suc_1);
            }
            else if (yourRoll < 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(stoneOptions.Stone_Fail_1);
            }

            //Run Option
            if (yourRoll >= 15 && objectiveDice.text == "15")
            {
                ConversationManager.Instance.StartConversation(runOptions.Run_Suc_1);
            }
            else if (yourRoll < 15 && objectiveDice.text == "15")
            {
                ConversationManager.Instance.StartConversation(runOptions.Run_Fail_1);
            }

            //Spear Option
            if (yourRoll >= 5 && objectiveDice.text == "5")
            {
                ConversationManager.Instance.StartConversation(spearOptions.Spear_Suc_1);
            }
            else if (yourRoll < 5 && objectiveDice.text == "5")
            {
                ConversationManager.Instance.StartConversation(spearOptions.Spear_Fail_1);
            }

            //Food Option
            if (yourRoll >= 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(foodOptions.Food_Suc_1);
            }
            else if (yourRoll < 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(foodOptions.Food_Fail_1);
            }
        }

        //FINAL FASE    
        if(isCardsTriggered && isFinalFase)
        {
            yourRoll = Random.Range(1, 20);
            TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();
            tirada.text = yourRoll.ToString();

            //Stone Option
            if (yourRoll >= 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(stoneOptions.Stone_Suc_2);
            }
            else if (yourRoll < 10 && objectiveDice.text == "10")
            {
                ConversationManager.Instance.StartConversation(stoneOptions.Stone_Fail_2);
            }

            //Run Option
            if (yourRoll >= 15 && objectiveDice.text == "15")
            {
                ConversationManager.Instance.StartConversation(runOptions.Run_Suc_2);
            }
            else if (yourRoll < 15 && objectiveDice.text == "15")
            {
                ConversationManager.Instance.StartConversation(runOptions.Run_Fail_2);
            }

            //Spear Option
            if (yourRoll >= 5 && objectiveDice.text == "5")
            {
                ConversationManager.Instance.StartConversation(spearOptions.Spear_Suc_2);
            }
            else if (yourRoll < 5 && objectiveDice.text == "5")
            {
                ConversationManager.Instance.StartConversation(spearOptions.Spear_Fail_2);
            }

            //Food Option
            if (yourRoll >= 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(foodOptions.Food_Suc_2);
            }
            else if (yourRoll < 8 && objectiveDice.text == "8")
            {
                ConversationManager.Instance.StartConversation(foodOptions.Food_Fail_2);
            }


        }
    }

    public void EndCards()
    {
        if(foodEvent.inFoodEvent)
        {
            isCardsTriggered = false;
            Continue = true;
            isFinalFase = false;
            conversationManager.anchoredPosition = new Vector2(0, 0);
            ConversationManager.Instance.EndConversation();
            foodEvent.ContinueFood = false;
            foodEvent.inFoodEvent = false;

        }
        else
        {
            isCardsTriggered = false;
            Continue = false;
            isFinalFase = false;
            conversationManager.anchoredPosition = new Vector2(0, 0);
            ConversationManager.Instance.EndConversation();
            foodEvent.ContinueFood = false;
            foodEvent.inFoodEvent = false;
        }

    }


    public void ContinueCards()
    {
        
        ConversationManager.Instance.EndConversation();
        DiceScreen.SetActive(false);
        
        isFinalFase = true;

        //Stone Option
        if (objectiveDice.text == "10")
        {
            ElectionScreen_Stone.SetActive(true);
        }

        //Run Option
        if (objectiveDice.text == "15")
        {
            ElectionScreen_Run.SetActive(true);
        }

        //Food Option
        if (objectiveDice.text == "8")
        {
            ElectionScreen_Food.SetActive(true);
        }

        //Spear Option
        if (objectiveDice.text == "5")
        {
            ElectionScreen_Spear.SetActive(true);
            GameObject button3 = Election_Spear_child.gameObject;
            if (yourRoll < 5)
            {               
                button3.SetActive(true);
            }
            else
            {
                button3.SetActive(false);
            }
        }
  
    }
    public void DiceScreenFinal_stone_op1()
    {
        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "10";
        ElectionScreen.SetActive(false);
        ElectionScreen_Stone.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }
    public void DiceScreenFinal_stone_op2()
    {
        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "10";
        ElectionScreen.SetActive(false);
        ElectionScreen_Stone.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }

    public void DiceScreenFinal_run_op1()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "15";
        ElectionScreen.SetActive(false);
        ElectionScreen_Run.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }

    public void DiceScreenFinal_run_op2()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "15";
        ElectionScreen.SetActive(false);
        ElectionScreen_Run.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }
    public void DiceScreenFinal_spear_op1()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "5";
        ElectionScreen.SetActive(false);
        ElectionScreen_Spear.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }
    public void DiceScreenFinal_spear_op2()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "5";
        ElectionScreen.SetActive(false);
        ElectionScreen_Spear.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }
    public void DiceScreenFinal_spear_op3()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "5";
        ElectionScreen.SetActive(false);
        ElectionScreen_Spear.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }

    public void DiceScreenFinal_food_op1()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "8";
        ElectionScreen.SetActive(false);
        ElectionScreen_Food.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }
    public void DiceScreenFinal_food_op2()
    {

        objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "8";
        ElectionScreen.SetActive(false);
        ElectionScreen_Food.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;

        GameObject continuebutton = continueButton.gameObject;
        continuebutton.SetActive(false);
    }



}
