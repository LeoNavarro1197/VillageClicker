using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int costoInicial = 50;
    public int nivel = 0;
    public int nivelMaximo = 3;
    private bool desbloqueada = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        ActualizarColor();
    }

    public void IntentarComprarOMejorar()
    {
        if (nivel >= nivelMaximo)
        {
            Debug.Log("La casa ya está al nivel maximo");
            return;
        }

        int costoActual = costoInicial * (int)Mathf.Pow(2, nivel); // costo escala 50, 100, 200...

        if (GameManager.Instance.GastarRecursos(costoActual))
        {
            nivel++;
            desbloqueada = true;
            Debug.Log("Casa nivel " + nivel + " comprada/mejorada");
            ActualizarColor();
        }
    }
    void OnMouseDown()
    {
        IntentarComprarOMejorar();
    } 

    private void ActualizarColor()
    {
        if (rend == null) return;

        if (!desbloqueada)
            rend.material.color = Color.gray;
        else if (nivel == 1)
            rend.material.color = Color.white;
        else if (nivel == 2)
            rend.material.color = Color.green;
        else if (nivel == 3)
            rend.material.color = Color.cyan;
    }
}
