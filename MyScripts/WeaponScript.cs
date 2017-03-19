using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _startBulletPoint;
    [SerializeField] private float _power;
    [SerializeField] private bool _inverse;
    private bool _globalShoot;


    private float timeToFire = 0;

    private Transform firePoint;
	//Use this for initialization
	void Start ()
	{


	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (fireRate == 0)
	    {
	        if ((Input.GetButtonDown("Fire1") && !transform.parent.tag.Equals("Enemy")) || _globalShoot)
	        {
	            Shoot();
	        }


	    }
	    else
	    {
	        if (((Input.GetButton("Fire1")&& !transform.parent.tag.Equals("Enemy")) || _globalShoot) && Time.time > timeToFire)
	        {
	            timeToFire = Time.time + 1 / fireRate;
	            Shoot();
	        }


	    }

	    _globalShoot = false;

	}

    void Awake()
    {
        firePoint = transform.FindChild("Firepoint");
        if (firePoint == null)
        {
             //Debug.LogError("No Firepoint");

        }

    }

    void Shoot()
    {
        GameObject b = Instantiate(_bulletPrefab, _startBulletPoint.transform.position,
            _startBulletPoint.transform.rotation) as GameObject;

        if (_inverse)
        {
            b.transform.eulerAngles = new Vector3(0, transform.parent.localScale.x < 0 ? 0 : 180);
            b.GetComponent<Rigidbody2D>().velocity =
                new Vector2(transform.parent.localScale.x < 0 ? _power : -_power, 0);
        }
        else
        {
            b.transform.eulerAngles = new Vector3(0, transform.parent.localScale.x < 0 ? 180 : 0);
            b.GetComponent<Rigidbody2D>().velocity =
                new Vector2(transform.parent.localScale.x < 0 ? -_power : _power, 0);
        }
        Destroy(b, 4);
    }

    public void GloabalShoot()
    {
        _globalShoot = true;

    }


}

public enum WeaponType
{
    Pistol,
    Autogun
}
