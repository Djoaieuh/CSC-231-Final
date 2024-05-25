using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }


        int score = 75;

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }
        
        Debug.Log(score);

        return score;
    }
}