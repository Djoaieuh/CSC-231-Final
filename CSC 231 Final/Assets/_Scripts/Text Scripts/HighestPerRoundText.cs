using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighestPerRoundText : MonoBehaviour
{
    TMP_Text highestPerRound;

    void Start()
    {
        highestPerRound = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highestPerRound.text = GameManager.instance.GetHighestScoreRound().ToString();
    }
}
