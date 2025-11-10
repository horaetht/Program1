using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [Header("Optional UI (Main Menu)")]
    [SerializeField] private GameObject loadButton;  
    [SerializeField] private TMP_Text saveInfoText;  

    void Start()
    {
        
        bool has = SaveSystem.HasSave();
        if (loadButton)   loadButton.SetActive(has);
        if (saveInfoText) saveInfoText.text = has ? $"Last saved: {SaveSystem.Load()?.savedAt}" : "No previous save";
    }

    // Start New
    public void LoadMain()
    {
        PlayerPrefs.SetInt("DoLoadOnStart", 0);  
        SceneManager.LoadScene("Main");
    }

    // Load Previous Game
    public void LoadPrevious()
    {
        if (!SaveSystem.HasSave()) return;        
        PlayerPrefs.SetInt("DoLoadOnStart", 1);   
        SceneManager.LoadScene("Main");
    }

    // Quit
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
