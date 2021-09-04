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
    public int stat0;
    [SerializeField]
    public int stat1;
    [SerializeField]
    public int stat2;
    [SerializeField]
    public int stat3;
    [SerializeField]
    public int stat4;
    [SerializeField]
    public int stat5;
    [SerializeField]
    Sprite cardFront;
    [SerializeField]
    Sprite cardBack;

    //will help set images on the top and bottom of card
    SpriteRenderer spriteRenderer;

    // determines face up status
    public bool isFaceUp;

    // support for determining the top card
    GameManager gameManager;
    public bool isPlayerTopCard;
    public bool isComputerTopCard;
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
        isFaceUp = false;
}

    private void Start()
    {
        if (isFaceUp)
        {
            spriteRenderer.sprite = cardFront;
        }
        else if (!isFaceUp)
        {
            spriteRenderer.sprite = cardBack;
        }
    }

    /// <summary>
    /// MouseDown click actions
    /// </summary>
    private void OnMouseDown()
    {
        if (!isFaceUp && isPlayerTopCard)
        {
            FlipCard();
        }
    }

    /// <summary>
    /// Determines whether or not a player card can be flipped over
    /// </summary>
    private void FlipCard()
    {
        if (!isFaceUp && isPlayerTopCard)
        {
            spriteRenderer.sprite = cardFront;
            isFaceUp = true;
        }
        else if (!isFaceUp && !isPlayerTopCard)
        {
            spriteRenderer.sprite = cardBack;
            isFaceUp = false;
        } 
    }

    /// <summary>
    /// Used prmiarly to send debug.log messages. MouseOver has no gameplay functionality
    /// </summary>
    private void OnMouseOver()
    {
        GetPlayerTopCard();
        GetComputerTopCard();        
    }

    /// <summary>
    /// Gets the player's top card, which is used to determine playability
    /// </summary>
    public GameObject GetPlayerTopCard()
    {

        //initial setup
        GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerCard");

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
            isPlayerTopCard = true;
        }
        else isPlayerTopCard = false;

        return topCard;
    }
    /// <summary>
    /// Gets the computer's top card, which is used to determine playability
    /// </summary>
    public GameObject GetComputerTopCard()
    {

        //initial setup
        GameObject[] array = GameObject.FindGameObjectsWithTag("ComputerCard");

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
            isComputerTopCard = true;
        }
        else isComputerTopCard = false;

        return topCard;
    }

    #endregion
}
