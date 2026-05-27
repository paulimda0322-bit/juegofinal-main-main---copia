using UnityEngine;

public class InteraccionNPC : MonoBehaviour
{
    public DialogoSecuencia gestorDialogo;
    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
            gestorDialogo.IniciarDialogo();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
            jugadorCerca = true;
    }

    void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
            jugadorCerca = false;
    }
}