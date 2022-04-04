using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChange : MonoBehaviour
{
    [SerializeField] public Player _player;
    [SerializeField] public Transform destination;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.transform.position = destination.position;
        }
    }

    //mettre les trigger sur les box colliders


}
