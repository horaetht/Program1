using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;   

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;            

    [Header("Audio (optional)")]
    public AudioMixer masterMixer;      

    bool paused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        paused = !paused;
        panel.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;

        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible   = paused;
    }

    public void OnResume()  => TogglePause();

    public void OnRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()    
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Splash");
    }

    public void OnVolumeChanged(float v)
    {
        if (masterMixer != null)
        {
            float dB = Mathf.Lerp(-80f, 0f, v);
            masterMixer.SetFloat("MasterVolume", dB);
        }
        else
        {
            AudioListener.volume = v;   
        }
    }
}