using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Refs")]
    public TextMeshProUGUI scoreText;  // 拖 Canvas-HUD/ScoreText (TMP) 進來
    public Rigidbody playerRb;         // 拖 Player 的 Rigidbody 進來

    private int score = 0;
    private float scoreTimer = 0f;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void Update()
    {
        scoreTimer += Time.deltaTime;

        // 每 0.3 秒檢查一次是否在移動
        if (scoreTimer >= 0.3f)
        {
            scoreTimer = 0f;

            if (playerRb != null && playerRb.linearVelocity.sqrMagnitude > 0.01f)
            {
                AddScore(1);
            }
        }
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
}

