using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int sizeX = 10;
    public int sizeZ = 10;
    public int TileDistance = 2;
    public GameObject Tile;
    NodeBlock[,] matrixOfTiles;

    void Awake()
    {
        if(Tile == null) enabled = false;

        matrixOfTiles = new NodeBlock[sizeX,sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                var newTile = Instantiate(Tile) as GameObject;

                var tileScript = newTile.GetComponent<NodeBlock>();
                tileScript.Reset();
                tileScript.SetSize(x, z);
                newTile.transform.position = new Vector3(x * TileDistance, 0, z * TileDistance);
                
                matrixOfTiles[x,z] = tileScript;
            }
        }
    }

    public NodeBlock GetNode(int x, int z){
        return matrixOfTiles[x,z];
    }

    public  List<NodeBlock> GetClosestNodes(NodeBlock node){
        var closest = new List<NodeBlock>();

        var newX = node.X - 1;
        if(newX >= 0)
        {
            closest.Add(GetNode(newX, node.Z));
            if(node.Z - 1 >= 0)
            {
                closest.Add(GetNode(newX, node.Z - 1));
            }
            if(node.Z + 1 < sizeZ)
            {
                closest.Add(GetNode(newX, node.Z + 1));
            }
        }

        newX = node.X + 1;
        if(newX < sizeX)
        {
            closest.Add(GetNode(newX, node.Z));
            if(node.Z - 1 >= 0)
            {
                closest.Add(GetNode(newX, node.Z - 1));
            }
            if(node.Z + 1 < sizeZ)
            {
                closest.Add(GetNode(newX, node.Z + 1));
            }
        }

        newX = node.X;
        if(node.Z + 1 < sizeZ)
        {
            closest.Add(GetNode(newX, node.Z + 1));
        }
        if(node.Z - 1 >= 0)
        {
            closest.Add(GetNode(newX, node.Z - 1));
        }


        return closest;
    }

    public void SetObstacles(List<NodeBlock> nodes){
        foreach (var item in nodes)
        {
            item.IsObstacle = true;
            var renderer = item.gameObject.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.black);
        }
    }
}
