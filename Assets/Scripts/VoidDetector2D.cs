using UnityEngine;

public class VoidDetector2D : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teletransporta
            if (other.TryGetComponent<Playermovement>(out Playermovement playerMovement))
            {
                playerMovement.TeletransportarA(spawnPoint.position);
            }
            else
            {
                other.transform.position = spawnPoint.position;
            }

            // Quita vida
            VidaJugador vida = other.GetComponent<VidaJugador>();
            if (vida != null)
            {
                Debug.Log("Llamando PerderVida");
                vida.PerderVida();
            }
            else
            {
                Debug.LogWarning("VidaJugador no encontrado en el Personaje");
            }
        }
    }
}