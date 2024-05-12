using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject leftCardPanel;
    public GameObject rightCardPanel;

    public GameObject player;
    public GameObject camera;

    public Transform cameraTarget;

    public bool isCardsTriggered = false;


    void Start()
    {

        leftCardPanel.SetActive(false);
        rightCardPanel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCards();

        }

    }

    void Update()
    {
        if (isCardsTriggered)
        {
            
            leftCardPanel.SetActive(true);
            rightCardPanel.SetActive(true);

            var playerScript = player.GetComponent<FirstPersonMovement>();
            var cameraScript = camera.GetComponent<FirstPersonLook>();

            if (playerScript != null)
            {
                playerScript.speed = 0;
            }
            if (cameraScript != null)
            {
                cameraScript.sensitivity = 0;
                cameraScript.inDialog = false;

            }
        }

        if(!isCardsTriggered)
        {
            
            leftCardPanel.SetActive(false);
            rightCardPanel.SetActive(false);

            var playerScript = player.GetComponent<FirstPersonMovement>();
            var cameraScript = camera.GetComponent<FirstPersonLook>();
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
    }
}
