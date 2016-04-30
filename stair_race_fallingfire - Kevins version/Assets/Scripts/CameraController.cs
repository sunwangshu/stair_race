using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        else
        {
            Debug.Log("Player not set correctly. Please check if tag is set correctly.");
        }
    }
}
