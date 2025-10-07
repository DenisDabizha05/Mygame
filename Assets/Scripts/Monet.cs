using UnityEngine;

public class Monet : MonoBehaviour
{
    public float RotationSpeed = 50f;
    public int coinValue = 1;

    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Находим ScoreDisplay и увеличиваем счет
            ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if (scoreDisplay != null)
            {
                scoreDisplay.AddScore(coinValue);
            }

            Destroy(gameObject);
        }
    }
}