using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    char[,] tileGrid = new char[99,99];

    [SerializeField]
    GameObject wall;

    [SerializeField]
    GameObject path;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        SpawnGrid();
    }

    //generates a grid with verticies on it
    public void GenerateGrid()
    {
        for (int i = 0; i < tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < tileGrid.GetLength(1); j++)
            {
                Debug.Log(i + " " + j);
                tileGrid[i,j] = 'x';
            }
        }

        tileGrid[50, 50] = 'p';
        tileGrid[49, 50] = 'v';
        tileGrid[50, 49] = 'v';
        tileGrid[50, 51] = 'v';
        tileGrid[51, 50] = 'v';



    }

    //spawns the grid in the game
    public void SpawnGrid()
    {
        for (int i = 0; i < tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < tileGrid.GetLength(1); j++)
            {
                if (tileGrid[i,j] == 'x')
                    Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
                else if (tileGrid[i, j] == 'v')
                    Instantiate(path , new Vector3(i, 0, j), Quaternion.identity);
                else
                    Instantiate(path, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }
}
