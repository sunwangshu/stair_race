using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	private Rigidbody2D rb;

    private float timerFloat;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(1);
	}
	
	// Update is called once per frame
	void Update () {
        timerFloat += 1 * Time.deltaTime;
        if(timerFloat > 4)
        {
            Destroy(gameObject);
        }
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject, 0.1f);
		}
	}
}
