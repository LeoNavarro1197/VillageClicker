using System.Collections;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public Items items;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public bool isClickedTree = false, isClickedRock = false;

    void Start()
    {
        UpdateScore();
    }

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(audioSource.clip);

        if (gameObject.tag == "Arbol")
        {
            items.woodScore++;
            isClickedTree = true;
            UpdateScore();
        }

        if(gameObject.tag == "Piedra")
        {
            items.rockScore++;
            isClickedRock = true;
            UpdateScore();
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

