using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public string nombreSpriteRecolectado;

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
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
}