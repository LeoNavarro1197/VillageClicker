using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estatua : MonoBehaviour
{
    public Items items;
    [SerializeField] private GameObject estatuaDesbloqueada;

    public void DesbloquearEstatua()
    {
        if (items.woodScore >= 10000 && items.rockScore >= 10000)
        {
            estatuaDesbloqueada.SetActive(true);
            items.woodScore = items.woodScore - 10000;
            items.rockScore = items.rockScore - 10000;
            items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
        }
    }
}
