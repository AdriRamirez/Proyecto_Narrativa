using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 3f; // Rango en el que el jugador puede recoger el objeto
    private GameObject currentItem; // Referencia al objeto que se puede recoger
    private Inventory inventory; // Referencia al inventario del jugador

    public GameObject inventoryPanel; // Panel de inventario
    public TextMeshProUGUI inventoryText; // Texto del inventario

    public GameObject interactText; // Texto del inventario

    public GameObject objectivePanel; // Panel de objetivos

    public CardSelection cardsScript;
    public FoodEvent foodEvent;

    void Start()
    {
        interactText.SetActive(false);

        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogError("No Inventory component found on the player.");
        }

        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        

        // Mostrar/ocultar inventario al presionar "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(!foodEvent.inFoodEvent)
        {
            interactText.SetActive(true);
        }
        else
        {
            interactText.SetActive(false);
        }
        
        // Verifica si el objeto tiene la etiqueta "Collectible" y está dentro del rango de recogida
        if (other.CompareTag("Cogible") && Vector3.Distance(transform.position, other.transform.position) <= pickupRange)
        {
            currentItem = other.gameObject;
            // Mostrar un mensaje en la pantalla o un indicador para el jugador aquí
        }

        // Si el jugador está en rango de un objeto y presiona "E"
        if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Lemons")
        {
           
            if (foodEvent.ContinueFood)
            { 
                foodEvent.GoToDiceScreen();
                foodEvent.ContinueFood = false;
            }
            

            if (foodEvent.yourRoll > 2)
            {
                PickUp();
            }
            

        }else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Deer")
        {

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen();
                foodEvent.ContinueFood = false;
            }


            if (foodEvent.yourRoll > 2)
            {
                PickUp();
            }


        }
    }

    void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);

        // Cuando el jugador sale del rango del objeto recogible
        if (other.CompareTag("Cogible"))
        {
            currentItem = null;
            // Ocultar el mensaje en la pantalla o el indicador para el jugador aquí
        }

      
    }

    void PickUp()
    {
        if (currentItem != null)
        {
            // Añadir el objeto al inventario
            inventory.AddItem(currentItem);

            // Desactiva el objeto recogido
            currentItem.SetActive(false);

            // Elimina el texto del objetivo correspondiente
            UpdateObjectiveUI(currentItem.name);

            currentItem = null; // Resetea la referencia al objeto recogido


        }
    }

    void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);

            if (!isActive)
            {
                // Actualiza el texto del inventario
                inventoryText.text = inventory.GetInventoryText();
            }
        }
    }

    void UpdateObjectiveUI(string itemName)
    {
        if (objectivePanel != null)
        {
            foreach (Transform child in objectivePanel.transform)
            {
                TextMeshProUGUI objectiveText = child.GetComponent<TextMeshProUGUI>();
                if (objectiveText != null && objectiveText.text.Contains(itemName))
                {
                    objectiveText.text = ""; // Eliminar el texto del objetivo correspondiente
                }
            }
        }
    }
}
