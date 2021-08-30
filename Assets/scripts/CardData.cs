using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class CardData : MonoBehaviour
{
    #region Fields
    [SerializeField]
    string cardName; // the name of the card. ie, Burgerchamp
    [SerializeField]
    string statName; // the name of the stat. ie, Trivia Mastery
    [SerializeField]
    int statValue; // the value of the stat. ie, 93
    [SerializeField]
    Sprite icon; // the sprite used for the card image

    #endregion

    #region Properties

    #endregion

    #region Methods
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
    #endregion
}
