using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public int state;

    private float timerFloat;
    private float timerInt;

    public Player1 player1;
    public Player2 player2;

    private float winTimer;


    // Use this for initialization
    void Start () {	    

	}

	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Main");
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
