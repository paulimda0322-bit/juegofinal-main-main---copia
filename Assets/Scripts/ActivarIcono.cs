using UnityEngine;

public class ActivarIcono : MonoBehaviour
{
    public string nombreIcono;

    public void Activar()
    {
        GameObject[] todos = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in todos)
        {
            if (obj.name == nombreIcono)
            {
                obj.SetActive(true);
                break;
            }
        }
    }
}