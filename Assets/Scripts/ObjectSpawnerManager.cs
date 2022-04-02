using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class ObjectSpawnerManager : MonoManager<ObjectSpawner, ObjectSpawnerManager>
{
    //manages floor spawners
    public override void Init()
    {
        obj = Object.FindObjectOfType<ObjectSpawner>();
        base.Init();
    }
}
