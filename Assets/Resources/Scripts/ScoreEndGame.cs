using UnityEngine;
using TMPro;
public class ScoreEndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreTime;

    // Start is called before the first frame update
    void Start()
    {

        scoreTime.text = "Your score was " + KeepOvertime.timeDuration.ToString() + "points.";
    }
}
