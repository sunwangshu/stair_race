#pragma strict

var startKey1: KeyCode;
var startKey2: KeyCode;
var startKey3: KeyCode;
var startKey4: KeyCode;

var endheight: float = 16;	//whoever first reach the height is the winner

var stage: int = 1;		//1: gameplay; 2: end game;

var player1: Player;
var player2: Player;

var result: UI.Text;	// result
var timeText: UI.Text;	// result
var timeCount: float = 0.0;
var timeStart: float;

function Start () {
	result.text = "";
	timeText.text = "Press any button to start racing!";
}

function Update () {
	// start
	if (stage == 1) {
		if(Input.GetKeyDown(startKey1) || Input.GetKeyDown(startKey2) || Input.GetKeyDown(startKey3) ||Input.GetKeyDown(startKey4)){
			player1.startGame();
			player2.startGame();
			timeCount = 0.0;
			timeStart = Time.time;
			stage = 2;
		}
	}

	if (stage == 2) {
		timeCount = Time.time - timeStart;
		timeText.text = "Time: " + timeCount;
		if(player1.transform.position.y >= endheight) {
			// player1 wins
			result.text = "<- Sun wins the star!";
			//result.text.color = #AA0000FF;
			player1.endGame();
			player2.endGame();
			stage = 0;
		}
		else if (player2.transform.position.y >= endheight) {
			// player2 wins
			result.text = "-> Moon wins the star!";
			player1.endGame();
			player2.endGame();
			stage = 0;
		}
	}
}