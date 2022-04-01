using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public int jumpForce;
    [SerializeField]
    public int speed;

    private Rigidbody rb;
    bool isGrounded;
    //avant start
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //ce qui n'est pas de la physique
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale += new Vector3(2, 2, 2);
        }
    }
    //mieux pour la physique
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*speed);

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            isGrounded = true;
    }
    
    public void Die()
    {
        Debug.Log("You died!");

    }

    //
}
