using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce = 500f; // ����������� �������� ��� � ������� (500)

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            // �������� Rigidbody ������ � ��������� ����
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}