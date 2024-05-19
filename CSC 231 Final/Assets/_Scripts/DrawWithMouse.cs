using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    private LineRenderer line;
    public List<Vector3> mousePosition;


    void Start()
    {

    }


    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(tempMousePos, mousePosition[mousePosition.Count -1]) > .1f)
            {
                UpdateLine(tempMousePos);
            }
        }
        if(Input.GetMouseButtonUp(0)) {
            DestroyLine();
        }
    }

    void CreateLine()
    { 
       currentLine = Instantiate (linePrefab, Vector3.zero, Quaternion.identity);
       line = GetComponent<LineRenderer>();
        mousePosition.Clear();
        mousePosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        line.SetPosition(0, mousePosition[0]);
        line.SetPosition(1, mousePosition[1]);
    }

    void UpdateLine(Vector3 newMousePos)
    {
        mousePosition.Add(newMousePos);
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, newMousePos);
    }

    void DestroyLine() {
        Destroy(currentLine);
    }
}
