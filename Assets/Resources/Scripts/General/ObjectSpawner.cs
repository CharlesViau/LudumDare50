using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawner : MonoBehaviour
{
    private HashSet<Vector3> spawningPositions;
    public void FixedRefresh()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        foreach(Transform child in transform)
        {
            foreach (Transform subchild in child.transform)
            {
                spawningPositions.Add(subchild.position);
                //remove later
                Debug.Log(spawningPositions);
            }
        }
    }

    public void PostInit()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
