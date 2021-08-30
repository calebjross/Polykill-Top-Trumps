using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class InitializeGame : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject card;
  
    #endregion

    #region Properties

    #endregion

    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }
    #endregion
}
