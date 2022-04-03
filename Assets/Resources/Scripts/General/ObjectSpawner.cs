using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawner : MonoBehaviour
{
    //vector3 representing the object's position and boolean representing if an object is already there
    private HashSet<(Vector3 position, bool present)> spawningPositions;
    static int woodCounter;
    public static int holeCounter;

    [SerializeField] public float timeMod = 1.2f;
    private float timeCounter = 0f;
    private float timeTreshold = 10;
    //relative wood probability is the probability to get wood over hole /1000
    [SerializeField] public int relativeWoodProbability = 200;
    [SerializeField] public GameObject baril;
    public void Awake()
    {
        foreach(Transform child in transform)
        {
            foreach (Transform subchild in child.transform)
            {
                spawningPositions.Add((subchild.position, false));
                //remove later
                Debug.Log(spawningPositions);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= timeTreshold)
        {
            timeTreshold /= timeMod;
            timeCounter -= timeTreshold;
            GenerateItem();
        }
    }

    void GenerateItem()
    {
        int value = Random.Range(0, 1000);
        if (value >= relativeWoodProbability)
        {
            //generating wood
             Instantiate()
        }
        else
        {
            //ge
        }

    }
}
