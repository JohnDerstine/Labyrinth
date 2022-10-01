using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    public Wall(int i, int j) : base(i, j)
    {

    }

    public override int[] Grow()
    {
        return null;
    }
}
