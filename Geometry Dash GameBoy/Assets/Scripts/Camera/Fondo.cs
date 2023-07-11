using UnityEngine;

public class Fondo : MonoBehaviour
{
    public Transform playerTransform; // Referencia al transform del jugador

    private void Update()
    {
        // Obtener la posici�n actual del jugador
        Vector3 playerPosition = playerTransform.position;

        // Mantener la misma posici�n en el eje X y Y del jugador
        Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

        // Actualizar la posici�n del fondo para seguir al jugador
        transform.position = newPosition;
    }
}

