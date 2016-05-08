using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
    //[SerializeField] private Texture[] textures;
    [HideInInspector] public bool jump = false;
    public float moveForce2 = 30f;
    public float maxSpeed2 = 80f;
    public float jumpForce2 = 390f;
	public GameObject stairblock; 

    public bool grounded2;

    private Rigidbody2D rb;

    private TextManager textManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        textManager = GameObject.Find("Canvas").GetComponent<TextManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Player2Up") && grounded2)
        {
            rb.AddForce(new Vector2(0f, jumpForce2));
            grounded2 = false;
        }
        if (Input.GetButtonDown("Player2Fire"))
        {
            GameObject player1 = GameObject.Find("Player1");
            float x = player1.transform.position.x;
            float y = player1.transform.position.y;
            Instantiate(stairblock, new Vector3(x + 10, y + 20, 0), Quaternion.Euler(new Vector3(0, 0, 40)));
        }
        if (Input.GetButtonDown("Player2Right"))
        {
            float h = Input.GetAxis("Player2Right") * 8;
            if (h * rb.velocity.x < maxSpeed2)
            {
                rb.AddForce(Vector2.right * h * moveForce2);
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed2)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed2, rb.velocity.y);
            }
        }
    }
    
    /*for continuous movement to the right
    void FixedUpdate()
    {
        float h = Input.GetAxis("Player2Right");
        if (h * rb.velocity.x < maxSpeed2)
        {
            rb.AddForce(Vector2.right * h * moveForce2);
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed2)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed2, rb.velocity.y);
        }
    }*/

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stairs")
        {
            grounded2 = true;
        }
    }

}