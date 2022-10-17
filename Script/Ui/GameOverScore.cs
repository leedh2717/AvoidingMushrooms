using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text bestScore;
    public Text score;
    void Start()
    {
        GameManager.instance.ScoreCompare();
        bestScore.text = GameManager.instance.gameData.bestScore.ToString();
        score.text = GameManager.instance.Score.ToString();        
    }
}
