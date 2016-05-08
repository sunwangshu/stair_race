using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour
{
    //[SerializeField] private Texture[] textures;
    [HideInInspector] public bool jump = false;
    public float moveForce = 30f;
    public float maxSpeed = 80f;
    public float jumpForce = 390f;
	public GameObject stairblock; 

    public bool grounded;

    private Rigidbody2D rb;

    private TextManager textManager;    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        textManager = GameObject.Find("Canvas").GetComponent<TextManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Player1Up") && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }
        if (Input.GetButtonDown("Player1Fire")) {
                GameObject player2 = GameObject.Find("Player2");
                float x = player2.transform.position.x;
                float y = player2.transform.position.y;
                Instantiate(stairblock, new Vector3(x + 10, y + 20, 0), Quaternion.Euler(new Vector3(0, 0, 40)));
        }
        if (Input.GetButtonDown("Player1Right"))
        {
            float h = Input.GetAxis("Player1Right")*8;
            if (h * rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector2.right * h * moveForce);
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }
        }
    }

    /*for continuous movement to the right
    void FixedUpdate()
    {
        float h = Input.GetAxis("Player1Right");
        if (h * rb.velocity.x < maxSpeed)
        {
            rb.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }*/

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stairs")
        {
            grounded = true;
        }
    }

}