using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelection : MonoBehaviour
{
    public int playerStat;
    public int computerStat;
    CardBehavior cardBehavior;
    Renderer spriteRenderer;
    GameObject computerTopCard;
    BoxCollider2D bc2d;

    private void Start()
    {
        cardBehavior = GetComponentInParent<CardBehavior>();
        spriteRenderer = GetComponent<Renderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (bc2d != null)
        {
            //tracks clickability of box collider
            if (cardBehavior.isFaceUp == true)
            {
                bc2d.enabled = true;
            }
            else bc2d.enabled = false;
        }
    }

    public void OnMouseEnter()
    {
        //determines which stat value to select from the player card
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
            spriteRenderer.enabled = true;
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
        }
    }

    private void OnMouseExit()
    {
        spriteRenderer.enabled = false;
    }
    private void OnMouseDown()
    {
        if (cardBehavior.isFaceUp && cardBehavior.isPlayerTopCard)
        {
            cardBehavior.Battle(playerStat, computerStat);
        }
    }
}
