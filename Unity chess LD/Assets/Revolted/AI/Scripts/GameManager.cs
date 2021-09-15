using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AlphaBeta ab = new AlphaBeta();
    private bool _kingDead = false;
    public GameObject playerKing;
    public GameObject playerWin;
    public GameObject aiWin;
    float timer = 0;
    Board _board;
    public bool playerTurn = true;
    
    void Start ()
    {
        Time.timeScale = 1;
        playerWin.SetActive(false);
        aiWin.SetActive(false);
        _board = Board.Instance;
        _board.SetupBoard();
	}

	void Update ()
    {
       
        if (_kingDead)
        {
            if(playerKing == null)
            {
                aiWin.SetActive(true);
            }
            else
            {
                playerWin.SetActive(true);
            }
        }
        if (!playerTurn && timer < 3)
        {
            timer += Time.deltaTime;
        }
        else if (!playerTurn && timer >= 3)
        {

            Move move = ab.GetMove();
            _DoAIMove(move);
            timer = 0;
        }
	}

    

    void _DoAIMove(Move move)
    {
        Tile firstPosition = move.firstPosition;
        Tile secondPosition = move.secondPosition;

        if (secondPosition.CurrentPiece && secondPosition.CurrentPiece.Type == Piece.pieceType.KING)
        {
            SwapPieces(move);
            _kingDead = true;
        }
        else
        {
            SwapPieces(move);
        }
    }

    public void SwapPieces(Move move)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Highlight");
        foreach (GameObject o in objects)
        {
            Destroy(o);
        }

        Tile firstTile = move.firstPosition;
        Tile secondTile = move.secondPosition;

        firstTile.CurrentPiece.MovePiece(new Vector3(-move.secondPosition.Position.x, 0, move.secondPosition.Position.y));

        if (secondTile.CurrentPiece != null)
        {
            if (secondTile.CurrentPiece.Type == Piece.pieceType.KING)
                _kingDead = true;
            Destroy(secondTile.CurrentPiece.gameObject);
        }
            

        secondTile.CurrentPiece = move.pieceMoved;
        firstTile.CurrentPiece = null;
        secondTile.CurrentPiece.position = secondTile.Position;
        secondTile.CurrentPiece.HasMoved = true;
        playerTurn = !playerTurn;
    }

    public void OpenMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
