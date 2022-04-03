using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarilComponent : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem woodParticles;

    [SerializeField] public GameObject wood;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            Destroy();
    }

    public void Destroy()
    {
        Instantiate(woodParticles, transform.position, Quaternion.identity);
        Instantiate(wood);
        GameObject.Destroy(this);
        
        


    }
}
