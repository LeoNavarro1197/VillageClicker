using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int recursosTotales = 0;
    public List<Casa> casasDisponibles;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        // Test: añadir recursos con tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            recursosTotales += 10;
            Debug.Log("Recursos actuales: " + recursosTotales);
        }
    }

    public bool GastarRecursos(int cantidad)
    {
        if (recursosTotales >= cantidad)
        {
            recursosTotales -= cantidad;
            return true;
        }
        else
        {
            Debug.Log("No tienes suficientes recursos");
            return false;
        }
    }

    public void AñadirRecursos(int cantidad)
    {
        recursosTotales += cantidad;
    }
}
