using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; 

    
    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }
    }
}
