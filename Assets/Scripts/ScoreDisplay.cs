using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int CurrentScore = 0;

    void Start()
    {
        // �������������� ����� ��� ������
        UpdateScoreText();
    }

    // ����� ��� ���������� �����
    public void AddScore(int points)
    {
        CurrentScore += points;
        UpdateScoreText();
    }

    // ����� ��� ���������� ������
    private void UpdateScoreText()
    {
        ScoreText.text = "������: " + CurrentScore;
    }
}
