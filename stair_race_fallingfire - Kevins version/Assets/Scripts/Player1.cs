using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour
{
    //[SerializeField] private Texture[] textures;
    [HideInInspector] public bool jump = false;
    public float moveForce = 10f;
    public float maxSpeed = 10f;
    public float jumpForce = 300f;

    public bool grounded;

    private Rigidbody2D rb;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Player1Up") && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }
    }

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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stairs")
        {
            grounded = true;
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