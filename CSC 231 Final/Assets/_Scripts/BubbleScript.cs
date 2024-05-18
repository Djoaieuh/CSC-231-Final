using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;

    Vector2 Position;
    private enum State
    {
        Idle,
        Hovered,
        Current,
        Selected
    }

    private State currentState;

    void Start()
    {
        currentState = State.Idle;

        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (currentState == State.Selected)
        {
            SpriteRenderer.color = Color.red;
        }
        else if (currentState == State.Idle)
        {
            SpriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        currentState = State.Selected;

        GameManager.instance.AddToChain(gameObject);

        Debug.Log(Position);
    }

    private void OnMouseEnter()
    {
        if (!GameManager.instance.IsChainEmpty())
        {
            List<GameObject> bubbleChain = GameManager.instance.GetChain();
            GameObject preBubble = bubbleChain.Last();

            if (Vector2.Distance(Position, preBubble.GetComponent<BubbleScript>().GetPosition()) == 1)
            {
                GameManager.instance.AddToChain(gameObject);
                currentState = State.Selected;
            }
        }
    }

    public void Select()
    {
        currentState = State.Selected;
    }

    public void Deselect()
    {
        currentState = State.Idle;
    }

    public void SetPosition(Vector2 startPos)
    {
        Position = startPos;
    }

    public Vector2 GetPosition()
    {
        return Position;
    }
}
