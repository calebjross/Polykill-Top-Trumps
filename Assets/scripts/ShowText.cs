using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ShowText : MonoBehaviour
{
    #region Fields
    public Text textElement;

    // support for exposing the stats
    CardStats stats;
    int triviaMastery;
    int soulsBorneSkills;
    int drinkMixing;
    int gameCollection;
    int speedRunning;
    int polykilling;
    #endregion

    #region Properties

    #endregion

    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        stats = GetComponent<CardStats>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //establish card properties and state
        triviaMastery = stats.triviaMastery;
        soulsBorneSkills = stats.soulsBorneSkills;
        drinkMixing = stats.drinkMixing;
        gameCollection = stats.gameCollection;
        speedRunning = stats.speedRunning;
        polykilling = stats.polykilling;

        textElement.text = polykilling.ToString();
    }
    #endregion
}
