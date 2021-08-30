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
    GameManager cardsArray;


    #endregion

    #region Properties

    #endregion

    #region Methods

    private void Awake()
    {
        cardsArray = GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardFront;
        isFaceUp = true;
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //FlipCard();
        Destroy(gameObject);
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

    }

    #endregion
}
