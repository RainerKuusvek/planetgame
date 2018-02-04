using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class gravitybody : MonoBehaviour {
    gravityattractor planet;

        void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("planet").GetComponent<gravityattractor>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        planet.Attract(transform);
    }
}
