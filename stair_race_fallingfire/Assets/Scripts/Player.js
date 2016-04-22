#pragma strict

var playing: boolean = false;
//var star: GameObject;

var key1 : KeyCode;
var key2: KeyCode;
var key1Once: boolean = false;
var key2Once: boolean = false;

//jump
var jump: KeyCode;
var jumpTime: float;
var isJumping: boolean = false;
//var fallingfire: GameObject;

var stepx: float = 0.35;
var stepy: float = 0.35;

function Start () {
	
}

function Update () {
	if (playing){
		// alternate keys
		if (Input.GetKeyDown(key1)) {
			key1Once = true;
		}
		if (Input.GetKeyDown(key2)) {
			key2Once = true;
		}

		if (key1Once == true && key2Once == true){
			transform.position.x += stepx;
			transform.position.y += stepy;
			key1Once = false;
			key2Once = false;
		}

		// jump
		if (Input.GetKeyDown(jump)) {
			if (!isJumping) {
				transform.position.y += 3 * stepy;
				jumpTime = Time.time;
				isJumping = true;
			}
		}
		if (isJumping) {
			if (Time.time - jumpTime >= 0.5) {
				transform.position.y -= 3 * stepy;
				isJumping = false;
			}
		}
	}
}

//collision
function OnCollisionEnter2D (coll: Collision2D ) {
	Debug.Log("enter");
	if (coll.gameObject.tag == "Respawn") {
		Debug.Log("respawn");
		Destroy(coll.gameObject);
		Debug.Log("Not transforming");
		transform.position.x -= 5 * stepx;
		transform.position.y -= 5 * stepy;
		Debug.Log("Transforming");
	}
}

public function startGame () {
	playing = true;
}

function endGame () {
	playing = false;
}