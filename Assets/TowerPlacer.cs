using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject parent;
    [SerializeField] int maxTower = 5;

    bool isTowerPlased = false;

    private void OnMouseDown()
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;
            if (!isTowerPlased)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity, parent.transform);
                isTowerPlased = true;
            }
    }

    private void MoveTower()
    {
        
    }
}
