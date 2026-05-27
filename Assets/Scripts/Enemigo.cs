using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float fuerzaEmpuje = 10f;

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // Quita una vida
            VidaJugador vida = otro.GetComponent<VidaJugador>();
            if (vida != null)
                vida.PerderVida();

            // Empuja al jugador
            Rigidbody2D rb = otro.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direccion = (otro.transform.position - transform.position).normalized;
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(direccion * fuerzaEmpuje, ForceMode2D.Impulse);
            }
        }
    }
}