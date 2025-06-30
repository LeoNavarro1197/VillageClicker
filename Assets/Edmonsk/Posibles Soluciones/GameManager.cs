using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int recursosTotales = 0;

    public int RecursosTotales => recursosTotales;

    public List<Casa> casasDisponibles = new List<Casa>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene GameManager entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Busca todas las casas en la escena al iniciar
        casasDisponibles = new List<Casa>(FindObjectsOfType<Casa>());
    }

    void Update()
    {
        // Test rápido: añadir recursos presionando R
        if (Input.GetKeyDown(KeyCode.R))
        {
            AñadirRecursos(10);
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
