using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;

    GameObject parent, grid;
    Vector2 Position;
    private enum State
    {
        Inactive,
        Idle,
        Selected
    }

    private State currentState;

    void Start()
    {
        currentState = State.Inactive;

        Appear();

        SpriteRenderer = GetComponent<SpriteRenderer>();

        parent = transform.parent.gameObject;

        grid = transform.parent.parent.gameObject;
    }

    void Update()
    {
        if (currentState == State.Selected)
        {
            SpriteRenderer.color = new Color(0.65f, 0.81f, 0.93f);
        }
        else if (currentState == State.Idle)
        {
            SpriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        if (!(currentState == State.Inactive))
        {
            GameManager.instance.AddToChain(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        if (!GameManager.instance.IsChainEmpty() && !(currentState == State.Inactive))
        {
            List<GameObject> bubbleChain = GameManager.instance.GetChain();
            GameObject preBubble = bubbleChain.Last();

            if (Vector2.Distance(Position, preBubble.GetComponent<BubbleScript>().GetPosition()) == 1)
            {
                GameManager.instance.AddToChain(gameObject);
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

    private void Appear()
    {
        transform.DOScale(0.4f, 0.7f).OnComplete(() =>
        {
            currentState = State.Idle;
        });
    }

    public void Disappear()
    {
        transform.DOScale(0.00000001f, 0.5f).OnComplete(() =>
        {
            transform.parent = null;
            grid.GetComponent<GridManager>().RefillBubble(parent);
            Destroy(gameObject);
        });
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
