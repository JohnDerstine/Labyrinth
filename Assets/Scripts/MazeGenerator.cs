using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    //fields
    #region
    [SerializeField]
    Tile[,] tileGrid = new Tile[101,101];

    [SerializeField]
    GameObject wall;

    [SerializeField]
    GameObject path;

    [SerializeField]
    List<Tile> roots = new List<Tile>();

    int[] next;

    Stack<Tile> vStack = new Stack<Tile>();
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        SpawnGrid();
    }

    //generates a grid with verticies on it
    public void GenerateGrid()
    {
        //blank maze
        #region
        //initialize all tiles as walls for now
        for (int i = 1; i < tileGrid.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < tileGrid.GetLength(1) - 1; j++)
            {
                tileGrid[i, j] = new Wall(i, j, 'n', tileGrid);
            }
        }
        #endregion

        //setup origin
        #region 
        //setup the origin for the maze genertion
        tileGrid[50, 50] = new Path(50, 50, 'n', tileGrid);
        tileGrid[49, 50] = new Root(49, 50, 'l', tileGrid);
        roots.Add(tileGrid[49, 50]);
        tileGrid[51, 50] = new Root(51, 50, 'r', tileGrid);
        roots.Add(tileGrid[51, 50]);
        tileGrid[50, 49] = new Root(50, 49, 'd', tileGrid);
        roots.Add(tileGrid[50, 49]);
        tileGrid[50, 51] = new Root(50, 51, 'u', tileGrid);
        roots.Add(tileGrid[50, 51]);
        #endregion

        //Roots
        #region
        //grow from the roots
        foreach (Root r in roots)
        {
            next = r.Grow();
            tileGrid[next[0], next[1]] = new Vertex(next[0], next[1], r.originalDirection, tileGrid);
            vStack.Push(tileGrid[next[0], next[1]]);
        }
        #endregion

        //vertecies
        #region
        while (vStack.Count > 0)
        {
            next = vStack.Peek().Grow();
            if (next[0] != 0 && next[1] != 0)
            {
                tileGrid[next[0], next[1]] = new Vertex(next[0], next[1], vStack.Peek().originalDirection, tileGrid);
                vStack.Pop();
                vStack.Push(tileGrid[next[0], next[1]]);
            }
            else
            {
                vStack.Pop();
            }
        }
        #endregion

        //reset neighbors
        #region
        //Makes sure all tiles have the correct neighor references
        for (int i = 1; i < tileGrid.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < tileGrid.GetLength(1) - 1; j++)
            {
                tileGrid[i, j].down = tileGrid[i, j - 1];
                tileGrid[i, j].right = tileGrid[i + 1, j];
                tileGrid[i, j].left = tileGrid[i - 1, j];
                tileGrid[i, j].up = tileGrid[i, j + 1];
            }
        }
        #endregion
    }

    //spawns the grid in the game
    public void SpawnGrid()
    {
        for (int i = 0; i < tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < tileGrid.GetLength(1); j++)
            {
                if (tileGrid[i,j] is Wall) 
                    Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
                else if (tileGrid[i, j] is Root)
                    Instantiate(path , new Vector3(i, 0, j), Quaternion.identity);
                else
                    Instantiate(path, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }
}
