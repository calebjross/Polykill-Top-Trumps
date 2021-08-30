using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 
/// </summary>

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    public GameObject[] cards = new GameObject[4];

    // used to establish the first card position
    float xpos = 6f;
    float ypos = -1f;
    float zpos = 0f;

    #endregion

    #region Properties

    #endregion

    #region Methods
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            Instantiate(cards[i], new Vector3(xpos, ypos, zpos), Quaternion.identity);
            xpos -= 0.5f;
            ypos += 0.5f;
            zpos -= 0.1f;
        }

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    void OnMouseOver()
    {

    }

    #endregion
}
