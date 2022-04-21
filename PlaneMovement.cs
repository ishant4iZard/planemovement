using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

    [SerializeField] private float finalspeed = 100000f;
    [SerializeField] Animator flaps;
    [SerializeField] Animator propellor;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float horSpeed = 10f;
    private float verSpeed = 0f;
    [SerializeField] private float verSpeedFinal= 100f;
    Rigidbody rb;
    

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        propellor.SetTrigger("EngineOn");
    }

    private void FixedUpdate()
    {
        planemovement();
    }

    void planemovement()
    {

        if (transform.rotation == Quaternion.Euler(0f, 90f, 0f))
        {
            rb.AddForce(new Vector3(horSpeed, verSpeed, 0));

            if (horSpeed <= finalspeed)
            {
                horSpeed += acceleration * Time.deltaTime;
            }
        }
        else
        {
            rb.velocity = (new Vector3(0, 0, 0));
            if (transform.position.z < 137.5f)
                rb.velocity = (new Vector3(0, 0, 10f));
            else {
                transform.Rotate(Vector3.up * 10f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        flaps.SetTrigger("Flapsdown");
        verSpeed = verSpeedFinal;

    }
}
