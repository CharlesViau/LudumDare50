using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float CurrentTime = 120f;
    private readonly float _initialTime = CurrentTime;

    private static float _elapsedTime = 0f;
    [SerializeField] public GameObject Water;
    private int waterDelta = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        _elapsedTime += Time.deltaTime;
        //update UI element text

        //make water go up according to time
        //the function I made is complete trash - if currentTime goes above initialTime the water goes down and everything fucks up
        Water.transform.position -= new Vector3(0, waterDelta * (_initialTime - CurrentTime) / _initialTime, 0);
        
        //make maxHoles scale up as time advances

        if (CurrentTime <= 0)
        {
            //game over
        }
    }

    public void GameOver()
    {
        //impl�menter!
    }

}
