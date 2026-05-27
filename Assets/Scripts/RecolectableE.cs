using UnityEngine;

public class RecolectableE : MonoBehaviour
{
    public string nombreSpriteRecolectado;
    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] todos = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in todos)
            {
                if (obj.name == nombreSpriteRecolectado)
                {
                    obj.SetActive(true);
                    break;
                }
            }

            gameObject.SetActive(false);
        }
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