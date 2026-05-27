using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void OnReintentarClick()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            VidaJugador vida = player.GetComponent<VidaJugador>();
            if (vida != null)
                vida.Reintentar();
        }
    }
}