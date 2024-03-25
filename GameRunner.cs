using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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

    public Material selectionMat;
    public Material originalMatWhite;
    public Material originalMatBlack;

    // Start is called before the first frame update
    void Start()
    {
        // set turn to white first;
        whitesMove = true;

        Renderer rend = GameObject.Find("White Pawn").GetComponent<Renderer>();
        if (rend != null)
        {
            originalMatWhite = rend.material;
        }

        Renderer render = GameObject.Find("Black Pawn").GetComponent<Renderer>();
        if (rend != null)
        {
            originalMatBlack = rend.material;
        }

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with any collider
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.IndexOf("White") != -1f || hit.collider.gameObject.name.IndexOf("Black") != -1f)
                {
                    Renderer rend = hit.collider.gameObject.GetComponent<Renderer>();

                    // Check if Renderer component exists
                    if (rend != null)
                    {
                        // Set the material to the new material
                        rend.material = selectionMat;
                    }
                }
                else
                {
                    for (int i = 0; i < pieceNames.Length; i++)
                    {
                        if (pieceNames[i] == "")
                        {
                            break;
                        }
                        Renderer rend = GameObject.Find(pieceNames[i]).GetComponent<Renderer>();

                        if (rend != null)
                        {
                            if (pieceNames[i].IndexOf("White") != -1)
                            {
                                rend.material = originalMatWhite;
                            }
                            else if (pieceNames[i].IndexOf("Black") != -1)
                            {
                                rend.material = originalMatBlack;
                            }
                        }
                        
                    }
                }
            }
        }
    }

    public GameObject[,] getBoardPosition()
    {
        return boardPositions;
    }
}