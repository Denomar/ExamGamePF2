using UnityEngine;
using System.Collections;

public class MobsAI_Script : MonoBehaviour
{

    public float platformerTargetDistance;

    public float mobLookDistance;

    public float attackDistance;

    public float mobMovementSpeed;

    public float damping;

    public Transform platformerTarget;

    Rigidbody2D theRigidbody;

    Renderer myRender;
	// Use this for initialization
	void Start ()
	{

	   // myRender.GetComponent<Renderer>();
	    theRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    platformerTargetDistance = Vector3.Distance(platformerTarget.position,transform.position);
	    if (platformerTargetDistance < mobLookDistance)
	    {
	      //  myRender.material.color = Color.yellow;
	        lookAtPlayer();
	        print("Look at Player");
	    }
	    if (platformerTargetDistance < attackDistance)
	    {
	        attackPlease();
	        print("attack");
	    }
	    else
	    {
	     //   myRender.material.color = Color.blue;
	    }

	}

    void lookAtPlayer()
    {
Quaternion rotation  = Quaternion.LookRotation(platformerTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attackPlease()
    {
         // theRigidbody.AddForce(transform.forward*mobMovementSpeed);
    }
}
