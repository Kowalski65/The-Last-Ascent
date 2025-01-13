using UnityEngine;
using UnityEngine.UI;

public class ThirstSystem : MonoBehaviour
{
    public GameObject imageFullThirst;   
    public GameObject imageMediumThirst; 
    public GameObject imageLowThirst;    

    public Button drinkButton;           

    private float currentThirst = 100f;  
    private float maxThirst = 100f;      
    private float thirstDrainRate = 5f;  
    private float thirstRestoreAmount = 50f; 

    private int drinkButtonUses = 0;     
    private int maxButtonUses = 2;       

    void Start()
    {
        
        UpdateThirstImages();

       
        drinkButton.onClick.AddListener(RestoreThirst);
    }

    void Update()
    {
        
        if (currentThirst > 0)
        {
            currentThirst -= thirstDrainRate * Time.deltaTime;
            currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst); 
            UpdateThirstImages(); 
        }
    }

    void RestoreThirst()
    {
        if (drinkButtonUses < maxButtonUses)
        {
            currentThirst += thirstRestoreAmount;
            currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst); 
            drinkButtonUses++;

            UpdateThirstImages(); 

            if (drinkButtonUses >= maxButtonUses)
            {
                drinkButton.interactable = false;
            }
        }
    }

    void UpdateThirstImages()
    {
        
        if (currentThirst > 50)
        {
            imageFullThirst.SetActive(true);
            imageMediumThirst.SetActive(false);
            imageLowThirst.SetActive(false);
        }
        else if (currentThirst > 20)
        {
            imageFullThirst.SetActive(false);
            imageMediumThirst.SetActive(true);
            imageLowThirst.SetActive(false);
        }
        else
        {
            imageFullThirst.SetActive(false);
            imageMediumThirst.SetActive(false);
            imageLowThirst.SetActive(true);
        }
    }
}
