using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject leftCardPanel;
    public GameObject rightCardPanel;

    public GameObject player;
    public GameObject camera;



    void Start()
    {

        leftCardPanel.SetActive(false);
        rightCardPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Mostrar ambos paneles al presionar la tecla F
            leftCardPanel.SetActive(true);
            rightCardPanel.SetActive(true);

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

        if(Input.GetKeyDown(KeyCode.H))
        {
            // Mostrar ambos paneles al presionar la tecla F
            leftCardPanel.SetActive(false);
            rightCardPanel.SetActive(false);

            var playerScript = player.GetComponent<BasicBehaviour>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
            var cameraScript = camera.GetComponent<ThirdPersonOrbitCamBasic>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
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
}
