using UnityEngine;
using UnityEngine.UI;

public class TemperatureSystem : MonoBehaviour
{
    public GameObject imageNormalTemperature;   
    public GameObject imageHotTemperature;      
    public GameObject imageColdTemperature;     

    public Button adjustTemperatureButton;     

    private float currentTemperature = 100f;     
    private float maxTemperature = 100f;        
    private float minTemperature = 0f;          
    private float temperatureChangeRate = 5f;   
    private float adjustAmount = 20f;           

    private int buttonUses = 0;                 
    private int maxButtonUses = 3;              

    void Start()
    {
        
        UpdateTemperatureImages();

        
        adjustTemperatureButton.onClick.AddListener(AdjustTemperature);
    }

    void Update()
    {
        
        currentTemperature -= temperatureChangeRate * Time.deltaTime;
        currentTemperature = Mathf.Clamp(currentTemperature, minTemperature, maxTemperature);

        UpdateTemperatureImages(); 
    }

    void AdjustTemperature()
    {
        if (buttonUses < maxButtonUses)
        {
            currentTemperature += adjustAmount;
            currentTemperature = Mathf.Clamp(currentTemperature, minTemperature, maxTemperature);
            buttonUses++;

            UpdateTemperatureImages(); 

            if (buttonUses >= maxButtonUses)
            {
                adjustTemperatureButton.interactable = false; 
            }
        }
    }

    void UpdateTemperatureImages()
    {
        
        if (currentTemperature > 70)
        {
           
            imageNormalTemperature.SetActive(false);
            imageHotTemperature.SetActive(true);
            imageColdTemperature.SetActive(false);
        }
        else if (currentTemperature < 30)
        {
            
            imageNormalTemperature.SetActive(false);
            imageHotTemperature.SetActive(false);
            imageColdTemperature.SetActive(true);
        }
        else
        {
            
            imageNormalTemperature.SetActive(true);
            imageHotTemperature.SetActive(false);
            imageColdTemperature.SetActive(false);
        }
    }
}
