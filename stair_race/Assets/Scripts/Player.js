#pragma strict

var playing: boolean = false;
var star: GameObject;

var key1 : KeyCode;
var key2: KeyCode;
var key1Once: boolean = false;
var key2Once: boolean = false;

var stepx: float = 0.35;
var stepy: float = 0.35;

function Start () {
	
}

function Update () {
	if (playing){
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
	}
}

public function startGame () {
	playing = true;
}

function endGame () {
	playing = false;
}