using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            Destroy(gameObject, 0.05f);
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject, 0.5f);
            Destroy(gameObject, 0.05f);
        }
    }
}
