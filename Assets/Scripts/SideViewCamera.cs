using UnityEngine;

public class SideViewCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(5f, 1f, 0f);

    void Update()
    {
        if (player != null)
        {
            // Позиция камеры = позиция игрока + смещение
            transform.position = player.position + offset;

            // Камера всегда смотрит на игрока
            transform.LookAt(player);
        }
    }
}
