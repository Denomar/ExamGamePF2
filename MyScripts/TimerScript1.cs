using UnityEngine;
using System.Collections;

public class TimerScript1 : MonoBehaviour
{
    public float timer;
    public Light l;
    public Renderer r;
    public float spawnX, spawnY;


    // Update is called once per frame
    void Update()
    {

        if (timer < 5)
        {
            //  col.gameObject.name == "hero"
            // if ()
            // {
            // timer += Time.deltaTime;
            //Destroy(col.gameObject);
            // }
        }
        if (timer > 5)
        {

            {
                //  l.color = Color.red;
                r.material.color = Color.red;
                //  Destroy(gameObject);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)//&& col.gameObject.name == "platform"
    {
        if (timer < 5 && col.gameObject.name == "platform")
        {
            Destroy(col.gameObject);
           // transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            Debug.Log("IF WORKED!!! " + col.gameObject.name);
        }

        Debug.Log("IN collision with " + col.gameObject.name);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (timer < 5 && col.gameObject.tag == "MainHero")
        {
            Destroy(col.gameObject);
            Debug.Log("IF WORKED!!! " + col.gameObject.name);
        }

        Debug.Log("IN collision with " + col.gameObject.name);
    }
}
