using UnityEngine;
using TMPro;
public class ScoreEndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreTime;
    private float timeScoreDuration = KeepOvertime.timeDuration;
    private int seconds;
    private void Awake()
    {
        seconds = (int)timeScoreDuration % 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTime.text = "You have delayed the inevitable for " + ((int)timeScoreDuration / 60).ToString() + ":" + (seconds < 10 ? "0" : "") + (seconds.ToString());
    }
}
