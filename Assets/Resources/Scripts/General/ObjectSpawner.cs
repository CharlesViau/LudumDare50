using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawner : MonoBehaviour
{
    //vector3 representing the object's position and boolean representing if an object is already there
    private List<(Transform position, bool present)> spawningPositions;
    static int woodCounter;
    public static int holeCounter;

    [SerializeField] public float timeMod = 1.2f;
    private float timeCounter = 0f;
    private float timeTreshold = 10;
    //relative wood probability is the probability to get wood over hole /1000
    [SerializeField] public int relativeWoodProbability = 200;
    [SerializeField] public GameObject baril;
    [SerializeField] public GameObject hole;
    public void Awake()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform subchild in child.transform)
            {
                spawningPositions.Add((subchild, false));
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
            while (true)
            {
                int random = Random.Range(0, spawningPositions.Count - 1);
                //generating wood
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
