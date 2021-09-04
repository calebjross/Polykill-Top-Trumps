using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelection : MonoBehaviour
{
    public int playerStat;
    public int computerStat;
    CardBehavior cardBehavior;
    SpriteRenderer sprite;
    GameObject computerTopCard;

    private void Start()
    {
        cardBehavior = GetComponentInParent<CardBehavior>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    private void OnMouseOver()
    {
        
        //determines which stat value to select from the player card
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
<<<<<<< Updated upstream
=======
            computerTopCard = cardBehavior.GetComputerTopCard();
>>>>>>> Stashed changes
            switch (gameObject.name)
            {
                case "stat0":
                    playerStat = cardBehavior.stat0;
                    break;
                case "stat1":
                    playerStat = cardBehavior.stat1;
                    break;
                case "stat2":
                    playerStat = cardBehavior.stat2;
                    break;
                case "stat3":
                    playerStat = cardBehavior.stat3;
                    break;
                case "stat4":
                    playerStat = cardBehavior.stat4;
                    break;
                case "stat5":
                    playerStat = cardBehavior.stat5;
                    break;
                default:
                    playerStat = 0;
                    break;
            }
<<<<<<< Updated upstream
            Debug.Log("You are hovering over: " + gameObject + "with a value of " + playerStat);
=======
            //Debug.Log("Player " + gameObject + "stat is " + playerStat + ". Comp "+ computerTopCard + "stat is " + computerStat);
>>>>>>> Stashed changes
            sprite.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (sprite.enabled == true)
        {
            sprite.enabled = false;
        }
<<<<<<< Updated upstream
=======

        // ensure stats do not retain a value
        playerStat = 0;
        computerStat = 0;
    }

    private void OnMouseDown()
    {
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
            computerTopCard.GetComponent<CardBehavior>().FlipCard();
            cardBehavior.Battle(playerStat, computerStat);
        }
    }

    private void MoveCardToCompetitorPile()
    {
        //code to move the losing card to the winner card pile after battle completion
        //must add card to the bottom (highest z) of the pile and move each card of the pile up
>>>>>>> Stashed changes
    }
}
