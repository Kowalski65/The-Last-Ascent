using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{
    public GameObject imageFullEnergy;   
    public GameObject imageMediumEnergy; 
    public GameObject imageLowEnergy;    

    public Button restoreButton;         

    private float currentEnergy = 100f; 
    private float maxEnergy = 100f;      
    private float energyDrainRate = 5f;  
    private float energyRestoreAmount = 50f; 

    private int restoreButtonUses = 0;   
    private int maxButtonUses = 2;      

    void Start()
    {
        
        UpdateEnergyImages();

        restoreButton.onClick.AddListener(RestoreEnergy);
    }

    void Update()
    {
     
        if (currentEnergy > 0)
        {
            currentEnergy -= energyDrainRate * Time.deltaTime;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy); 
            UpdateEnergyImages();
        }
    }

    void RestoreEnergy()
    {
        if (restoreButtonUses < maxButtonUses)
        {
            currentEnergy += energyRestoreAmount;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy); 
            restoreButtonUses++;

            UpdateEnergyImages(); 

            if (restoreButtonUses >= maxButtonUses)
            {
                restoreButton.interactable = false; 
            }
        }
    }

    void UpdateEnergyImages()
    {
        
        if (currentEnergy > 50)
        {
            imageFullEnergy.SetActive(true);
            imageMediumEnergy.SetActive(false);
            imageLowEnergy.SetActive(false);
        }
        else if (currentEnergy > 20)
        {
            imageFullEnergy.SetActive(false);
            imageMediumEnergy.SetActive(true);
            imageLowEnergy.SetActive(false);
        }
        else
        {
            imageFullEnergy.SetActive(false);
            imageMediumEnergy.SetActive(false);
            imageLowEnergy.SetActive(true);
        }
    }
}