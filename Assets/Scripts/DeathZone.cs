using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Tooltip("Начальная точка возрождения игрока. Если не назначена, будет использоваться позиция (0,0,0)")]
    public Transform respawnPoint;

    private void Start()
    {
       
        if (respawnPoint == null)
        {
            GameObject defaultRespawn = new GameObject("DefaultRespawnPoint");
            respawnPoint = defaultRespawn.transform;
            respawnPoint.position = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.gameObject);
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

        
        player.transform.position = new Vector3(-9, 1, 1);
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