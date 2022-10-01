using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Tile down;
    public Tile right;
    public Tile left;
    public Tile up;
    public int[] coords = new int[2];

    public Tile(int i, int j)
    {
        coords[0] = i;
        coords[1] = j;
    }

    public abstract int[] Grow();
}
