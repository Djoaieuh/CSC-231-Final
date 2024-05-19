using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GirlGenerator : MonoBehaviour
{

    [SerializeField] List<Sprite> sprites;


    [SerializeField] List<string> bubbleTypes;

    string currentPreference;

    string previousPreference;

    string currentDislike;

    string previousDislike;

    void Start()
    {

    }
    void Update()
    {

    }

    public void GenerateNewGirl()
    {

        previousPreference = currentPreference;
        previousDislike = currentDislike;

        currentPreference = null;
        currentDislike = null;

        while (currentPreference == null)
        {
            string newPref = bubbleTypes[Random.Range(0, bubbleTypes.Count)];

            if (newPref != previousPreference)
            {
                currentPreference = newPref;
            }
        }

        while (currentDislike == null)
        {
            string newDislike = bubbleTypes[Random.Range(0, bubbleTypes.Count)];

            if (newDislike != previousDislike && newDislike != currentPreference)
            {
                currentPreference = newDislike;
            }
        }

    }

    public string GetPreference()
    {
        return currentPreference;
    }

    public string GetDislike()
    {
        return currentDislike;
    }

}
