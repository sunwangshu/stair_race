using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public int state;

    private float timerFloat;
    private float timerInt;

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
            if(player1.transform.position.x > 196.1)
            {
                state = 1;
            }
            if(player2.transform.position.x > 196.1)
            {
                state = 2;
            }
        
        //player1 wins
        if(state == 1)
        {
            timerFloat = 0;
            gameOver1Text.text = "PLAYER 1 WINS";
            gameOver2Text.text = "";
            //StartCoroutine(OriginalState());
            winTimer += 1 * Time.deltaTime;
                if(winTimer > 4)
            {
                SceneManager.LoadScene("Title");
            }
        }
        //player2 wins
	    if (state == 2)
        {
            timerFloat = 0;
            gameOver1Text.text = "";
            gameOver2Text.text = "PLAYER 2 WINS";
            //StartCoroutine(OriginalState());
            winTimer += 1 * Time.deltaTime;
            if (winTimer > 4)
            {
                SceneManager.LoadScene("Title");
            }
        }
        if (state == 3)
        {

        }
	}

    /*public IEnumerator OriginalState()
    {
        yield return new WaitForSeconds(2f);
        state = 0;
        gameOver1Text.text = "";
        gameOver2Text.text = "";
    }*/
}
