using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHouse : MonoBehaviour
{
    public Items items;
    ManagerPrices managerPrices;
    [SerializeField] private GameObject nivel1, nivel2, nivel3;
    [SerializeField] private BoxCollider2D espacioCasaBoxCollider;
    [SerializeField] private SpriteRenderer espacioCasaSpriteRenderer;

    private void OnMouseDown()
    {
        /* COMPRAR CASAS DE ASERRADORES*/

        if(gameObject.tag == "CasaAserradero")
        {
            if (items.woodScore >= managerPrices.houseAserraderoLevel1Price && espacioCasaSpriteRenderer.enabled == true)
            {
                espacioCasaSpriteRenderer.enabled = false;
                nivel1.SetActive(true);
                items.woodScore = items.woodScore - managerPrices.houseAserraderoLevel1Price;
                items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            }

            if (items.woodScore >= managerPrices.houseAserraderoLevel2Price && nivel2.active == false)
            {
                nivel2.SetActive(true);
                items.woodScore = items.woodScore - managerPrices.houseAserraderoLevel2Price;
                items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            }

            if (items.woodScore >= managerPrices.houseAserraderoLevel3Price && nivel3.active == false)
            {
                nivel3.SetActive(true);
                items.woodScore = items.woodScore - managerPrices.houseAserraderoLevel3Price;
                items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            }
        }

        /* COMPRAR CASAS DE MINEROS*/

        if (gameObject.tag == "CasaHerrero")
        {
            if (items.rockScore >= managerPrices.houseMineroLevel1Price && espacioCasaSpriteRenderer.enabled == true)
            {
                espacioCasaSpriteRenderer.enabled = false;
                nivel1.SetActive(true);
                items.rockScore = items.rockScore - managerPrices.houseMineroLevel1Price;
                items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            }

            if (items.rockScore >= managerPrices.houseMineroLevel2Price && nivel2.active == false)
            {
                nivel2.SetActive(true);
                items.rockScore = items.rockScore - managerPrices.houseMineroLevel2Price;
                items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            }

            if (items.rockScore >= managerPrices.houseMineroLevel3Price && nivel3.active == false)
            {
                nivel3.SetActive(true);
                items.rockScore = items.rockScore - managerPrices.houseMineroLevel3Price;
                items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            }
        }       
    }
}