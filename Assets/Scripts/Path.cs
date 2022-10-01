using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : Tile
{
    public Path(int i, int j, char originalDirection, Tile[,] tileGrid) : base(i, j, originalDirection, tileGrid)
    {

    }

    public override int[] Grow()
    {
        return null;
    }
}
