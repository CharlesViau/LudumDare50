using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class Player : MonoBehaviour, IInteract
{
    public Inventory Inventory { get; set; }
    [SerializeField] private int inventoryCapacity;
    //ajouté par Nath
    public Rigidbody rb;
    //le premier étage correspond à currentStage = 0;
    public int currentStage = 1;
    //liste contenant les positions des 4 empty "PlayerSpawn"; il faudrait l'initialiser dans Init(); Respawn() utilise cette liste pour modifier la position du joueur lors des changements d'étage
    private List<Vector3> spawnTransforms;

    private string staircaseUsed = "up";

    public void Awake()
    {
        Inventory = new Inventory(inventoryCapacity);
    }

    public void Interact()
    {
        
    }

    public void upStage()
    {
        if (currentStage <= 1)
        {
            currentStage += 1;
            staircaseUsed = "up";
            Respawn();
        }
        //faire monter d'étage; pas de else, on est juste con si la fonction est mal utilisée
    }
    
    public void downStage()
    {
        if (currentStage >= 1)
        {
            currentStage -= 1;
            staircaseUsed = "down";
            Respawn();
        }
        //faire descendre d'étage; pas vraiment besoin de else ici non plus je crois
    }

    public void Respawn()
    {


        //faire réapparaître le joueur à l'étage correspondant à currentStage et à l'escalier correspondant à staircaseUsed
    }
}