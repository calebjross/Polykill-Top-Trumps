using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelection : MonoBehaviour
{
    public int playerStat;
    public int computerStat;
    CardBehavior cardBehavior;
    SpriteRenderer sprite;
    GameManager gameManager;
    GameObject computerTopCard;

    private void Start()
    {
        cardBehavior = GetComponentInParent<CardBehavior>();
        sprite = GetComponent<SpriteRenderer>();
        gameManager = Camera.main.GetComponent<GameManager>();
        sprite.enabled = false;
    }

    public void OnMouseOver()
    {
        //determines which stat value to select from the player card
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
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
            Debug.Log("Player " + gameObject + " of " + playerStat + " vs Computer " + computerTopCard + " of " + computerStat);
            sprite.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (sprite.enabled == true)
        {
            sprite.enabled = false;
        }
    }
    private void OnMouseDown()
    {
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
            gameManager.Battle(playerStat,computerStat);
            computerTopCard.GetComponent<CardBehavior>().FlipCard();
        }
    }

    private void MoveCardToCompetitorPile()
    {
        //code to move the losing card to the winner card pile after battle completion
        //must add card to the bottom (highest z) of the pile and move each card of the pile up
    }
}
