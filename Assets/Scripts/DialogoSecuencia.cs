using UnityEngine;

public class DialogoSecuencia : MonoBehaviour
{
    public GameObject primerPanel;
    public GameObject[] panelesSiguientes;
    private int indiceActual = 0;

    void Start()
    {
        if (primerPanel != null)
            primerPanel.SetActive(false);
        foreach (GameObject panel in panelesSiguientes)
            panel.SetActive(false);
    }

    public void IniciarDialogo()
    {
        indiceActual = 0;
        primerPanel.SetActive(true);
    }

    public void SiguienteDialogo()
    {
        if (indiceActual == 0)
            primerPanel.SetActive(false);
        else
            panelesSiguientes[indiceActual - 1].SetActive(false);

        if (indiceActual < panelesSiguientes.Length)
        {
            panelesSiguientes[indiceActual].SetActive(true);
            indiceActual++;
        }
    }
}