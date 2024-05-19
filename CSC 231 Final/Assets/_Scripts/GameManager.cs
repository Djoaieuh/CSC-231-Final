using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject Grid;

    [SerializeField] GameObject GirlGenerator;


    int maxConnections;
    int currentMult;
    int chainMult;

    float timer;

    int score;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> bubbleChain;

    void Start()
    {
        maxConnections = 4;
        currentMult = 1;
        chainMult = 1;

        score = 0;

        timer = 30;

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
        }
        else 
        {
            timer =- Time.deltaTime;
        }



    }

    public void AddToChain(GameObject currentBubble)
    {
        if (!bubbleChain.Contains(currentBubble) && bubbleChain.Count < maxConnections)
        {
            bubbleChain.Add(currentBubble);
            currentBubble.GetComponent<BubbleScript>().Select();

        }
    }

    public void ExitChain()
    {
        if (bubbleChain.Count > 2)
        {
            CalculateScore();
        }

        ClearChain();
    }


    void CalculateScore()
    {
        for (int i = 0; i < bubbleChain.Count; i++)
        {
            score = score + bubbleChain[i].GetComponent<BubbleClass>().GetScore(bubbleChain, currentMult * chainMult);

            //Debug.Log(score);
        }

        for (int i = 0; i < bubbleChain.Count; i++)
        {
            Destroy(bubbleChain[i]);
        }

        ClearChain();
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

        bubbleChain.Clear();
    }

    public List<GameObject> GetChain()
    {
        return bubbleChain;
    }

    public void SetMult(int mult)
    {
        currentMult = mult;
    }

    public void SetChainMult(int mult)
    {
        chainMult = chainMult * mult;
    }

    private void NewRound()
    {
        Grid.GetComponent<GridManager>().RefillGrid();

        timer = 30;

        //GirlGenerator.GetComponent<GirlGenerator>().GenerateNewGirl();




    }


    public void GameOver()
    {
        //Debug.Log("Game Over");
    }

}
