using UnityEngine;

public class Monet : MonoBehaviour
{
    public float RotationSpeed = 50f;
    public int coinValue = 1;

    [Header("Particle Effects")]
    public ParticleSystem shineParticles; // ���������� �����
    public ParticleSystem collectParticles; // ������ �����

    void Start()
    {
        // ��������� ������ ������ ��� �������� ������
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
            // ��������� ����
            ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if (scoreDisplay != null)
            {
                scoreDisplay.AddScore(coinValue);
            }

            // ���������� ������ �����
            if (collectParticles != null)
            {
                // ��������� ���������� ����� ������, �� ��������� �������
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                // ��������� �����
                if (shineParticles != null)
                    shineParticles.Stop();

                // ��������� ������ �����
                collectParticles.Play();

                // ���������� ������ ����� ���������� �������
                Destroy(gameObject, collectParticles.main.duration);
            }
            else
            {
                // ���� ������� ���, ������ ����������
                Destroy(gameObject);
            }
        }
    }
}