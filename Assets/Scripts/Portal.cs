using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool huesoRecolectado = false;
    private bool libroRecolectado = false;
    private bool celularRecolectado = false;

    void Update()
    {
        // Busca incluso objetos desactivados
        Recolectable[] items = Resources.FindObjectsOfTypeAll<Recolectable>();
        
        huesoRecolectado = false;
        libroRecolectado = false;
        celularRecolectado = false;

        foreach (Recolectable item in items)
        {
            if (item.gameObject.scene != gameObject.scene) continue;

            if (item.gameObject.name == "Hueso" && !item.gameObject.activeSelf)
                huesoRecolectado = true;
            if (item.gameObject.name == "Libro" && !item.gameObject.activeSelf)
                libroRecolectado = true;
            if (item.gameObject.name == "Celular" && !item.gameObject.activeSelf)
                celularRecolectado = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (huesoRecolectado && libroRecolectado && celularRecolectado)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Nivel5");
            }
            else
            {
                Debug.Log("Faltan objetos por recolectar");
            }
        }
    }
}