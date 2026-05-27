using UnityEngine;

public class RespawnControl : MonoBehaviour
{
    [Header("Configuración del Respawn")]
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private string playerTag = "Player"; 

    // Usamos OnTriggerEnter2D porque tu juego es en 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si lo que cayó tiene el Tag "Player"
        if (other.CompareTag(playerTag))
        {
            // Mueve al jugador al punto de spawn
            other.transform.position = spawnPoint.position;

            // Frenamos la velocidad de caída para que no aparezca cayendo a mil por hora
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; // Así se escribe en Unity 6 para 2D
            }
        }
    }
}