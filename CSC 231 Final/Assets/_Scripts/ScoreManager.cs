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
   float MaxScore;
    void Start()
    {
        MaxScore = (float) GameManager.instance.GetMaxScore();
        SetScoreBar(MaxScore);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void ResetBar()
    {
        CurrentScore = 0;
    }
}
