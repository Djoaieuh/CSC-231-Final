using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject Grid;

    [SerializeField] GameObject GirlGenerator;

    [SerializeField] GameObject ScoreManager;

    [SerializeField] GameObject Background; //test

    [SerializeField] GameObject Girl;

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

    string currentP;

    string currentD;

    AudioManager audiomanager;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> bubbleChain;

    void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

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

        scoreGoal = 250;

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
            DisconnectSound();
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

            Debug.Log("Compare for selection");

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
            ConnectSound();
        }

        ClearChain();
    }


    void CalculateScore()
    {
        int newScore = 0;

        currentChainMult = nextChainMult;
        nextChainMult = 1;


        for (int i = 0; i < bubbleChain.Count; i++)
        {
            currentMult = nextMult;
            nextMult = 1;

            newScore = newScore + (bubbleChain[i].GetComponent<BubbleClass>().GetScore(bubbleChain, currentP, currentD) * currentMult);

        }

        Debug.Log(newScore);

        score = score + (newScore * currentChainMult);

        Debug.Log(score);

        ScoreManager.GetComponent<ScoreManager>().GainPoints(score);

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
        Debug.Log(currentChainMult);
        currentChainMult = currentChainMult * mult;
        Debug.Log(currentChainMult);
    }

    public void AddConnections(int c)
    {
        bonusConnections += c;
    }

    private void NewRound()
    {

        for (int i = 0; i < curRound; i++)
        {
            scoreGoal = (int)(scoreGoal * 1.05f);
        }

        ++curRound;

        Grid.GetComponent<GridManager>().ResetGrid();

        timer = 30;

        score = 0;

        GirlGenerator.GetComponent<GirlGenerator>().GenerateNewGirl();

        currentP = GirlGenerator.GetComponent<GirlGenerator>().GetPreference();

        currentD = GirlGenerator.GetComponent<GirlGenerator>().GetDislike();

        Background.GetComponent<BackgroundGenerator>().GenerateBackground();

        movesLeft = 3;
        ScoreManager.GetComponent<ScoreManager>().ResetBar();
        ScoreManager.GetComponent<ScoreManager>().SetScoreBar(scoreGoal);

    }

    public void NextMove()
    {
        ClearChain();
        movesLeft--;

        if (score >= scoreGoal)
        {
            NewRound();
        }
        else if (((float)score / (float)scoreGoal) * 100 >= 66)
        {
            Debug.Log("Higher than 66");

            Girl.GetComponent<GirlScript>().SetExpression(1);
        }
        else if (((float)score / (float)scoreGoal) * 100 >= 33)
        {
            Debug.Log("Higher than 33");

            Girl.GetComponent<GirlScript>().SetExpression(5);
        }
        else if (movesLeft == 0)
        {
            GameOver();
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

    public void GameOver()
    {
        SceneManager.LoadScene(2);

        Grid.GetComponent<GridManager>().ResetGrid();
        ScoreManager.GetComponent<ScoreManager>().ResetBar();
        Debug.Log("Game Over");
    }

    public int GetMaxScore()
    {
        return scoreGoal;
    }

    public int GetMoves()
    {
        return movesLeft;
    }

    public int GetScore()
    {
        return score;
    }

    public void ConnectSound()
    {
        AudioManager.instance.PlaySFX(audiomanager.Connect);
    }

    public void DisconnectSound()
    {
        AudioManager.instance.PlaySFX(audiomanager.Disconnect);
    }
}
