    using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour
{

    [SerializeField] private WeaponScript _autogun;
    [SerializeField] private WeaponScript _pistol;
    private WeaponScript _currentWeapon;
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float score;
	public float move;
    public float spawnX, spawnY;
	private GameObject star;
	// Use this for initialization
	void Start () {
        spawnX = transform.position.x;
        spawnY = transform.position.y;
	    SetCurrentWeapon(_autogun);
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){
		if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {

			GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();



		if (Input.GetKey(KeyCode.Escape))
		{
            Application.LoadLevel("MenuScene");
		}

		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
          //  Application.LoadLevel("MenuScene");

        }
        if (Input.GetKey(KeyCode.F))
        {
            // Application.LoadLevel("MenuScene");
            Application.Quit();
        }

    }
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void ChangeWeapon(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Autogun:
                SetCurrentWeapon(_autogun);
                break;

            case WeaponType.Pistol:
                SetCurrentWeapon(_pistol);
                break;

        }
    }

    private void SetCurrentWeapon(WeaponScript weapon)
    {
        if (_currentWeapon)
        {
            _currentWeapon.gameObject.SetActive(false);
        }
        _currentWeapon = weapon;
        _currentWeapon.gameObject.SetActive(true);
    }

	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.name == "dieCollider")&&(col.gameObject.name == "saw"))
						Application.LoadLevel (Application.loadedLevel);



       if(col.gameObject.CompareTag("acorn"))
        {
            score++;
            Destroy (col.gameObject);

        }


		if (col.gameObject.CompareTag("NextLevel")) {
			 Application.LoadLevel ("L2");
				}
        if (col.gameObject.CompareTag("toInstance"))
        {
            //

            Application.LoadLevel("Instance");
           // Debug.Log(col.gameObject.name);
          
        }
        if (col.gameObject.CompareTag("toLevel2"))
        {
            //

            Application.LoadLevel("L2");
            // Debug.Log(col.gameObject.name);

        }

        if (col.gameObject.CompareTag("toSecretArea"))
        {
            Application.LoadLevel("IceAgeStyleArea");
        }
	    if (col.gameObject.CompareTag("toSecretInstanceLevel2"))
	    {
	        Application.LoadLevel("Area2");

	    }
        //void OnCollisionEnter2D(Collision2D col)
        // {
        if (col.gameObject.CompareTag("Destroyer"))//|| col.gameObject.name == "dieCollider"
        {
            Destroy(gameObject);
            //  transform.Rotate(new Vector3(0f, 0f, 1f));
            // spawnX = transform.position.x;
            //spawnY = transform.position.y;  
            Application.LoadLevel(Application.loadedLevel);
            Debug.Log(gameObject.name + "Collide");
        }
        Debug.Log(col.gameObject.name);
        //transform.position = new Vector3(spawnX, spawnY, transform.position.z);
      
    }

	void OnGUI(){
				GUI.Box (new Rect (0, 0, 100, 100), "Stars: " + score);
		}
    

    }


		
//}
