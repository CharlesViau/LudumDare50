using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float currentTime = 120f;
    private float initialTime = currentTime;

    public static float elapsedTime = 0f;
    [SerializeField] public GameObject Water;
    private Transform initialWaterPosition;
    private int waterDelta = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        elapsedTime += Time.deltaTime;
        //update UI element text

        //make water go up according to time
        //the function I made is complete trash - if currentTime goes above initialTime the water goes down and everything fucks up
        Water.transform.position -= new Vector3(0, waterDelta * (initialTime - currentTime) / initialTime, 0);
        
        //make maxHoles scale up as time advances

        if (currentTime <= 0)
        {
            //game over
        }
    }

    public void GameOver()
    {
        //implémenter!
    }

}
