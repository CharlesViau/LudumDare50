using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticValues : MonoBehaviour
{
    void Start()
    {
        Reset();
    }
    public static void Reset()
    {
        TimeManager._remainingTime = TimeManager._initialTime;
        TimeManager._elapsedTime = 0;
        UIBehaviour.staticWoodCount = 0;
    }
}
