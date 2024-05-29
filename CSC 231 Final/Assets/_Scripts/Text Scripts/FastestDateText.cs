using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FastestDateText : MonoBehaviour
{
    TMP_Text time;

    void Start()
    {
        time = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time.text = GameManager.instance.GetFastestDate().ToString();
    }
}