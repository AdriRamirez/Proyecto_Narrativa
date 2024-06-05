using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonParent;
    public float spacing = 100f;


    string item = "patata";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreateButtonForItem(item);
        }

    }
    public void CreateButtonForItem(string itemName)
    {
        // Instanciar el prefab del botón
        GameObject newButton = Instantiate(buttonPrefab, buttonParent);

        // Obtener la posición del último botón creado
        Vector3 lastButtonPosition = buttonParent.GetChild(buttonParent.childCount - 2).transform.position;

        // Ajustar la posición del nuevo botón
        RectTransform newButtonRectTransform = newButton.GetComponent<RectTransform>();
        newButtonRectTransform.position = new Vector3(lastButtonPosition.x, lastButtonPosition.y - newButtonRectTransform.rect.height - spacing, lastButtonPosition.z);


        // Configurar el texto del botón
        newButton.GetComponentInChildren<Text>().text = "patata";
    }
}
