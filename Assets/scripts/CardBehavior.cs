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
    public int triviaMastery;
    [SerializeField]
    public int soulsBorneSkills;
    [SerializeField]
    public int drinkMixing;
    [SerializeField]
    public int gameCollection;
    [SerializeField]
    public int speedRunning;
    [SerializeField]
    public int polykilling;
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
    GameObject[] playerCards;
    GameObject[] computerCards;

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
        GetTopCard(playerCards);
        GetTopCard(computerCards);
        Debug.Log("You are hovering over a " + gameObject.tag + "card called" + gameObject + "with an isTopCardValue of " + isTopCard);
    }

    public GameObject GetTopCard(GameObject [] array)
    {
        // initial setup
        if (array == playerCards)
        {
            array = GameObject.FindGameObjectsWithTag("PlayerCard");
        } else if (array == computerCards)
        {
            array = GameObject.FindGameObjectsWithTag("ComputerCard");
        }
        
        GameObject topCard;
        float lowestZed;
        if (array.Length == 0)
        {
            return null;
        }
        else
        {
            topCard = array[0];
            lowestZed = 0;
        }

        // find and return closest pickup
        for (int i = 0; i < array.Length; i++)
        {
            float zpos = array[i].transform.position.z;
            if (zpos < lowestZed)
            {
                topCard = array[i];
                lowestZed = array[i].transform.position.z;
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
