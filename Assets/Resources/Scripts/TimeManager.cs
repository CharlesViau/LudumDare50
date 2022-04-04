using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class TimeManager : MonoBehaviour
{
    

    //IMPORTANT change remaining time t0 90f
    public static float _remainingTime;
    public static readonly float _initialTime = 90f;

    public static float _elapsedTime = 0f;
    [SerializeField] public TextMeshProUGUI timeText;
    [SerializeField] public float holeScaling = 1.002f;
    // Start is called before the first frame update

    private void Awake()
    {
        _remainingTime = _initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        Player.hammerTimer -= Time.deltaTime;
        _remainingTime -= Time.deltaTime;
        _elapsedTime += Time.deltaTime;

        //updating UI element text
        int roundedTime = (int)_remainingTime;
        int seconds = (int)roundedTime % 60;

        timeText.text = ((int)roundedTime / 60).ToString() + ":" + (seconds < 10 ? "0" : "") + (seconds.ToString());

        if (_remainingTime <= 10f)
            timeText.color = Color.red;
        else
            timeText.color = Color.white;

        //make water go up according to time
        //the function I made is complete trash - if currentTime goes above initialTime the water goes down and everything fucks up
        
        

        //make maxHoles scale up as time advances



        if (_remainingTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("FinalScene");
    }

}
