using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITimer : MonoBehaviour
{
    public float playerTimeMin;
    public float playerTimeSec;
    public float AITimeMin;
    public float AITimeSec;
    public Text playerTimeText;
    public Text AITimeText;
    public bool isPlayerTurn;
    public GameManager gameManager;
    public GameObject playerWinPanel;
    public GameObject aiWinPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<BoardManager>();
        ChessTimer();
        playerTimeText.text = playerTimeMin + ":" + playerTimeSec;
        playerWinPanel.SetActive(false);
        aiWinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChessTimer()
    {
        isPlayerTurn = gameManager.playerTurn;
        InvokeRepeating("ChessTimer", 1f, 0f);

        if (isPlayerTurn)
        {
            WhiteTime();
        }
        else
        {
            BlackTime();
        }
    }

    void WhiteTime()
    {
        if (playerTimeMin >= 0)
        {
            if (playerTimeSec >= 0)
            {
                playerTimeSec--;
                if (playerTimeSec < 0 && playerTimeMin > 0)
                {
                    playerTimeMin--;
                    playerTimeSec = 59f;

                }
                else if (playerTimeMin <= 0 && playerTimeSec <= 0)
                {
                    aiWinPanel.SetActive(true);
                }
            }
        }


        if (playerTimeMin >= 10 && playerTimeSec <= 9)
        {
            playerTimeText.text = playerTimeMin + ":0" + playerTimeSec;
        }
        else if (playerTimeMin <= 9 && playerTimeSec >= 10)
        {
            playerTimeText.text = "0" + playerTimeMin + ":" + playerTimeSec;
        }
        else if (playerTimeMin <= 9 && playerTimeSec <= 9)
        {
            playerTimeText.text = "0" + playerTimeMin + ":0" + playerTimeSec;
        }
        else if (playerTimeMin >= 10 && playerTimeSec >= 10)
        {
            playerTimeText.text = playerTimeMin + ":" + playerTimeSec;
        }
    }

    void BlackTime()
    {
        if (AITimeMin >= 0)
        {
            if (AITimeSec >= 0)
            {
                AITimeSec--;
                if (AITimeSec < 0 && AITimeMin > 0)
                {
                    AITimeMin--;
                    AITimeSec = 59f;

                }
                else if (AITimeMin <= 0 && AITimeSec <= 0)
                {
                    playerWinPanel.SetActive(true);
                }
            }
        }


        if (AITimeMin >= 10 && AITimeSec <= 9)
        {
            AITimeText.text = AITimeMin + ":0" + AITimeSec;
        }
        else if (AITimeMin <= 9 && AITimeSec >= 10)
        {
            AITimeText.text = "0" + AITimeMin + ":" + AITimeSec;
        }
        else if (AITimeMin <= 9 && AITimeSec <= 9)
        {
            AITimeText.text = "0" + AITimeMin + ":0" + AITimeSec;
        }
        else if (AITimeMin >= 10 && AITimeSec >= 10)
        {
            AITimeText.text = AITimeMin + ":" + AITimeSec;
        }
    }
}
