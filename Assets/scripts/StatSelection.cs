using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelection : MonoBehaviour
{
    public int playerStat;
    public int computerStat;
    CardBehavior cardBehavior;
    SpriteRenderer sprite;

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
            Debug.Log("You are hovering over: " + gameObject + "with a value of " + playerStat);
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
}
