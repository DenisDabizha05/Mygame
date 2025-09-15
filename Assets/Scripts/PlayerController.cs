using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Скорость движения
    public float Speed = 5f;
    public float JumpForce = 300f;

    void Update()
    {
        // Движение влево-вправо
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        }
    }
}
