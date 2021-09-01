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
        spriteRenderer.sprite = cardBack;
    }

    /// <summary>
    /// MouseDown click actions
    /// </summary>
    private void OnMouseDown()
    {
        if (isFaceUp && isPlayerTopCard)
        {
            Destroy(gameObject);
        } else FlipCard();
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
        
        if (gameObject.tag == "PlayerCard")
        {
            Debug.Log("You are hovering over a " + gameObject.tag + "card called" + gameObject + "with an isTopCardValue of " + isPlayerTopCard);
        }
        else if (gameObject.tag == "ComputerCard")
        {
            Debug.Log("You are hovering over a " + gameObject.tag + "card called" + gameObject + "with an isTopCardValue of " + isComputerTopCard);
        }
        
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

    private void Update()
    {
        
    }

    #endregion
}
