using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject Grid;

    [SerializeField] GameObject GirlGenerator;


    int maxConnections;

    int movesLeft;

    int bonusConnections;

    int connectionsLeft;

    int currentMult;
    int currentChainMult;

    int nextMult;
    int nextChainMult;

    float timer;

    int score;
    int scoreGoal;

    int curRound;

    string prevBubbleType;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> bubbleChain;

    void Start()
    {
        maxConnections = 4;
        connectionsLeft = maxConnections;

        currentMult = 1;
        currentChainMult = 1;

        nextMult = 1;
        nextChainMult = 1;

        score = 0;

        timer = 30;

        prevBubbleType = "";

        curRound = 0;

        scoreGoal = 50;

        NewRound();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ExitChain();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ClearChain();
        }

        if (timer <= 0)
        {
            GameOver();

            Debug.Log(timer);
        }
        else
        {
            timer = timer - Time.deltaTime;
        }



    }

    public void AddToChain(GameObject currentBubble)
    {
        if (!bubbleChain.Contains(currentBubble) && connectionsLeft != 0 && movesLeft > 0)
        {
            bubbleChain.Add(currentBubble);
            currentBubble.GetComponent<BubbleScript>().Select();

            if (!currentBubble.GetComponent<BubbleClass>().CompareType(prevBubbleType))
            {
                connectionsLeft--;
            }

            prevBubbleType = currentBubble.tag;

        }
    }

    public void ExitChain()
    {
        if (bubbleChain.Count > 2)
        {
            bonusConnections = 0;

            CalculateScore();
        }

        ClearChain();
    }


    void CalculateScore()
    {
        int newScore = 0;

        currentChainMult = nextChainMult;
        nextChainMult = 1;

        string currentP = GirlGenerator.GetComponent<GirlGenerator>().GetPreference();

        string currentD = GirlGenerator.GetComponent<GirlGenerator>().GetDislike();


        for (int i = 0; i < bubbleChain.Count; i++)
        {
            currentMult = nextMult;
            nextMult = 1;

            newScore = newScore + (bubbleChain[i].GetComponent<BubbleClass>().GetScore(bubbleChain, currentP, currentD) * currentMult);

        }

        score = score + (newScore * currentChainMult);

        for (int i = 0; i < bubbleChain.Count; i++)
        {
            bubbleChain[i].GetComponent<BubbleScript>().Disappear();
        }

        NextMove();
    }

    public bool IsChainEmpty()
    {
        if (bubbleChain.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearChain()
    {
        for (int i = 0; i < bubbleChain.Count; i++)
        {
            GameObject currentbubble = bubbleChain[i];

            currentbubble.GetComponent<BubbleScript>().Deselect();
        }

        connectionsLeft = maxConnections + bonusConnections;

        bubbleChain.Clear();
    }

    public List<GameObject> GetChain()
    {
        return bubbleChain;
    }

    public void SetMult(int mult)
    {
        nextMult = nextMult * mult;
    }

    public void SetNextChainMult(int mult)
    {
        nextChainMult = nextChainMult * mult;
    }

    public void SetCurrentChainMult(int mult)
    {
        currentChainMult = currentChainMult * mult;
    }

    public void AddConnections(int c)
    {
        bonusConnections += c;
    }

    private void NewRound()
    {
        curRound++;

        for (int i = 0; i <= 1; i++)
        {
            scoreGoal = (int)(scoreGoal * 1.12f);
        }


        Grid.GetComponent<GridManager>().ResetGrid();

        timer = 30;

        score = 0;

        GirlGenerator.GetComponent<GirlGenerator>().GenerateNewGirl();

        movesLeft = 3;


    }

    public void NextMove()
    {
        ClearChain();

        movesLeft--;

        if (movesLeft == 0)
        {
            EndRound();
        }
    }

    public int GetTimer()
    {
        return (int)timer;
    }

    public void AddTime(int time)
    {
        timer += time;
    }

    void EndRound()
    {
        if (score >= scoreGoal)
        {
            NewRound();
        }

        else
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        Grid.GetComponent<GridManager>().ResetGrid();

        Debug.Log("Game Over");
    }
}
