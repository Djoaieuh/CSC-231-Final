using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestPerMove : MonoBehaviour
{
    TMP_Text highestMove;

    void Start()
    {
        highestMove = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highestMove.text = GameManager.instance.GetHighestScoreMove().ToString();
    }
}