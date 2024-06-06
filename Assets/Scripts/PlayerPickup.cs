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

    public EventHandleDialogue EventHandleDialogue;

    public CardSelection cardsScript;
    public FoodEvent foodEvent;

    public GameObject ContinueButton;
    public GameObject ExitButton;


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
        
        if (!foodEvent.inFoodEvent && !EventHandleDialogue.isDialogTriggered)
        {
            interactText.SetActive(true);
        }
        else 
        {
            interactText.SetActive(false);
        }

        if(other.CompareTag("Bear"))
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
        if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Fruta")
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);
            if (foodEvent.ContinueFood)
            { 
                foodEvent.GoToDiceScreen();
                foodEvent.ContinueFood = false;
            }
            

        }else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Carne")
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen2();
                foodEvent.ContinueFood = false;
            }


        }else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Agua")
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen3();
                foodEvent.ContinueFood = false;
            }


           
        }
        else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Pescado robado") //Robar
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen4();
                foodEvent.ContinueFood = false;
            }

        }
        else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Peces") //Persuadir
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen5();
                foodEvent.ContinueFood = false;
            }



        }
        else if (currentItem != null && Input.GetKey(KeyCode.E) && currentItem.name == "Refugio") 
        {
            ContinueButton.SetActive(false);
            ExitButton.SetActive(false);
            interactText.SetActive(false);

            if (foodEvent.ContinueFood)
            {
                foodEvent.GoToDiceScreen6();
                foodEvent.ContinueFood = false;
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
    
    public void StartPickUp()
    {
        if (foodEvent.lemonRoll > 2 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.lemonRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;

        }
        
        if (foodEvent.deerRoll > 10 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.deerRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;
        }
        
        if (foodEvent.waterRoll > 2 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.waterRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;
        }

        if (foodEvent.stealRoll > 13 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.waterRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;
        }

        if (foodEvent.persuadeRoll > 8 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.waterRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;
        }

        if (foodEvent.refugioRoll > 0 && foodEvent.rolled)
        {
            PickUp();
            foodEvent.waterRoll = 0;
            foodEvent.rolled = false;
            foodEvent.ContinueFood = true;
        }



        ContinueButton.SetActive(true);
        ExitButton.SetActive(true);
    }

    void PickUp()
    {
        if (currentItem != null)
        {
            // Añadir el objeto al inventario
            inventory.AddItem(currentItem);

            // Desactiva el objeto recogido
            if(currentItem.name != "Agua" || currentItem.name != "Peces")
            {
                currentItem.SetActive(false);
            }
            
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
