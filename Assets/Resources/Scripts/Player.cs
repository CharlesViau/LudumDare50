using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using General;

public class Player : MonoBehaviour, IInteract, IMove
{
    public Inventory Inventory { get; set; }
    private UserInput _input;
    private AnimationStatePlayer _animationStatePlayer;
    [SerializeField] private int inventoryCapacity;
  
    public Rigidbody rb;
    public Animator animator;
    
    [SerializeField]public float speed = 5;

    private void Awake()
    {
        Inventory = new Inventory(inventoryCapacity);
        _input = new UserInput(this);
        _animationStatePlayer = new AnimationStatePlayer(this);
        
        _input.Init();
        _animationStatePlayer.Init();
    }

    private void Start()
    {
        _input.PostInit();
        _animationStatePlayer.PostInit();
    }

    private void Update()
    {
        _input.Refresh();
    }

    private void FixedUpdate()
    {
        _input.FixedRefresh();
    }

    public void Interact()
    {
        
    }

    public void Move(Vector3 move)
    {
        rb.AddForce(move * speed);
    }

   
}