using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

    public int state;

    private float timerFloat;
    private float timerInt;

    public Text titleText;
    public Text instructionsText;
    public Text timerText;
    public Text gameOver1Text;
    public Text gameOver2Text;

    public Player1 player1;
    public Player2 player2;

    private float winTimer;


    // Use this for initialization
    void Start () {	    

	}
	
	// Update is called once per frame
	void Update () {
        //print(state);
        if (state == 0 && Input.anyKeyDown)
        {
            state = 1;
        }
        //title screen
        if (state == 0)
        {
            timerFloat = 0;
            titleText.text = "STAIR BRAWL";
            instructionsText.text = "Press to begin.";
            timerText.text = "";
            gameOver1Text.text = "";
            gameOver1Text.text = "";
        }
        //timer
        if(state == 1)
        {
            timerFloat += 1 * Time.deltaTime;
            timerInt = Mathf.Floor(timerFloat);
            titleText.text = "";
            instructionsText.text = "";
            //timerText.text = "TIME: " + timerInt.ToString();
            gameOver1Text.text = "";
            gameOver2Text.text = "";
            if(player1.transform.position.x > 196.1)
            {
                state = 2;
            }
            if(player2.transform.position.x > 196.1)
            {
                state = 3;
            }
        }
        //player1 wins
        if(state == 2)
        {
            timerFloat = 0;
            titleText.text = "";
            timerText.text = "";
            instructionsText.text = "";
            gameOver1Text.text = "PLAYER 1 WINS";
            gameOver2Text.text = "";
            StartCoroutine(OriginalState());
            winTimer += 1 * Time.deltaTime;
                if(winTimer > 4)
            {
                state = 0;
            }
        }
        //player2 wins
	    if (state == 3)
        {
            timerFloat = 0;
            titleText.text = "";
            timerText.text = "";
            instructionsText.text = "";
            gameOver1Text.text = "";
            gameOver2Text.text = "PLAYER 2 WINS";
            StartCoroutine(OriginalState());
            winTimer += 1 * Time.deltaTime;
            if (winTimer > 4)
            {
                state = 0;
            }
        }
        if (state == 4)
        {

        }
	}

    public IEnumerator OriginalState()
    {
        yield return new WaitForSeconds(2f);
        state = 0;
        gameOver1Text.text = "";
        gameOver2Text.text = "";
    }
}
