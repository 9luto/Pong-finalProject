using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    static int gameLaunch = 0;

    public GUISkin layout;

    GameObject theBall;
    GameObject PaddleTwo;
    PlayerControls PlayerTwoControls;

    


    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        PaddleTwo = GameObject.FindGameObjectWithTag("Player2");
    }

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if(gameLaunch >=0)
        players();

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            gameLaunch++;
            players();
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 60, 400, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 60, 400, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    void players()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 65, 150, 120, 53), "One Player"))
        {
            PaddleTwo.GetComponent<PlayerControls>().enabled = false;
            PaddleTwo.GetComponent<PaddleAI>().enabled = true;
        }
        else if (GUI.Button(new Rect(Screen.width / 2 - 65, 200, 120, 53), "Two Player"))
        {

            PaddleTwo.GetComponent<PlayerControls>().enabled = true;
            PaddleTwo.GetComponent<PaddleAI>().enabled = false;

        }
    }

}
