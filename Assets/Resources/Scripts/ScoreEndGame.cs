using UnityEngine;
using TMPro;
public class ScoreEndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreTime;
    private float timeDuration = KeepOvertime.timeDuration;
    private int seconds;
    private void Awake()
    {
        seconds = (int)timeDuration % 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTime.text = "You have delayed the inevitable for " + ((int)timeDuration / 60).ToString() + ":" + (seconds < 10 ? "0" : "") + (seconds.ToString());
    }
}
