using UnityEngine;

public class VerificadorVegetales : MonoBehaviour
{
    public GameObject panelCompletado;
    public float tiempoEspera = 3f;

    private bool puedeVerificar = false;

    void Start()
    {
        if (panelCompletado != null)
            panelCompletado.SetActive(false);

        Invoke("ActivarVerificacion", 0.5f);
    }

    void ActivarVerificacion()
    {
        puedeVerificar = true;
    }

    void Update()
    {
        if (!puedeVerificar) return;

        RecolectableE[] todos = Resources.FindObjectsOfTypeAll<RecolectableE>();
        int activosEnEscena = 0;

        foreach (RecolectableE v in todos)
        {
            if (v.gameObject.activeInHierarchy && 
                v.gameObject.scene == gameObject.scene)
                activosEnEscena++;
        }

        if (activosEnEscena == 0)
        {
            if (panelCompletado != null && !panelCompletado.activeSelf)
            {
                panelCompletado.SetActive(true);
                Invoke("DesactivarPanel", tiempoEspera);
            }
        }
    }

    void DesactivarPanel()
    {
        if (panelCompletado != null)
            panelCompletado.SetActive(false);
    }
}