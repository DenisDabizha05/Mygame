using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int CurrentScore = 0;

    void Start()
    {
        // Инициализируем текст при старте
        UpdateScoreText();
    }

    // Метод для добавления очков
    public void AddScore(int points)
    {
        CurrentScore += points;
        UpdateScoreText();
    }

    // Метод для обновления текста
    private void UpdateScoreText()
    {
        ScoreText.text = "Монеты: " + CurrentScore;
    }
}
