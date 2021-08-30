using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides the functionality of the card
/// </summary>

public class CardBehavior : MonoBehaviour
{
    #region Fields
    [SerializeField]
    int triviaMastery;
    [SerializeField]
    int soulsBorneSkills;
    [SerializeField]
    int drinkMixing;
    [SerializeField]
    int gameCollection;
    [SerializeField]
    int speedRunning;
    [SerializeField]
    int polykilling;
    [SerializeField]
    Sprite cardFront;
    [SerializeField]
    Sprite cardBack;

    //set sides of card
    SpriteRenderer spriteRenderer;

    // determines face up status
    bool isFaceUp = true;

    // support for determining the top card
    bool isTopCard;
    GameManager gameManager;


    #endregion

    #region Properties

    #endregion

    #region Methods

    private void Awake()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardFront;
        isFaceUp = true;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Debug.Log(GetTopCard());
    }

    private void FlipCard()
    {
        if (isFaceUp == true)
        {
            spriteRenderer.sprite = cardBack;
            isFaceUp = false;
        }
        else spriteRenderer.sprite = cardFront;
        isFaceUp = true;
    }

    private void OnMouseOver()
    {
        GetTopCard();
    }

    public GameObject GetTopCard()
    {
        // initial setup
        GameObject[] cards = gameManager.cards;
        GameObject topCard;
        float lowestZed;
        if (cards.Length == 0)
        {
            return null;
        }
        else
        {
            topCard = cards[0];
            lowestZed = 0;
        }

        // find and return closest pickup
        for (int i = 0; i < cards.Length; i++)
        {
            float zpos = cards[i].transform.position.z;
            if (zpos < lowestZed)
            {
                topCard = cards[i];
                lowestZed = cards[i].transform.position.z;
            }
        }
        return topCard;
    }

    #endregion
}
