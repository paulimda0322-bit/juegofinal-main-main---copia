using UnityEngine;

public class InventarioUI : MonoBehaviour
{
    public GameObject panelInventarioVisual;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        panelInventarioVisual.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panelInventarioVisual.SetActive(!panelInventarioVisual.activeSelf);
        }
    }
}