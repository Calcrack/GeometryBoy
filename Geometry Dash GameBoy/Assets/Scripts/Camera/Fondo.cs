using UnityEngine;

public class Fondo : MonoBehaviour
{
    public Transform playerTransform; // Referencia al transform del jugador

    private void Update()
    {
        // Obtener la posición actual del jugador
        Vector3 playerPosition = playerTransform.position;

        // Mantener la misma posición en el eje X y Y del jugador
        Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

        // Actualizar la posición del fondo para seguir al jugador
        transform.position = newPosition;
    }
}

