using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Slider ScoreBar;
    public float CurrentScore = 0f;
    float TargetScore;
    private float LerpSpeed = 5f;
    private float time;
    void Start()
    {
        SetScoreBar(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) 
        {
            GainPoints(10);
        }

        AnimateScoreBar();
    }


    public void SetScoreBar(float maxScore)
    {
        ScoreBar.maxValue = maxScore;
        ScoreBar.value = CurrentScore;

    }
    public void GainPoints(float score)
    {
        CurrentScore += score;
        time = 0;
    }

    private void AnimateScoreBar()
    {
        TargetScore = CurrentScore;
        float MaxScore = ScoreBar.value;
        time = Time.deltaTime * LerpSpeed;
        ScoreBar.value = Mathf.Lerp(MaxScore, TargetScore, time);
    }
}
