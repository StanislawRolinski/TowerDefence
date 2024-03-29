﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int GRID_SIZE = 10;
    Vector2Int gridPos;
    [SerializeField] GameObject top;

    public bool isExplored = false;
    public Waypoint exploredFrom;


    public int GridSize()
    {
        return GRID_SIZE;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
       Mathf.RoundToInt(transform.position.x / GRID_SIZE),
       Mathf.RoundToInt(transform.position.z / GRID_SIZE)
        );
    }
}
