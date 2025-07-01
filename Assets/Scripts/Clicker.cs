using System.Collections;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public Items items;
    private SpriteRenderer spriteRenderer;

    public bool isClickedTree = false, isClickedRock = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateScore();
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Arbol")
        {
            items.woodScore++;
            spriteRenderer.color = Color.gray;
            isClickedTree = true;
            UpdateScore();
        }

        if(gameObject.tag == "Piedra")
        {
            items.rockScore++;
            spriteRenderer.color = Color.gray;
            isClickedRock = true;
            UpdateScore();
        }
    }

    private void OnMouseUp()
    {
        if (gameObject.tag == "Arbol")
        {
            spriteRenderer.color = Color.green;
        }

        if (gameObject.tag == "Piedra")
        {
            spriteRenderer.color = Color.blue;
        }
    }

    public void UpdateScore()
    {
        if (isClickedTree)
        {
            if (items.woodScoreText != null)
            {
                items.woodScoreText.text = items.itemWoodName + ": " + items.woodScore.ToString();
            }
        }

        if (isClickedRock)
        {
            if (items.rockScoreText != null)
            {
                items.rockScoreText.text = items.itemRockName + ": " + items.rockScore.ToString();
            }
        }

    }
}

