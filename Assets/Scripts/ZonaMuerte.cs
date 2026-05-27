using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colision detectada: " + col.gameObject.name);
        if (col.gameObject.CompareTag("Player"))
        {
            VidaJugador vida = col.gameObject.GetComponent<VidaJugador>();
            if (vida != null)
                vida.PerderVida();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger detectado: " + col.gameObject.name);
        if (col.CompareTag("Player"))
        {
            VidaJugador vida = col.GetComponent<VidaJugador>();
            if (vida != null)
                vida.PerderVida();
        }
    }
}