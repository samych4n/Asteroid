using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour {
    public TextMeshProUGUI text;

    private void Start()
    {
        Score.ChangeScore += ChangeScore;
        text.text = "00.000";
    }

    private void ChangeScore(int score)
    {
        text.text = ((float)score /1000f).ToString("00.000");
    }
    private void OnDestroy()
    {
        Score.ChangeScore -= ChangeScore;
    }
}
