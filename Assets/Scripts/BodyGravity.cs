using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGravity : MonoBehaviour
{
    public PlanetScript attractorPlanet;
    private Transform bodyTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        bodyTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(bodyTransform);
        }
    }
}
