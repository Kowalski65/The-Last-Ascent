using UnityEngine;
using UnityEngine.UI;

public class HungerSystem : MonoBehaviour
{
    public GameObject imageFullHunger;   
    public GameObject imageMediumHunger; 
    public GameObject imageLowHunger;    

    public Button eatButton;             

    private float currentHunger = 100f;  
    private float maxHunger = 100f;      
    private float hungerDrainRate = 3f;  
    private float hungerRestoreAmount = 50f; 

    private int eatButtonUses = 0;       
    private int maxButtonUses = 2;       

    void Start()
    {
        
        UpdateHungerImages();

        
        eatButton.onClick.AddListener(RestoreHunger);
    }

    void Update()
    {
        
        if (currentHunger > 0)
        {
            currentHunger -= hungerDrainRate * Time.deltaTime;
            currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger); 
            UpdateHungerImages(); 
        }
    }

    void RestoreHunger()
    {
        if (eatButtonUses < maxButtonUses)
        {
            currentHunger += hungerRestoreAmount;
            currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger); 
            eatButtonUses++;

            UpdateHungerImages(); 

            if (eatButtonUses >= maxButtonUses)
            {
                eatButton.interactable = false; 
            }
        }
    }

    void UpdateHungerImages()
    {
        
        if (currentHunger > 50)
        {
            imageFullHunger.SetActive(true);
            imageMediumHunger.SetActive(false);
            imageLowHunger.SetActive(false);
        }
        else if (currentHunger > 20)
        {
            imageFullHunger.SetActive(false);
            imageMediumHunger.SetActive(true);
            imageLowHunger.SetActive(false);
        }
        else
        {
            imageFullHunger.SetActive(false);
            imageMediumHunger.SetActive(false);
            imageLowHunger.SetActive(true);
        }
    }
}
