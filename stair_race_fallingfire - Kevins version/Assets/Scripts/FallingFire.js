#pragma strict

var direction: int;	//left 0; right 1;
var spawnX : float;
var spawnY : float;
var speedX : float;
var speedY : float;
var lastTime : float;
var interval : float = 0.25;

function Start () {
	lastTime = Time.time;
	if (direction == 0) {
		speedX = -0.35;
		speedY = -0.35;
	}
	else if (direction == 1) {
		speedX = 0.35;
		speedY = -0.35;
	}
}

function Update () {
	if (Time.time - lastTime >= interval) {
		transform.position.x += speedX;
		transform.position.y += speedY;
		lastTime = Time.time;
	}
}