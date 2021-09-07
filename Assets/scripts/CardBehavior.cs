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
    public string winner;

    // support for determining the top card
    GameManager gameManager;
    public bool isPlayerTopCard;
    public bool isComputerTopCard;
    GameObject playerTopCard;
    GameObject computerTopCard;

    //creates time for card flips before battle ends
    public float targetTime;
    public bool battleTimerActive;
    // creates time for card flips after battle ends
    public float flipTargetTime;
    public bool flipTimerActive;

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
}

    private void Start()
    {
        if (isFaceUp)
        {
            bc2d.enabled = false;
            spriteRenderer.sprite = cardFront;
        }
        if (!isFaceUp)
        {
            bc2d.enabled = true;
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
        playerTopCard = GetPlayerTopCard();
        computerTopCard = GetComputerTopCard();

        if (bc2d != null)
        {
            //tracks clickability of box collider
            if (isFaceUp == true)
            {
                bc2d.enabled = false;
            }
            else bc2d.enabled = true;
        }

        //battle timer
        if (battleTimerActive)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                battleTimerActive = false;
                flipTimerActive = true;
                flipTargetTime = 0.2f;
                //flip both cards after determining winner
                computerTopCard.GetComponent<CardBehavior>().FlipCard();
                playerTopCard.GetComponent<CardBehavior>().FlipCard();
                
            }
        }
        //post battle flip timer
        if (flipTimerActive)
        {
            flipTargetTime -= Time.deltaTime;
            if (flipTargetTime <= 0.0f)
            {
                flipTimerActive = false;
                //move cards to competitor pile
                MoveCardToCompetitorPile(winner);
            }
        }

        //flips card
        if (!isFaceUp)
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
    /// Initiates a battle between player and comp card based on the chosen stat
    /// </summary>
    /// <param name="playerStat"></param>
    /// <param name="computerStat"></param>
    public void Battle(int playerStat, int computerStat)
    {
        //set all stat boxes to unclickable
        GameObject[] StatBars = GameObject.FindGameObjectsWithTag("StatBar");
        for (int i = 0; i < StatBars.Length; i++)
        {
            StatBars[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        //active the battle timer
        battleTimerActive = true;
        targetTime = 2.0f;

        if (computerTopCard.GetComponent<CardBehavior>().isFaceUp == false)
        {
            computerTopCard.GetComponent<CardBehavior>().FlipCard();
        }

        winner = null;
        if (playerStat > computerStat)
        {
            winner = "player";
        }
        else if (playerStat < computerStat)
        {
            winner = "computer";
        }
    }

    private void MoveCardToCompetitorPile(string winner)
    {
        switch (winner)
        {
            case "player":
                gameManager.playerCardScore += 1;
                gameManager.computerCardScore -= 1;
                GameObject[] playerCardsArray = GameObject.FindGameObjectsWithTag("PlayerCard");
                for (int i = 0; i < playerCardsArray.Length; i++)
                {
                    playerCardsArray[i].transform.position = new Vector3(playerCardsArray[i].transform.position.x - 0.4f,
                        playerCardsArray[i].transform.position.y + 0.4f, playerCardsArray[i].transform.position.z - 0.2f);
                }

                computerTopCard.transform.position = new Vector3(6f, -1f, 0f);
                playerTopCard.transform.position = new Vector3(5.8f, -0.8f, -0.1f);
                computerTopCard.tag = "PlayerCard";
                playerTopCard.tag = "PlayerCard";
                break;
            case "computer":
                gameManager.playerCardScore -= 1;
                gameManager.computerCardScore += 1;
                GameObject[] computerCardsArray = GameObject.FindGameObjectsWithTag("ComputerCard");
                for (int i = 0; i < computerCardsArray.Length; i++)
                {
                    computerCardsArray[i].transform.position = new Vector3(computerCardsArray[i].transform.position.x + 0.4f,
                        computerCardsArray[i].transform.position.y + 0.4f, computerCardsArray[i].transform.position.z - 0.2f);
                }

                playerTopCard.transform.position = new Vector3(-6f, -1f, -0f);
                computerTopCard.transform.position = new Vector3(-5.8f, -0.8f, -0.1f);
                computerTopCard.tag = "ComputerCard";
                playerTopCard.tag = "ComputerCard";
                break;
        }

        //set winner to null
        computerTopCard.GetComponent<CardBehavior>().winner = null;
        playerTopCard.GetComponent<CardBehavior>().winner = null;
    }



    //*********************************************************
    // GET TOP CARDS
    //*********************************************************

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
