using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreShow : MonoBehaviour
{
    public Text HS;
    void Start()
    {
        HS.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
