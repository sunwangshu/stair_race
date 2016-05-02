using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
    //[SerializeField] private Texture[] textures;
    [HideInInspector] public bool jump = false;
    public float moveForce2 = 10f;
    public float maxSpeed2 = 10f;
    public float jumpForce2 = 300f;

    public bool grounded2;

    private Rigidbody2D rb;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Player2Up") && grounded2)
        {
            rb.AddForce(new Vector2(0f, jumpForce2));
            grounded2 = false;
        }
    }

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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stairs")
        {
            grounded2 = true;
        }
    }

        /*void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "prop_powerCube")
            {
                Destroy(col.gameObject);
            }
        }*/
    }