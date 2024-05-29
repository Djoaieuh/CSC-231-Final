using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    int highestScoreMove;
    int highestScoreRound;
    int nbsOfRounds;
    int highestMult;
    int fastestTime;


    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void SetStats(int h, int H, int n, int Hmu, int t)
    {
        highestScoreMove = h;
        highestScoreRound = H;
        highestMult = Hmu;
        nbsOfRounds = n;
        fastestTime = t;
    }

    public int GetHighscoreRound()
    {
        return highestScoreRound;
    }

    public int GetHighestMult()
    {
        return highestMult;
    }

    public int GetNbsGirls()
    {
        return nbsOfRounds;
    }

    public int GetHighscoreMove()
    {
        return highestScoreMove;
    }

    public int GetLowestTime()
    {
        return fastestTime;
    }
}
