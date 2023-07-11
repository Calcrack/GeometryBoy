using UnityEngine;

public class Float : MonoBehaviour
{
    public float floatHeight = 0.1f; // Altura de flotado
    public float floatSpeed = 1.0f; // Velocidad de flotado
    private Vector3 originalPosition; // Posición original del objeto

    void Start()
    {
        // Almacenar la posición original del objeto
        originalPosition = transform.position;
    }

    void Update()
    {
        // Utilizar la función Mathf.Sin para generar una oscilación en el eje y
        float yPos = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(originalPosition.x, yPos, originalPosition.z);
    }
}

