using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    
    void Start()
    {
        
        Button ExitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        
        if (ExitButton != null)
        {
            ExitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("ExitButton not found in the scene!");
        }
    }

    
    void QuitGame()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If we're in a built game, quit the application
            Application.Quit();
#endif
    }
}
