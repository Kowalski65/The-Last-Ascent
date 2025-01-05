using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    
    void Start()
    {
        
        Button PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();

        
        if (PlayButton != null)
        {
            PlayButton.onClick.AddListener(LoadMainGame);
        }
        else
        {
            Debug.LogError("PlayButton not found in the scene!");
        }
    }

    
    void LoadMainGame()
    {
        
        SceneManager.LoadScene("MainGame");
    }
}
