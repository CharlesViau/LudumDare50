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
    [SerializeField] private int inventoryCapacity;
  
    public Rigidbody rb;
    [SerializeField]private const float Speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        Inventory = new Inventory(inventoryCapacity);
        _input = new UserInput(this);
        
        _input.Init();
    }

    private void Start()
    {
        _input.PostInit();
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
        rb.AddForce(move * Speed);
    }

   
}