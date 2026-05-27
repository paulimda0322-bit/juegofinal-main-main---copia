using UnityEngine;

public class MensajeInicio : MonoBehaviour
{
    public GameObject panelMensaje;

    void Start()
    {
        panelMensaje.SetActive(true); // Se activa al iniciar
        Time.timeScale = 0f; // Pausa el juego
    }

    public void CerrarMensaje()
    {
        panelMensaje.SetActive(false); // Se desactiva al presionar el botón
        Time.timeScale = 1f; // Reanuda el juego
    }
}