using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Tooltip("Начальная точка возрождения игрока")]
    public Transform respawnPoint;

    private HealthManager healthManager;

    private void Start()
    {
        // Находим HealthManager в сцене
        healthManager = FindObjectOfType<HealthManager>();

        if (respawnPoint == null)
        {
            GameObject defaultRespawn = new GameObject("DefaultRespawnPoint");
            respawnPoint = defaultRespawn.transform;
            respawnPoint.position = new Vector3(-9, 1, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Отнимаем сердечко перед возрождением
            LoseHealth();
            RespawnPlayer(other.gameObject);
        }
    }

    private void LoseHealth()
    {
        if (healthManager != null)
        {
            healthManager.LoseHealth();
        }
        else
        {
            Debug.LogWarning("HealthManager не найден в сцене!");
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        bool wasEnabled = false;

        if (characterController != null)
        {
            wasEnabled = characterController.enabled;
            characterController.enabled = false;
        }

        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;

        // Сбрасываем скорость (если есть Rigidbody)
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Восстанавливаем состояние CharacterController
        if (characterController != null)
        {
            characterController.enabled = wasEnabled;
        }

        Debug.Log("Игрок возвращен на стартовую точку");
    }
}