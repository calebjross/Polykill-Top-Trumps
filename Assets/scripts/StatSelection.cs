using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelection : MonoBehaviour
{
    public int playerStat;
    public int computerStat;
    CardBehavior cardBehavior;
    Renderer renderer;
    SpriteRenderer spriteRenderer;
    GameObject computerTopCard;
    BoxCollider2D bc2d;
    GameManager gameManager;
    StatSounds statSounds;
    AudioSource audioSource;

    //determines ability for stat menus to be interactive
    public bool isBattlingCantClick;

    private void Start()
    {
        cardBehavior = GetComponentInParent<CardBehavior>();
        renderer = GetComponent<Renderer>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        gameManager = Camera.main.GetComponent<GameManager>();
        bc2d = GetComponent<BoxCollider2D>();
        renderer.enabled = false;
        statSounds = GetComponentInParent<StatSounds>();
        audioSource = GetComponentInParent<AudioSource>();
        isBattlingCantClick = false;
    }

    private void Update()
    {
        //ensures that colliders and triggers are only enabled when needed
        if (!cardBehavior.isFaceUp && bc2d != null)
        {
            bc2d.enabled = false;
            bc2d.isTrigger = false;
        }
        if (cardBehavior.isFaceUp && bc2d != null)
        {
            bc2d.enabled = true;
            bc2d.isTrigger = true;
        }
    }

    public void OnMouseEnter()
    {
        //determines which stat value to select from the player card
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
            renderer.enabled = true;
            spriteRenderer.sprite = cardBehavior.selectorSprite;
            computerTopCard = cardBehavior.GetComputerTopCard();
            switch (gameObject.name)
            {
                case "stat0":
                    playerStat = cardBehavior.stat0;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat0;
                    break;
                case "stat1":
                    playerStat = cardBehavior.stat1;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat1;
                    break;
                case "stat2":
                    playerStat = cardBehavior.stat2;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat2;
                    break;
                case "stat3":
                    playerStat = cardBehavior.stat3;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat3;
                    break;
                case "stat4":
                    playerStat = cardBehavior.stat4;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat4;
                    break;
                case "stat5":
                    playerStat = cardBehavior.stat5;
                    computerStat = computerTopCard.GetComponent<CardBehavior>().stat5;
                    break;
                default:
                    playerStat = 0;
                    break;
            }

            if (statSounds != null)
            {
                //call to sounds script
                statSounds.PlayMusic();
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        renderer.enabled = false;
    }
    private void OnMouseDown()
    {
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard && !isBattlingCantClick)
        {
            cardBehavior.Battle(playerStat, computerStat);
            gameManager.DisplayChosenStats(playerStat, computerStat);
            GameObject[] StatBars = GameObject.FindGameObjectsWithTag("StatBar");
            for (int i = 0; i < StatBars.Length; i++)
            {
                StatBars[i].GetComponent<StatSelection>().isBattlingCantClick = true;
            }
        }
    }
}
