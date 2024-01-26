using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;

    public void UpdateScoreAndLevel()
    {
        levelText.text = $"Level {Stats.Level}";
        scoreText.text = "Score " + Stats.Score.ToString("D4");
    }

    public void UpdateHp(int hp)
    {
        hpText.text = $"HP: {hp}";
    }
}
