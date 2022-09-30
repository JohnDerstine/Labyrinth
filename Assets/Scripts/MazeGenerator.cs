using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    char[,] tileGrid = new char[100,100];

    [SerializeField]
    GameObject wall;

    [SerializeField]
    GameObject path;

    [SerializeField]
    List<Vector2> vList = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        foreach (Vector2 vertex in vList)
            CreatePath(vertex);
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

        //get random verticies
        for (int i = 0; i < 15; i++)
        {
            int x = Random.Range(1,99);
            int y = Random.Range(1, 99);
            tileGrid[x, y] = 'v';
            vList.Add(new Vector2(x, y));
        }
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

    //creates paths betweenv verticies
    public void CreatePath(Vector2 vertex)
    {
        List<Vector2> pathList = GetPaths(vertex);
        //Vector2 closest = GetClosest(vList[0]);

        foreach (Vector2 v in pathList)
        {
            float xDiff = v.x - vertex.x;
            float yDiff = v.y - vertex.y;
            bool xDir = false;
            bool yDir = false;
            Vector2 currentTile = vertex;
            if (xDiff < 0)
                xDir = true;
            if (yDiff < 0)
                yDir = true;

            for (int i = 1; i <= Mathf.Abs(xDiff); i++)
            {
                if (xDir)
                {
                    int currentX = Mathf.RoundToInt(vertex.x) + (-1 * i);
                    int currentY = Mathf.RoundToInt(vertex.y);
                    currentTile = new Vector2(currentX, currentY);
                    tileGrid[currentX, currentY] = 'p';
                }
                else
                {
                    int currentX = Mathf.RoundToInt(vertex.x) + i;
                    int currentY = Mathf.RoundToInt(vertex.y);
                    currentTile = new Vector2(currentX, currentY);
                    tileGrid[currentX, currentY] = 'p';
                }
            }

            for (int i = 1; i <= Mathf.Abs(yDiff); i++)
            {
                if (yDir && currentTile != new Vector2(100, 100))
                    tileGrid[Mathf.RoundToInt(currentTile.x), Mathf.RoundToInt(currentTile.y) + (-1 * i)] = 'p';
                else
                    tileGrid[Mathf.RoundToInt(currentTile.x), Mathf.RoundToInt(currentTile.y) + i] = 'p';

            }
        }
    }

    //public Vector2 GetClosest(Vector2 thisV)
    //{
    //    Vector2 closest1 = new Vector2(1000,1000);
    //    foreach (Vector2 v in vList)
    //    {
    //        Vector2 betweenC1 = closest1 - thisV;
    //        Vector2 between = v - thisV;
    //        if ((between.magnitude < betweenC1.magnitude) && between.magnitude != 0)
    //            closest1 = v;
    //    }
    //    return closest1;
    //}

    public List<Vector2> GetPaths(Vector2 thisV)
    {
        Vector2 closest1 = new Vector2(1000, 1000);
        Vector2 closest2 = new Vector2(1000, 1000);
        Vector2 farthest = new Vector2(0,0);
        foreach (Vector2 v in vList)
        {
            Vector2 betweenC1 = closest1 - thisV;
            Vector2 between = v - thisV;
            if ((between.magnitude < betweenC1.magnitude) && between.magnitude != 0)
            {
                closest2 = closest1;
                closest1 = v;
            }

            Vector2 betweenF = farthest - thisV;
            if (between.magnitude > betweenF.magnitude)
            {
                farthest = v;
            }
        }
        List<Vector2> paths = new List<Vector2>();
        paths.Add(closest1);
        paths.Add(closest2);
        paths.Add(farthest);

        return paths;
    }
}
