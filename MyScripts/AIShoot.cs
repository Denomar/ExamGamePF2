using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WeaponScript))]
public class AIShoot : MonoBehaviour
{

    private WeaponScript _weapon;

    private void Awake()
    {
        _weapon = GetComponent<WeaponScript>();

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            _weapon.GloabalShoot();
        }
    }
}
