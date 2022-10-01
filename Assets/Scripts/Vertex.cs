using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : Tile
{
    public Vertex(int i, int j, char originalDirection, Tile[,] tileGrid) : base(i, j, originalDirection, tileGrid)
    {

    }

    //grow once in any direction
    public override int[] Grow()
    {
        int[] next = new int[2];
        next[0] = coords[0];
        next[1] = coords[1];
        int count = 0;
        do
        {
            count++;
            float decision = Random.Range(0f, 101f);

            if (decision < 50)
            {
                //go right
                next[0] += 1;
            }
            else if (decision < 66.65)
            {
                //go left
                next[0] -= 1;
            }
            else if (decision < 83.3)
            {
                //go up
                next[1] += 1;
            }
            else if (decision < 99.95)
            {
                //go down
                next[1] -= 1;
            }
            else
            {
                Debug.Log("end");
                //end
                next[0] = 0;
                next[1] = 0;
            }
            //Debug.Log(coords[0] + " " + coords[1] + " " + next[0] + " " + next[1]);
            if (next[0] > 0 && next[1] > 0)
            {
                //Debug.Log(tileGrid[coords[0], coords[1]].originalDirection + " " + tileGrid[next[0], next[1]].originalDirection);

                //Debug.Log(coords[0] + " " + coords[1] + " " + next[0] + " " + next[1]);
                if (tileGrid[coords[0], coords[1]].originalDirection == tileGrid[next[0], next[1]].originalDirection)
                {
                    Debug.Log("ran into myself");
                    next[0] = coords[0];
                    next[1] = coords[1];
                    count--;
                }
            }

        }
        while (count < 1);

        return next;
    }
}

