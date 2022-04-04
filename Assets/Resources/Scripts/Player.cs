using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using General;

public class Player : MonoBehaviour, IInteract, IMove
{
    public bool hammerActive;
    public static float hammerTimer;
    [SerializeField] public readonly float maxHammerTimer = 15f;
    public Inventory Inventory { get; set; }
    private const int InventoryCapacity = 3;
    private Transform _transform1;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    [SerializeField] public float speed;
    [SerializeField] public float turningSpeed;
    private float _turnSmoothVelocity;

    private readonly int _speedHash = Animator.StringToHash("Speed");

    private const string InteractAction = "Fire1";
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    private void Awake()
    {
        Inventory = new Inventory(InventoryCapacity);
        _transform1 = transform;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (hammerTimer <= 0)
            hammerActive = false;
        if (Input.GetButtonDown(InteractAction))
        {
            Interact();
        }
        
        
    }

    private void FixedUpdate()
    {
        if (new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical)).normalized is var direction &&
            direction.magnitude >= 0.1f)
        {
            Move(direction);
            //Debug.Log(animator.GetFloat(_speedHash));
        }
        
        animator.SetFloat(_speedHash, direction.normalized.magnitude/speed);
    }

    public void Interact()
    {
    }

    public void Move(Vector3 direction)
    {
        var smoothAngle =
            Mathf.SmoothDampAngle(_transform1.eulerAngles.y, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg,
                ref _turnSmoothVelocity, turningSpeed);

        _transform1.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

        rb.MovePosition(_transform1.position + direction * speed * Time.deltaTime);
    }
}