using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Refs")]
    public TextMeshProUGUI scoreText;   
    public Rigidbody playerRb;          
    public Transform player;            

    [Header("Pause ()")]
    public GameObject pauseCanvas;      
    private bool paused = false;

    private int score = 0;
    private float scoreTimer = 0f;

    private void Start()
    {
        UpdateScoreUI();
        TryLoadOnStart();               
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();

        scoreTimer += Time.deltaTime;
        if (!paused && scoreTimer >= 0.3f)
        {
            scoreTimer = 0f;

            if (playerRb != null && playerRb.linearVelocity.sqrMagnitude > 0.01f)
            {
                AddScore(1);
            }
        }
    }

    public void TogglePause() => SetPause(!paused);
    public void SetPause(bool on)
    {
        paused = on;
        Time.timeScale = on ? 0 : 1;
        if (pauseCanvas) pauseCanvas.SetActive(on);
    }


    public void AddScore(int delta)
    {
        score += delta;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void SaveAndQuit()
    {
        Vector3 pos = player ? player.position :
                        (playerRb ? playerRb.position : Vector3.zero);

        var d = new SaveData
        {
            px = pos.x,
            py = pos.y,
            pz = pos.z,
            score = score
        };
        SaveSystem.Save(d);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


    private void TryLoadOnStart()
    {
        if (PlayerPrefs.GetInt("DoLoadOnStart", 0) == 1)
        {
            var d = SaveSystem.Load();
            if (d != null) ApplyLoadedData(d);
            PlayerPrefs.SetInt("DoLoadOnStart", 0); 
        }
    }

    public void ApplyLoadedData(SaveData d)
    {
        if (player) player.position = new Vector3(d.px, d.py, d.pz);
        score = d.score;
        UpdateScoreUI();
    }
}


