using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawner : MonoBehaviour
{
    //vector3 representing the object's position and boolean representing if an object is already there
    private List<Transform> spawningPositions = new List<Transform>();
    private List<bool> presences = new List<bool>();
    static public int barrelCounter;
    public static int holeCounter;

    [SerializeField] public float timeMod = 1.001f;
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
        for (int i = 0; i < transform.childCount; i++)
        {
            spawningPositions.Add(transform.GetChild(i));
            presences.Add(false);
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
                Transform position = spawningPositions[random];
                bool present = presences[random];
                if (!present)
                {
                    Instantiate(baril, position);
                    //prend pour acquis que la copie lors de tuple est seulement de surface
                    presences[random] = true;
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
                Transform position = spawningPositions[random];
                bool present = presences[random];
                if (!present)
                {
                    Instantiate(baril, position);
                    //prend pour acquis que la copie lors de tuple est seulement de surface
                    presences[random] = true;
                    break;
                }

            }
        }





    }
}
