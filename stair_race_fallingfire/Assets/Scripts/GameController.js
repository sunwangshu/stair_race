#pragma strict

var startKey1: KeyCode;
var startKey2: KeyCode;
var startKey3: KeyCode;
var startKey4: KeyCode;

//var endheight: float = 16;	//whoever first reach the height is the winner
var endx: float = 0.5;		//whoever first reach within this x is the winner, avoid jumping cheat

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
//	// testing jump
//	player1.transform.position.x = -12.6;
//	player1.transform.position.y = 4;
//	player2.transform.position.x = 12.6;
//	player2.transform.position.y = 4;
}

function Update () {
	// start
	if (stage == 1) {
		if(Input.GetKeyDown(startKey1) || Input.GetKeyDown(startKey2) || Input.GetKeyDown(startKey3) ||Input.GetKeyDown(startKey4)){
			player1.startGame();
			player2.startGame();
			timeCount = 0.0;
			timeStart = Time.time;
//			Instantiate(fallingfire1, Vector2(0, 16.6), Quaternion.identity);
//			Instantiate(fallingfire2, Vector2(0, 16.6), Quaternion.identity);
			stage = 2;
		}
	}

	if (stage == 2) {
		timeCount = Time.time - timeStart;
		timeText.text = "Time: " + timeCount;
		if(player1.transform.position.x >= - endx) {
			// player1 wins
			result.text = "<- Sun wins the star!";
			//result.text.color = #AA0000FF;
			player1.endGame();
			player2.endGame();
			stage = 0;
		}
		else if (player2.transform.position.x <= endx) {
			// player2 wins
			result.text = "-> Moon wins the star!";
			player1.endGame();
			player2.endGame();
			stage = 0;
		}
	}
}