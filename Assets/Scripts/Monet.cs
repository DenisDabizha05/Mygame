using UnityEngine;

public class Monet : MonoBehaviour
{
    public float RotationSpeed = 50f;
    public int coinValue = 1;

    [Header("Particle Effects")]
    public ParticleSystem shineParticles; // Постоянный блеск
    public ParticleSystem collectParticles; // Эффект сбора

    void Start()
    {
        // Запускаем эффект блеска при создании монеты
        if (shineParticles != null)
        {
            shineParticles.Play();
        }
    }

    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Добавляем очки
            ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if (scoreDisplay != null)
            {
                scoreDisplay.AddScore(coinValue);
            }

            // Активируем эффект сбора
            if (collectParticles != null)
            {
                // Отключаем визуальную часть монеты, но оставляем частицы
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                // Отключаем блеск
                if (shineParticles != null)
                    shineParticles.Stop();

                // Запускаем эффект сбора
                collectParticles.Play();

                // Уничтожаем объект после завершения эффекта
                Destroy(gameObject, collectParticles.main.duration);
            }
            else
            {
                // Если эффекта нет, просто уничтожаем
                Destroy(gameObject);
            }
        }
    }
}