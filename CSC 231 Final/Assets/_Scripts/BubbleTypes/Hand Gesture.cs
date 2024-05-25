using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HandGesture : BubbleClass
{
    public override int GetScore(List <GameObject> bubbleChain, string preference, string dislike)
    {
        if (CompareType(dislike))
        {
            return -50;
        }

        int score = 30;

        GameManager.instance.SetMult(3);

        if (CompareType(preference))
        {
            GameManager.instance.SetCurrentChainMult(2);
        }

        Debug.Log(score);

        return score;
    }

}