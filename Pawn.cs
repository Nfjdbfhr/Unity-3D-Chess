using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    public int startRow = 0;
    public int startCol = 0;

    public GameObject[,] boardPositions = new GameObject[8, 8];

    public GameObject piece;

    public GameRunner gameRunner;

    // Start is called before the first frame update
    IEnumerator Start()
    {
    yield return new WaitForSeconds(2f);
        gameRunner = GameObject.Find("Game Runner").GetComponent<GameRunner>();

        boardPositions = gameRunner.getBoardPosition();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (boardPositions[row, col] != null && boardPositions[row, col].name == piece.name)
                {
                    startRow = row;
                    startCol = col;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isLegalMove(int targetRow, int targetCol)
    {
        boardPositions = gameRunner.getBoardPosition();

        int currentCol = 0;
        int currentRow = 0;

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (boardPositions[row, col] != null && boardPositions[row, col].name == piece.name)
                {
                    currentRow = row;
                    currentCol = col;
                }
            }
        }

        if (currentCol == targetCol)
        {
            if (targetRow != (currentRow + 1))
            {
                return false;
            }
            else if (boardPositions[targetRow, targetCol] != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (targetCol != (currentCol + 1) || targetCol != currentCol - 1)
            {
                return false;
            }
            else if (boardPositions[targetRow, targetCol] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // above the last else check the color of the piece you are moving into after you add the color properties
    }
}
