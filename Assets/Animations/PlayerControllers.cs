using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Движение влево-вправо (исправлено)
        float horizontal = Input.GetAxis("Horizontal");

        // Удаляем минус перед horizontal - теперь движение будет прямым:
        // positive horizontal (вправо) → движение вправо
        // negative horizontal (влево) → движение влево
        Vector3 movement = new Vector3(horizontal, 0, 0) * Speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Поворот персонажа (исправлено)
        if (horizontal > 0.1f) // Добавляем небольшой порог для избежания дрожания
            transform.rotation = Quaternion.LookRotation(Vector3.right); // Смотрим вправо
        else if (horizontal < -0.1f)
            transform.rotation = Quaternion.LookRotation(Vector3.left); // Смотрим влево

        // Передаём скорость в Animator
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce);
            animator.SetTrigger("Jump");
        }

        // Анимация смерти по O
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("Dash");
        }

        // Анимация танца по I
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("Dancing");
        }
    }
}