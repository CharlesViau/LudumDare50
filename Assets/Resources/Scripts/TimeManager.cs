using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public static float remainingTime = 120f;
    private readonly float _initialTime = remainingTime;

    private static float _elapsedTime = 0f;
    [SerializeField] public GameObject Water;
    [SerializeField] public Text timeText;
    private int waterDelta = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        _elapsedTime += Time.deltaTime;

        //updating UI element text
        int roundedTime = (int)remainingTime;
        timeText.text = ((int)roundedTime/60).ToString() + "\"" + ((int)roundedTime%60).ToString();

        //make water go up according to time
        //the function I made is complete trash - if currentTime goes above initialTime the water goes down and everything fucks up
        Water.transform.position -= new Vector3(0, waterDelta * (_initialTime - remainingTime) / _initialTime, 0);
        
        //make maxHoles scale up as time advances

        if (remainingTime <= 0)
        {
            //game over
        }
    }

    public void GameOver()
    {
        //impl�menter!
    }

}
