using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinding : MonoBehaviour
{
    public GameObject TerrainGeneratorObject;
    private TerrainGenerator TerrainGenerator;
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private List<NodeBlock> inProgressList;
    private List<NodeBlock> visitedList;

    void Start()
    {
        if(TerrainGeneratorObject == null) enabled = false;
        TerrainGenerator = TerrainGeneratorObject.GetComponent<TerrainGenerator>();
        
        //setting obstacles
        var obstacles = new List<NodeBlock> {
            TerrainGenerator.GetNode(0, 4),
            TerrainGenerator.GetNode(1, 4),
            TerrainGenerator.GetNode(2, 4),
            TerrainGenerator.GetNode(3, 4),
            TerrainGenerator.GetNode(4, 4),
            TerrainGenerator.GetNode(4, 7),
            TerrainGenerator.GetNode(5, 7),
            TerrainGenerator.GetNode(6, 7),
            TerrainGenerator.GetNode(3, 6),
            TerrainGenerator.GetNode(7, 6),
            TerrainGenerator.GetNode(3, 7),
        };
        TerrainGenerator.SetObstacles(obstacles);
        //
        var correctPath = FindPath(0,0,4,9);
        foreach (var node in correctPath)
        {
            var renderer = node.gameObject.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.green);
        }
    }

    public List<NodeBlock> FindPath(int startX, int startZ, int endX, int endZ){
        var startNode = TerrainGenerator.GetNode(startX, startZ);
        var endNode = TerrainGenerator.GetNode(endX, endZ);
        inProgressList = new List<NodeBlock> { startNode };
        visitedList = new List<NodeBlock>();

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while(inProgressList.Count > 0){
            var currentNode = GetLowestFCostNode(inProgressList);
            if(currentNode == endNode){
                //FOUND!
                return GetFinalPath(endNode);
            }

            inProgressList.Remove(currentNode);
            visitedList.Add(currentNode);

            var closestToNode = TerrainGenerator.GetClosestNodes(currentNode);
            foreach (var item in closestToNode)
            {
                if(!visitedList.Contains(item) && !item.IsObstacle){
                    var tempGCost = currentNode.gCost + CalculateDistanceCost(currentNode, item);
                    if(tempGCost < item.gCost){
                        item.UpdateCosts(currentNode, CalculateDistanceCost(currentNode, item), CalculateDistanceCost(item, endNode));

                        if(!inProgressList.Contains(item)){
                            inProgressList.Add(item);
                        }
                    }
                }
            }
        }
        return null;
    }

    private List<NodeBlock> GetFinalPath(NodeBlock node){
        var result =  new List<NodeBlock>();

        var currentNode = node;
        while(currentNode != null){
            result.Add(currentNode);
            currentNode = currentNode.cameFromNodeBlock;
        }
        result.Reverse();
        return result;
    }

    private int CalculateDistanceCost(NodeBlock start, NodeBlock end) {
        var xDistance = Mathf.Abs(start.X - end.X);
        var zDistance = Mathf.Abs(start.Z - end.Z);
        
        int remaining = Mathf.Abs(xDistance - zDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, zDistance) + MOVE_STRAIGHT_COST * remaining;
        // var diagonalDistance = xDistance == 1 && zDistance == 1;
        // if(diagonalDistance)
        // {
        //     return MOVE_DIAGONAL_COST * 
        // }
    }

    private NodeBlock GetLowestFCostNode(List<NodeBlock> nodes){
        var minCost = nodes.Min(x => x.fCost);
        return nodes.FirstOrDefault(x => x.fCost == minCost);
    }
}
