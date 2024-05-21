using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : BubbleClass
{
    public override int GetScore(List<GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }


        int score = 50;

        GameManager.instance.SetNextChainMult(2);

        return score;
    }
}