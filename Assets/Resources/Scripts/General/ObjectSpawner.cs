using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //vector3 representing the object's position and boolean representing if an object is already there
    private readonly List<Transform> _spawningPositions = new List<Transform>();
    private readonly List<bool> _presences = new List<bool>();
    public static int BarrelCounter;
    public static int HoleCounter;

    [SerializeField] public float timeMod = 1.001f;
    private float _timeCounter;

    private static float _timeThreshold = 3;

    //relative wood probability is the probability to get wood over hole /1000
    [SerializeField] public int relativeWoodProbability = 400;
    [SerializeField] public GameObject baril;
    [SerializeField] public GameObject hole;
    [SerializeField] public int maxBarrels = 7;
    [SerializeField] public int maxHoles = 10;


    public void Awake()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            _spawningPositions.Add(transform.GetChild(i));
            _presences.Add(false);
        }
    }
    
    void Update()
    {
        _timeCounter += Time.deltaTime;
        if (!(_timeCounter >= _timeThreshold)) return;
        _timeCounter -= _timeThreshold;
        _timeThreshold /= timeMod;
        GenerateItem();
    }

    private void GenerateItem()
    {
        Debug.Log("Generation tried");
        var woodChance = Random.Range(0, 1000);

        int randomPosition;
        do
        {
            randomPosition = Random.Range(0, _spawningPositions.Count - 1);
        } while (_presences[randomPosition]);
       
        
        if (woodChance >= relativeWoodProbability && BarrelCounter <=maxBarrels)
        {
            Instantiate(baril, _spawningPositions[randomPosition]);
            _presences[randomPosition] = true;
        }
        
        else if(HoleCounter <= maxHoles)
        {
            Instantiate(hole,  _spawningPositions[randomPosition]);
            _presences[randomPosition] = true;
        }
        
    }
}