using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Item
{
    // Start is called before the first frame update
    public override void Interact(IInteract person)
    {
        if (TryGetComponent<Player>(out var player))
        {
            player.hammerActive = true;
            Player.hammerTimer = player.maxHammerTimer;
            Destroy(gameObject);
        }
    }

    public void Interact(Player person)
    {
        Debug.Log("wtf");
        person.hammerActive = true;
        Player.hammerTimer = person.maxHammerTimer;
        Destroy(gameObject);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Interact(other.gameObject.GetComponent<Player>());
    }
    }
