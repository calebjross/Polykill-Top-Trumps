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
    [SerializeField]
    public Sprite selectorSprite;
    [SerializeField]
    AudioClip selectorSound;

    //will help set images on the top and bottom of card
    SpriteRenderer spriteRenderer;

    // determines card state
    public bool isFaceUp;
    bool isFlipping;
    float flipXValue = 1f;
    bool isRebounding = false;
    BoxCollider2D bc2d;
    public bool isBattling;
    public string winner;

    // support for determining the top card
    GameManager gameManager;
    public bool isPlayerTopCard;
    public bool isComputerTopCard;

    #endregion

    #region Properties

    #endregion

    #region Methods

    private void Awake()
    {
        //establish card properties and state
        bc2d = GetComponent<BoxCollider2D>();
        gameManager = Camera.main.GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFaceUp = false;
        isFlipping = false;
        isBattling = false;
}

    private void Start()
    {
        if (isFaceUp)
        {
            bc2d.enabled = false;
            spriteRenderer.sprite = cardFront;
        }
        else if (!isFaceUp)
        {
            bc2d.enabled = true;
            spriteRenderer.sprite = cardBack;
        }

        GetPlayerTopCard();
        GetComputerTopCard();
    }

    /// <summary>
    /// MouseDown click actions
    /// </summary>
    private void OnMouseDown()
    {
        if (!isFaceUp && isPlayerTopCard)
        {
            isBattling = true;
            FlipCard();
            GameObject[] StatBars = GameObject.FindGameObjectsWithTag("StatBar");
            for (int i = 0; i < StatBars.Length; i++)
            {
                StatBars[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    /// <summary>
    /// Determines whether or not a player card can be flipped over
    /// </summary>
    public void FlipCard()
    {
        if (!isFaceUp)
        {
            bc2d.enabled = true;
            isFlipping = true;
            bc2d.isTrigger = true;

        }
        if (isFaceUp)
        {
            bc2d.enabled = false;
            isFlipping = true;
            bc2d.isTrigger = false;
        }
    }

    private void Update()
    {
        //reset the top cards in prep for the next round
        GetPlayerTopCard();
        GetComputerTopCard();

        //flips card
        if (!isFaceUp) {
            if (isFlipping)
            {
                if (!isRebounding)
                {
                    flipXValue -= 0.05f;
                    transform.localScale = new Vector2(flipXValue, transform.localScale.y);
                    if (flipXValue <= 0)
                    {
                        isRebounding = true;
                    }
                }
                if (isRebounding)
                {
                    spriteRenderer.sprite = cardFront;
                    flipXValue += 0.05f;
                    transform.localScale = new Vector2(flipXValue, transform.localScale.y);
                    if (flipXValue >= 1)
                    {
                        isRebounding = false;
                        flipXValue = 1;
                        isFlipping = false;
                        isFaceUp = true;
                        bc2d.enabled = false;
                    }
                }
            }
        } 
        if (isFaceUp)
        {
            if (isFlipping)
            {
                if (!isRebounding)
                {
                    flipXValue -= 0.05f;
                    transform.localScale = new Vector2(flipXValue, transform.localScale.y);
                    if (flipXValue <= 0)
                    {
                        isRebounding = true;
                    }
                }
                if (isRebounding)
                {
                    spriteRenderer.sprite = cardBack;
                    flipXValue += 0.05f;
                    transform.localScale = new Vector2(flipXValue, transform.localScale.y);
                    if (flipXValue >= 1)
                    {
                        isRebounding = false;
                        flipXValue = 1;
                        isFlipping = false;
                        isFaceUp = false;
                        bc2d.enabled = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Used prmiarly to send debug.log messages. MouseOver has no gameplay functionality
    /// </summary>
    public void OnMouseOver()
    {
        
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

    /// <summary>
    /// Initiates a battle between player and comp card based on the chosen stat
    /// </summary>
    /// <param name="playerStat"></param>
    /// <param name="computerStat"></param>
    public void Battle(int playerStat, int computerStat)
    {
        winner = null;
        if (playerStat > computerStat)
        {
            winner = "player";
            GameObject[] playerCardsArray = GameObject.FindGameObjectsWithTag("PlayerCard");
            for (int i = 0; i< playerCardsArray.Length; i++)
            {
                playerCardsArray[i].transform.position = new Vector3(playerCardsArray[i].transform.position.x - 0.4f,
                    playerCardsArray[i].transform.position.y + 0.4f, playerCardsArray[i].transform.position.z - 0.2f);
            }
            gameManager.playerCardScore += 1;
            gameManager.computerCardScore -= 1;
        }
        else if (playerStat < computerStat)
        {
            winner = "computer";
            GameObject[] computerCardsArray = GameObject.FindGameObjectsWithTag("ComputerCard");
            for (int i = 0; i < computerCardsArray.Length; i++)
            {
                computerCardsArray[i].transform.position = new Vector3(computerCardsArray[i].transform.position.x + 0.4f,
                    computerCardsArray[i].transform.position.y + 0.4f, computerCardsArray[i].transform.position.z - 0.2f);
            }
            gameManager.playerCardScore -= 1;
            gameManager.computerCardScore += 1;
        }

        MoveCardToCompetitorPile(winner);
    }

    private void MoveCardToCompetitorPile(string winner)
    {
        GameObject tempComputerTopCard = GetComputerTopCard();

        // 1. Count how many cards are to be moved (should always be 2, right?)
        // 2. determine which pile to move the cards to (computer or player)
        // 3. move all existing cards "to the winning pile" * the count of cards that are moving (to make room for the moved cards)
        // 4. Add the moved cards to the new pile starting at the original positions (see Start() of GameManager.cs)
        // 5. The destroy the two top cards. Be sure this destory still works after having moved cards up
        
        bc2d.isTrigger = false;

        switch (winner)
        {
            case "player":
                tempComputerTopCard.transform.position = new Vector3(6f, -1f, 0f);
                transform.position = new Vector3(5.8f, -0.8f, -0.1f);
                tempComputerTopCard.tag = "PlayerCard";
                gameObject.tag = "PlayerCard";
                break;
            case "computer":
                transform.position = new Vector3(-6f, -1f, -0f);
                tempComputerTopCard.transform.position = new Vector3(-5.8f, -0.8f, -0.1f);
                tempComputerTopCard.tag = "ComputerCard";
                gameObject.tag = "ComputerCard";
                break;
        }

        //flip both cards over to face down
        tempComputerTopCard.GetComponent<CardBehavior>().FlipCard();
        gameObject.GetComponent<CardBehavior>().FlipCard();

        //set isBattling to false
        tempComputerTopCard.GetComponent<CardBehavior>().isBattling = false;
        gameObject.GetComponent<CardBehavior>().isBattling = false;
        
        //reset all TopCard values to false
        tempComputerTopCard.GetComponent<CardBehavior>().isComputerTopCard = false;
        gameObject.GetComponent<CardBehavior>().isComputerTopCard = false;
        tempComputerTopCard.GetComponent<CardBehavior>().isPlayerTopCard = false;
        gameObject.GetComponent<CardBehavior>().isPlayerTopCard = false;
    }
    #endregion
}
