using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Tile[,] tileGrid;
    public Tile down;
    public Tile right;
    public Tile left;
    public Tile up;
    public int[] coords = new int[2];
    public char originalDirection;

    public Tile(int i, int j, char originalDirection, Tile[,] tileGrid)
    {
        coords[0] = i;
        coords[1] = j;
        this.originalDirection = originalDirection;
        this.tileGrid = tileGrid;
    }

    public abstract int[] Grow();
}
