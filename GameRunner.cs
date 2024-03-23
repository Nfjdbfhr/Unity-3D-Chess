using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{

    public GameObject[,] boardPositions = new GameObject[8, 8];

    public string[] pieceNames =
    {
        "White Rook",
        "White Knight",
        "White Bishop",
        "White Queen",
        "White King",
        "White Bishop 2",
        "White Knight 2",
        "White Rook 2",
        "White Pawn",
        "White Pawn 2",
        "White Pawn 3",
        "White Pawn 4",
        "White Pawn 5",
        "White Pawn 6",
        "White Pawn 7",
        "White Pawn 8",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "Black Pawn",
        "Black Pawn 2",
        "Black Pawn 3",
        "Black Pawn 4",
        "Black Pawn 5",
        "Black Pawn 6",
        "Black Pawn 7",
        "Black Pawn 8",
        "Black Rook",
        "Black Knight",
        "Black Bishop",
        "Black Queen",
        "Black King",
        "Black Bishop 2",
        "Black Knight 2",
        "Black Rook 2"
    };

    public bool whitesMove;

    // Start is called before the first frame update
    void Start()
    {
        // set turn to white first;
        whitesMove = true;

        // set the gameobjects array with GameObject.Find(loop through names array)
        for (int i = 0; i < pieceNames.Length; i++)
        {
            int calcCoordRow = 0;
            int calcCoordCol = 0;

            if (i % 8 == 0)
            {
                calcCoordRow = (i + 1) / 8;
                calcCoordCol = 0;
            }
            else
            {
                calcCoordRow = (i / 8);
                calcCoordCol = i % 8;
            }

            if (GameObject.Find(pieceNames[i]) != null)
            {
                Debug.Log("Row: " + calcCoordRow + "  Col: " + calcCoordCol);
                boardPositions[calcCoordRow, calcCoordCol] = GameObject.Find(pieceNames[i]);
            }
            else
            {
                boardPositions[calcCoordRow, calcCoordCol] = null;
            }
        }

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (boardPositions[row, col] != null)
                {
                    Debug.Log(boardPositions[row, col].name);
                }
                else
                {
                    Debug.Log("Empty");
                }
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (whitesMove)
        {

        }
    }

    public GameObject[,] getBoardPosition()
    {
        return boardPositions;
    }
}