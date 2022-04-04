using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class TimeManager : MonoBehaviour
{

    //IMPORTANT change remaining time t0 90f
    public static float _remainingTime = 10f;
    private float _initialTime;

    public static float _elapsedTime = 0f;
    [SerializeField] public GameObject Water;
    [SerializeField] public TextMeshProUGUI timeText;
    [SerializeField] public float holeScaling = 1.002f;
    [SerializeField] private int waterDelta = 5;
    // Start is called before the first frame update

    private void Awake()
    {
        _initialTime = _remainingTime;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        foreach (Transform child in Water.transform)
        {
            child.transform.position -= new Vector3(0, waterDelta * (_initialTime - _remainingTime) / _initialTime, 0);
        }
        

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
