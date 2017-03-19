using UnityEngine;
using System.Collections;

public class SquirrelScript : MonoBehaviour {

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
    private GameObject acorn;
    // Use this for initialization
    void Start()
    {
        spawnX = transform.position.x;
        spawnY = transform.position.y;
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        move = Input.GetAxis("Horizontal");

    }



    // Use this for initialization
   
    // Update is called once per frame
    void Update() {

        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();



        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "toLevel2")
        {
            //

            Application.LoadLevel("L2");
            // Debug.Log(col.gameObject.name);
        }
        if (col.gameObject.name == "acorn")
        {
            score++;
            Destroy(col.gameObject);
            Debug.Log(col.gameObject.name);
        }

        if (col.gameObject.CompareTag("toSecretInstanceLevel2"))
        {
            Application.LoadLevel("Area2");

        }

    }
        void Flip(){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Acorns: " + score);
    }

}

