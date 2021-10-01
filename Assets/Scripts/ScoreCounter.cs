using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public int bonus;

    void Start()
    {
        Score = 0;
        bonus = 1;
    }

    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        ScoreText.text = Score.ToString();
    }

    public void AddBonus()
    {
        bonus++;
    }

    public void Count()
    {
        Score += bonus;
    }
}
