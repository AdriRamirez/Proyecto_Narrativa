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
        // Instanciar el prefab del bot�n
        GameObject newButton = Instantiate(buttonPrefab, buttonParent);

        // Obtener la posici�n del �ltimo bot�n creado
        Vector3 lastButtonPosition = buttonParent.GetChild(buttonParent.childCount - 2).transform.position;

        // Ajustar la posici�n del nuevo bot�n
        RectTransform newButtonRectTransform = newButton.GetComponent<RectTransform>();
        newButtonRectTransform.position = new Vector3(lastButtonPosition.x, lastButtonPosition.y - newButtonRectTransform.rect.height - spacing, lastButtonPosition.z);


        // Configurar el texto del bot�n
        newButton.GetComponentInChildren<Text>().text = "patata";
    }
}
