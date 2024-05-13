using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject ElectionScreen;
    public GameObject DiceScreen;

    public GameObject numDado;
    public GameObject yourResult;

    public GameObject player;
    public GameObject camera;

    public Transform cameraTarget;



    public bool isCardsTriggered = false;
    bool Continue = true;


    void Start()
    {

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
        if (!isCardsTriggered)
        {

            ElectionScreen.SetActive(false);
            DiceScreen.SetActive(false);



            var playerScript = player.GetComponent<FirstPersonMovement>();
            var cameraScript = camera.GetComponent<FirstPersonLook>();


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

    void StartCards()
    {
        isCardsTriggered = true;
        if (isCardsTriggered)
        {

            Cursor.lockState = CursorLockMode.Confined;
            ElectionScreen.SetActive(true);
           

            var playerScript = player.GetComponent<FirstPersonMovement>();
            var cameraScript = camera.GetComponent<FirstPersonLook>();

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

    public void GoToDiceScreen()
    {
        TextMeshProUGUI objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string objectiveNum = "10";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void GoToDiceScreen2()
    {

        TextMeshProUGUI objectiveDice = numDado.GetComponent<TextMeshProUGUI>();

        string  objectiveNum = "15";
        ElectionScreen.SetActive(false);
        DiceScreen.SetActive(true);
        objectiveDice.text = objectiveNum;
    }

    public void RollDice()
    {
        int yourRoll = Random.Range(1, 20);

        TextMeshProUGUI tirada = yourResult.GetComponent<TextMeshProUGUI>();

        tirada.text = yourRoll.ToString();
    }

    public void EndCards()
    {
        isCardsTriggered = false;
        Continue = false;
    }



}
