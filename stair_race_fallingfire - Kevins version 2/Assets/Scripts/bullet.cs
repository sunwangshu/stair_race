using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	private Rigidbody2D rb;

    private float timerFloat;

    public AudioClip impact;
    AudioSource source;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
		rb.AddTorque(1);
	}
	
	// Update is called once per frame
	void Update () {
        timerFloat += 1 * Time.deltaTime;
        if(timerFloat > 3.2)
        {
            Destroy(gameObject);
        }
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
            source.PlayOneShot(impact, .8f);
            Destroy (gameObject, 0.1f);
		}
	}
}
