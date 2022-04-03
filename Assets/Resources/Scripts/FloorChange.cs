using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChange : MonoBehaviour
{
    [SerializeField] public Player _player;
    [SerializeField] public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.transform.position = destination.position;
        }
    }

    //mettre les trigger sur les box colliders


}
