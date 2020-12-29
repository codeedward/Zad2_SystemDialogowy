using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBlock : MonoBehaviour
{
    public int X;
    public int Z;

    public int gCost;
    public int hCost;
    public int fCost;
    public NodeBlock cameFromNodeBlock;
    public bool IsObstacle = false;

    public void SetSize(int x, int z) {
        X = x;
        Z = z;
    }

    public void Reset() {
        gCost = int.MaxValue;
        hCost = 0;
        CalculateFCost();
        cameFromNodeBlock = null;

    }

    public void CalculateFCost(){
        fCost = gCost + hCost;
    }

    public void UpdateCosts(NodeBlock relative, int distanceToRelative, int distanceToEndNode){
        cameFromNodeBlock = relative;
        gCost = relative.gCost + distanceToRelative;
        hCost = distanceToEndNode;
        CalculateFCost();
    }
}
