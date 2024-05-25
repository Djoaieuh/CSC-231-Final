using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LovePotion : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        float score = 20;

        score = score + (250 * (1 - (GameManager.instance.GetTimer() * 0.0333f)));

        Debug.Log(GameManager.instance.GetTimer());

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }

        Debug.Log(score);

        return (int)score;
    }
}