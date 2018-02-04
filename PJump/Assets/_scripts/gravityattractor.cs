using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityattractor : MonoBehaviour
{

    public float gravity = -10f;
    public Vector3 targetDir;
    public float radius = 20f;

    public void Attract(Transform body)
    {
        targetDir = (body.position - transform.position).normalized;

        Vector3 bodyUp = body.up;
        body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation;
        if ((body.position - transform.position).magnitude > radius)
        {
            body.GetComponent<Rigidbody>().AddForce(targetDir * gravity);
        }
    }
}
