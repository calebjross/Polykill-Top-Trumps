using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides the functionality of the card
/// </summary>

public class CardBehavior : MonoBehaviour
{
    //establish fields that will controlled via the inspector
    #region Fields
    [SerializeField]
    Sprite cardFront;
    [SerializeField]
    Sprite cardBack;

    //will help set images on the top and bottom of card
    SpriteRenderer spriteRenderer;

    // determines face up status
    public bool isFaceUp = false;

    // support for determining the top card
    GameManager gameManager;
    public bool isTopCard;

    // support for exposing the stats
    CardStats stats;
    int triviaMastery;
    int soulsBorneSkills;
    int drinkMixing;
    int gameCollection;
    int speedRunning;
    int polykilling;

    #endregion

    #region Properties

    #endregion

    #region Methods

    private void Awake()
    {
        //establish card properties and state
        gameManager = Camera.main.GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardBack;
        stats = GetComponent<CardStats>();
        triviaMastery = stats.triviaMastery;
        soulsBorneSkills = stats.soulsBorneSkills;
        drinkMixing = stats.drinkMixing;
        gameCollection = stats.gameCollection;
        speedRunning = stats.speedRunning;
        polykilling = stats.polykilling;
    }

    private void OnMouseDown()
    {
        if (isFaceUp && isTopCard)
        {
            Destroy(gameObject);
        } else FlipCard();
    }

    private void FlipCard()
    {
        if (!isFaceUp && isTopCard)
        {
            spriteRenderer.sprite = cardFront;
            isFaceUp = true;
        }
        else if (!isFaceUp && !isTopCard)
        {
            spriteRenderer.sprite = cardBack;
            isFaceUp = false;
        } 
    }

    private void OnMouseOver()
    {
        GetTopCard();
        Debug.Log("You are hovering over " + gameObject + "with an isTopCardValue of " + isTopCard + " but the top card is " + GetTopCard() + ". The polykilling stat is " + polykilling);
    }

    public GameObject GetTopCard()
    {
        // initial setup
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
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

        if (topCard == gameObject)
        {
            isTopCard = true;
        }
        else isTopCard = false;

        return topCard;
    }

    private void Update()
    {
        
    }

    #endregion
}
