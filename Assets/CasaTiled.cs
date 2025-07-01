using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CasaTiled : MonoBehaviour
{
    public Tilemap tilemap;

    // Tiles por nivel
    public TileBase casaNivel1;
    public TileBase casaNivel2;
    public TileBase casaNivel3;

    // Costo base por nivel
    public int costoInicial = 100;

    // Nivel mximo
    private const int nivelMaximo = 3;

    // Datos por celda 
    private int nivelActual = 0;
    private Vector3Int celdaCasa;

    void Start()
    {
        // Por ejemplo, la casa está en (0,0,0)
        celdaCasa = new Vector3Int(0, 0, 0);
        tilemap.SetTile(celdaCasa, null); // Bloqueada al inicio (sin tile)
    }

    public void IntentarMejorarCasa()
    {
        if (nivelActual >= nivelMaximo)
        {
            Debug.Log("Nivel maximo alcanzado");
            return;
        }

        int costo = costoInicial * (int)Mathf.Pow(2, nivelActual);
        if (GameManager.Instance.GastarRecursos(costo))
        {
            nivelActual++;
            ActualizarTile();
            Debug.Log($"Casa mejorada a nivel {nivelActual}");
        }
        else
        {
            Debug.Log("Recursos insuficientes");
        }
    }

    void ActualizarTile()
    {
        switch (nivelActual)
        {
            case 1:
                tilemap.SetTile(celdaCasa, casaNivel1);
                break;
            case 2:
                tilemap.SetTile(celdaCasa, casaNivel2);
                break;
            case 3:
                tilemap.SetTile(celdaCasa, casaNivel3);
                break;
        }
    }
}
