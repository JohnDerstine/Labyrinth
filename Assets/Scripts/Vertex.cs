using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : Tile
{
    public Vertex(int i, int j) : base(i, j)
    {

    }

    //grow once in any direction
    public override int[] Grow()
    {
        int decision = Random.Range(0, 101);
        int[] next = coords;

        if (decision < 101)
        {
            //go right
            next[0] += 1;
        }
        else if (decision < 60)
        {
            //go left
            next[0] -= 1;
        }
        else if (decision < 90)
        {
            //go straight
            next[1] += 1;
        }
        else
        {
            //stop
            next[1] -= 1;
        }
        return next;
    }
}
