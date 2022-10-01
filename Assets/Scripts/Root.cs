using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Tile
{
    public Root(int i, int j) : base(i, j)
    {

    }

    //Grow once in the correct direction
    public override int[] Grow()
    {
        int[] next = coords;

        if (next[0] - 50 == 1)
        {
            next[0] += 1;
        }
        else if (next[0] - 50 == -1)
        {
            next[0] -= 1;
        }
        else if (next[1] - 50 == 1)
        {
            next[1] += 1;
        }
        else
        {
            next[1] -= 1;
        }

        return next;
    }
}
