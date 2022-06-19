using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManeger : MonoBehaviour
{
    public static ScoreManeger s;
    public TextMeshProUGUI text;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        if (s == null)
            s = this;
    }
    public void ChangeScore(int score)
    {
        this.score += score;
        text.text = $"Score:{this.score}";
    }

}
