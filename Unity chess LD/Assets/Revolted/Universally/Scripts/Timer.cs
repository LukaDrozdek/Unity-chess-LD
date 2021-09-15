using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float whiteTimeMin;
    public float whiteTimeSec;
    public float blackTimeMin;
    public float blackTimeSec;
    public Text whiteTimeText;
    public Text blackTimeText;
    public bool isWhite;
    public BoardManager boardManager;
    // Start is called before the first frame update
    void Start()
    {
        boardManager.GetComponent<BoardManager>();
        ChessTimer();
        whiteTimeText.text = whiteTimeMin + ":" + whiteTimeSec;
       // blackTimeText.text = blackTimeMin + ":0" + blackTimeSec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChessTimer()
    {
        isWhite = boardManager.isWhiteTurn;
        InvokeRepeating("ChessTimer", 1f, 0f);

        if (isWhite)
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
        if (whiteTimeMin >= 0)
        {
            if (whiteTimeSec >= 0)
            {
                whiteTimeSec--;
                if (whiteTimeSec < 0 && whiteTimeMin > 0)
                {
                    whiteTimeMin--;
                    whiteTimeSec = 59f;
                    
                }
                else if (whiteTimeMin <= 0 && whiteTimeSec <= 0)
                {
                    boardManager.blackWin.SetActive(true);
                }
            }
        }


        if (whiteTimeMin >= 10 && whiteTimeSec <= 9)
        {
            whiteTimeText.text = whiteTimeMin + ":0" + whiteTimeSec;
        }
        else if (whiteTimeMin <= 9 && whiteTimeSec >= 10)
        {
            whiteTimeText.text = "0" + whiteTimeMin + ":" + whiteTimeSec;
        }
        else if (whiteTimeMin <= 9 && whiteTimeSec <= 9)
        {
            whiteTimeText.text = "0" + whiteTimeMin + ":0" + whiteTimeSec;
        }
        else if (whiteTimeMin >= 10 && whiteTimeSec >= 10)
        {
            whiteTimeText.text = whiteTimeMin + ":" + whiteTimeSec;
        }
    }

    void BlackTime()
    {
        if (blackTimeMin >= 0)
        {
            if (blackTimeSec >= 0)
            {
                blackTimeSec--;
                if (blackTimeSec < 0 && blackTimeMin > 0)
                {
                    blackTimeMin--;
                    blackTimeSec = 59f;

                }
                else if (blackTimeMin <= 0 && blackTimeSec <= 0)
                {
                    boardManager.whiteWin.SetActive(true);
                }
            }
        }


        if (blackTimeMin >= 10 && blackTimeSec <= 9)
        {
            blackTimeText.text = blackTimeMin + ":0" + blackTimeSec;
        }
        else if (blackTimeMin <= 9 && blackTimeSec >= 10)
        {
            blackTimeText.text = "0" + blackTimeMin + ":" + blackTimeSec;
        }
        else if (blackTimeMin <= 9 && blackTimeSec <= 9)
        {
            blackTimeText.text = "0" + blackTimeMin + ":0" + blackTimeSec;
        }
        else if (blackTimeMin >= 10 && blackTimeSec >= 10)
        {
            blackTimeText.text = blackTimeMin + ":" + blackTimeSec;
        }
    }
}
