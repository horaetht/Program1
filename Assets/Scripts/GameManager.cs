using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Refs")]
    public TMP_Text scoreText;   // 拖 Canvas-HUD/ScoreText 進來

    int score = 0;

    void Start() => UpdateScoreUI();

    public void AddScore(int delta)
    {
        score += delta;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = $"Score: {score}";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) AddScore(1); // 按 P +1
    }
}
