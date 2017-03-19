using UnityEngine;
using System.Collections;
using Pathfinding;

 [RequireComponent(typeof(Rigidbody2D))]
 [RequireComponent(typeof(Seeker))]
public class bossAI_Script : MonoBehaviour
 {

     public Transform target;
     public float updateRate = 2f;

     private Seeker _seeker;
     private Rigidbody2D _rb;

     public Path path;
     public float speed = 300f;

     public ForceMode2D fMode;

     [HideInInspector] public bool pathIsEnded = false;

     public float nextWaypointDistance = 3;

     private int currentWaypoint = 0;

	// Use this for initialization
	void Start ()
	{


	    _rb = GetComponent<Rigidbody2D>();
	    _seeker = GetComponent<Seeker>();
	    if (target == null)
	    {
	        Debug.LogError("Where is player");
	        return;
	    }
	    _seeker.StartPath(transform.position, target.position, OnPathComplete);
	    StartCoroutine(UpdatePath());
	}

     IEnumerator UpdatePath()
     {
         if (target == null)
         {
             yield return new WaitForSeconds(1f/updateRate);
             StartCoroutine(UpdatePath());
             path = null;
         }
         else
         {
             path = _seeker.StartPath(transform.position, target.position, OnPathComplete);
             yield return new WaitForSeconds(1f/updateRate);
             StartCoroutine(UpdatePath());
         }
     }
     public void OnPathComplete(Path p)
     {
         Debug.Log("We got a path" + p.error);
         if (!p.error)
         {
             path = p;
             currentWaypoint = 0;

         }
     }
	// Update is called once per frame
	void FixedUpdate ()
	{

	   if (target == null)
	    {
	        return;

	    }
	    if (path == null)
	    {
	        return;
	    }
	    if (currentWaypoint >= path.vectorPath.Count)
	    {

	        if (pathIsEnded)
	        {
	            return;


	        }
	        Debug.Log("Path is ended");
	        pathIsEnded = true;
	        return;
	    }
	    pathIsEnded = false;


	    Vector3 dir  = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed* Time.fixedDeltaTime;

	    _rb.AddForce(dir, fMode);
	    //_rb.velocity = dir;
	    //Debug.Log("Add force");

	    float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
	  /* if (dist < nextWaypointDistance)
	    {
	        currentWaypoint++;
	        return;
	    }*/

	}
     public void OnTriggerEnter( Collider2D col)
     	    {
     	        if (col.gameObject.CompareTag("robot"))
     	        {

     	            Destroy(gameObject);

     	        }




     	    }

}
