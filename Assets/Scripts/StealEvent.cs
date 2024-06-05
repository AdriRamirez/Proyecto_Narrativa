using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealEvent : MonoBehaviour
{

    public GameObject DiceScreen;

    public GameObject numDado;
    public GameObject yourResult;

    public GameObject player;
    public GameObject camera;

    public Transform cameraTarget;

    FirstPersonMovement playerScript;
    FirstPersonLook cameraScript;


    public bool isCardsTriggered = false;
    bool Continue = true;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<FirstPersonMovement>();
        cameraScript = camera.GetComponent<FirstPersonLook>();

        DiceScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
