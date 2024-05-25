using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGoalText : MonoBehaviour
{
    TMP_Text scoreGoal;

    void Start()
    {
        scoreGoal = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreGoal.text = GameManager.instance.GetMaxScore().ToString();
    }
}
