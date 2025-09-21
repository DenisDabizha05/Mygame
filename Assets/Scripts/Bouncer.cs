using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce = 500f; // Используйте значение как в задании (500)

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            // Получаем Rigidbody игрока и применяем силу
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}