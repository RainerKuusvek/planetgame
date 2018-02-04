using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    public float walkSpeed = 8f;
    public RigidbodyInterpolation interpolation;
    Rigidbody enemyrb;
    Vector3 moveAmount;
    Vector3 smoothMoveV;
    public Transform player;
    public gravityattractor planet;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyrb = GetComponent<Rigidbody>();
    }

    Vector3 vec;

    void FixedUpdate()
    {
        //calc vector from player to enemy
        Vector3 diff = player.position - transform.position;

        //project onto local horizon plane to get a direction
        Vector3 movedirection = Vector3.ProjectOnPlane(diff, transform.position - planet.transform.position).normalized;

        moveAmount = movedirection * walkSpeed;
        vec = movedirection;
        //move
        enemyrb.MovePosition(enemyrb.transform.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + vec * 10);
    }



    //   public void StopFollowingTarget()
    //   {
    //       agent.stoppingDistance = 0;
    //       target = null;
    //       agent.updateRotation = true;
    //       anim["Walk"].enabled = false;
}
 //   void FaceTarget()
 //   {
  //      Vector3 direction = (target.position - transform.position).normalized;
   //     Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
//    }
//}
