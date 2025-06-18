using UnityEngine;
using TMPro; // Make sure you have the TextMeshPro package installed

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Player1Scored()
    {
        player1Score++;
        UpdateScoreUI();
        // Use FindFirstObjectByType instead of FindObjectOfType
        BallController ballController = Object.FindFirstObjectByType<BallController>();
        if (ballController != null)
        {
            ballController.ResetBall();
        }
    }

    public void Player2Scored()
    {
        player2Score++;
        UpdateScoreUI();
        // Use FindFirstObjectByType instead of FindObjectOfType
        BallController ballController = Object.FindFirstObjectByType<BallController>();
        if (ballController != null)
        {
            ballController.ResetBall();
        }
    }

    void UpdateScoreUI()
    {
        if (player1ScoreText != null)
        {
            player1ScoreText.text = player1Score.ToString();
        }
        if (player2ScoreText != null)
        {
            player2ScoreText.text = player2Score.ToString();
        }
    }
}