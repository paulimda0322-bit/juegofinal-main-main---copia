using UnityEngine;

public class AbrirInventario : MonoBehaviour
{
    private GameObject panel;

    void Start()
    {
        // Busca el panel incluso si está desactivado
        GameObject[] todos = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in todos)
        {
            if (obj.name == "PanelInventario")
            {
                panel = obj;
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}