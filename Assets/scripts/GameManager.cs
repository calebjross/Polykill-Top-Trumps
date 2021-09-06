using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    public GameObject[] playerCards = new GameObject[10];
    GameObject[] computerCards = new GameObject[10];

    [SerializeField]
    public Text playerText;
    [SerializeField]
    public Text computerText;

    // used to establish the first card position
    float pxpos; //player
    float pypos; //player
    float pzpos; //player
    float cxpos; //computer
    float cypos; //computer
    float czpos; //computer

    // used for Shuffle() method
    private GameObject tempGO;

    // set card counts / scores
    public int playerCardScore = 0;
    public int computerCardScore = 0;

    #endregion

    #region Properties

    #endregion

    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //make computerCards match playerCards
        computerCards = playerCards;

        // shuffle original array before dealing out to player and computer
        Shuffle(playerCards);

        //player cards behavior
        pxpos = 6f;
        pypos = -1f;
        pzpos = 0f;
        for (int i = 0; i < playerCards.Length; i += 2)
        {
            playerCards[i].tag = "PlayerCard";
            Instantiate(playerCards[i], new Vector3(pxpos, pypos, pzpos), Quaternion.identity);
            pxpos -= 0.2f;
            pypos += 0.2f;
            pzpos -= 0.1f;
        }

        //computer cards behavior
        cxpos = -6f;
        cypos = -1f;
        czpos = 0f;
        for (int i = 1; i < computerCards.Length; i += 2)
        {
            computerCards[i].tag = "ComputerCard";
            Instantiate(computerCards[i], new Vector3(cxpos, cypos, czpos), Quaternion.identity);
            cxpos += 0.2f;
            cypos += 0.2f;
            czpos -= 0.1f;
        }
        playerCardScore = playerCards.Length/2;
        computerCardScore = computerCards.Length/2;
    }

    /// <summary>
    /// shuffles the cards order
    /// </summary>
    public void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int rnd = Random.Range(i, array.Length);
            tempGO = array[rnd];
            array[rnd] = array[i];
            array[i] = tempGO;
        }
    }

    public void Update()
    {
        playerText.text = "Player cards remaining: " + playerCardScore.ToString();
        computerText.text = "Computer cards remaining: " + computerCardScore.ToString();
    }

    #endregion
}
