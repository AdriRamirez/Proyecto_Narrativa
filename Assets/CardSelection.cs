using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject leftCardPanel;
    public GameObject rightCardPanel;
    public Color selectedColor;
    public Color defaultColor;

    public GameObject player;

    private bool leftSelected = false;
    private bool rightSelected = false;

    void Start()
    {
        // Establecer colores predeterminados
        leftCardPanel.GetComponent<Image>().color = defaultColor;
        rightCardPanel.GetComponent<Image>().color = defaultColor;

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

            var otherScript = player.GetComponent<BasicBehaviour>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
            if (otherScript != null)
            {
                otherScript.enabled = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            // Mostrar ambos paneles al presionar la tecla F
            leftCardPanel.SetActive(false);
            rightCardPanel.SetActive(false);

            var otherScript = player.GetComponent<BasicBehaviour>(); // Reemplaza "OtherScript" con el nombre real del script que deseas desactivar
            if (otherScript != null)
            {
                otherScript.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Seleccionar el panel izquierdo y cambiar su color
            leftSelected = true;
            rightSelected = false;
            leftCardPanel.GetComponent<Image>().color = selectedColor;
            rightCardPanel.GetComponent<Image>().color = defaultColor;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Seleccionar el panel derecho y cambiar su color
            leftSelected = false;
            rightSelected = true;
            rightCardPanel.GetComponent<Image>().color = selectedColor;
            leftCardPanel.GetComponent<Image>().color = defaultColor;
        }
    }
}
