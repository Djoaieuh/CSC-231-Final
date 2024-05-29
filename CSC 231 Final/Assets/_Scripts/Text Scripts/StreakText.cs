using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StreakText : MonoBehaviour
{
    TMP_Text streak;

    void Start()
    {
        streak = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        streak.text = GameManager.instance.GetStreak().ToString();
    }
}