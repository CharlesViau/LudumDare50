using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawner : MonoBehaviour
{
    //vector3 representing the object's position and boolean representing if an object is already there
    private List<Transform> spawningPositions;
    private List<bool> present;
    static public int barrelCounter;
    public static int holeCounter;

    [SerializeField] public float timeMod = 1.2f;
    private float timeCounter = 0f;
    private float timeTreshold = 3;
    //relative wood probability is the probability to get wood over hole /1000
    [SerializeField] public int relativeWoodProbability = 400;
    [SerializeField] public GameObject baril;
    [SerializeField] public GameObject hole;
    [SerializeField] public int maxBarrels = 7;
    [SerializeField] public int maxHoles = 10;
    

    public void Awake()
    {
        foreach (Transform child in transform)
        {
            
            spawningPositions.Add((child, false));

                
            
        }
        //remove
        Debug.Log(spawningPositions);
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
        Debug.Log("Generation tried");
        int value = Random.Range(0, 1000);
        if (value >= relativeWoodProbability)
        {
            if (barrelCounter >= maxBarrels)
            {
                return;
            }
            while (true)
            {
                int random = Random.Range(0, spawningPositions.Count - 1);
                //generating wood
                (Transform position, bool present) tuple = spawningPositions[random];
                if (!tuple.present)
                {
                    Instantiate(baril, tuple.position);
                    //prend pour acquis que la copie lors de tuple est seulement de surface
                    tuple.present = true;
                    break;
                }

            }
        }
        else
        {
            if (holeCounter >= maxHoles)
            {
                return;
            }
            while (true)
            {
                int random = Random.Range(0, spawningPositions.Count - 1);
                //generating a hole
                (Transform position, bool present) tuple = spawningPositions[random];
                if (!tuple.present)
                {
                    Instantiate(hole, tuple.position);
                    //prend pour acquis que la copie lors de tuple est seulement de surface
                    tuple.present = true;
                    break;
                }

            }
        }





    }
}
