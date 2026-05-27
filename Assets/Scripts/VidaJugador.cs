using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public Transform puntoInicio;
    public GameObject panelGameOver;
    public int vidas = 3;

    private bool invencible = false;
    private float tiempoInvencible = 1.5f;

    public void PerderVida()
    {
        if (invencible) return;

        vidas--;
        Debug.Log("Vidas restantes: " + vidas);

        if (vidas == 2)
        {
            corazon3.SetActive(false);
        }
        else if (vidas == 1)
        {
            corazon2.SetActive(false);
        }
        else if (vidas == 0)
        {
            corazon1.SetActive(false);

            if (panelGameOver != null)
            {
                panelGameOver.SetActive(true);
                Debug.Log("Panel activado: " + panelGameOver.activeSelf);
            }
            else
                Debug.LogWarning("PanelGameOver es null!");

            Time.timeScale = 0f;
            return;
        }

        if (vidas > 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;
            transform.position = puntoInicio.position;

            invencible = true;
            Invoke("QuitarInvencibilidad", tiempoInvencible);
        }
    }

    void QuitarInvencibilidad()
    {
        invencible = false;
    }

    public void Reintentar()
    {
        vidas = 3;
        invencible = false;
        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);

        if (panelGameOver != null)
            panelGameOver.SetActive(false);

        Time.timeScale = 1f;

        transform.position = puntoInicio.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        // Reactivar todos los recolectables de esta escena
        Recolectable[] items = Resources.FindObjectsOfTypeAll<Recolectable>();
        foreach (Recolectable item in items)
        {
            if (item.gameObject.scene == gameObject.scene)
                item.gameObject.SetActive(true);
        }
    }
}