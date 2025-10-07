using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    // Ссылки на GameObject сердечек (сами объекты Heart1, Heart2, Heart3)
    public GameObject[] heartObjects;

    void Start()
    {
        currentHealth = maxHealth;

        // Автоматически находим все сердечки если не назначены
        if (heartObjects == null || heartObjects.Length == 0)
        {
            heartObjects = new GameObject[maxHealth];
            for (int i = 0; i < maxHealth; i++)
            {
                string heartName = "Heart" + (i + 1);
                heartObjects[i] = GameObject.Find(heartName);
            }
        }

        UpdateHearts();
    }

    public void LoseHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();

            // Проверяем смерть игрока
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    public void AddHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHearts();
        }
    }

    void UpdateHearts()
    {
        // Просто включаем/выключаем GameObject сердечек
        for (int i = 0; i < heartObjects.Length; i++)
        {
            if (heartObjects[i] != null)
            {
                heartObjects[i].SetActive(i < currentHealth);
            }
        }

        Debug.Log("Осталось жизней: " + currentHealth);
    }

    void GameOver()
    {
        Debug.Log("Игра окончена! У вас закончились жизни");
        // Здесь можно добавить перезагрузку уровня или экран Game Over
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}