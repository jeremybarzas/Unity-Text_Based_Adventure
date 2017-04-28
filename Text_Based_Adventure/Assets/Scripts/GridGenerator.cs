using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public Vector2 gridSize;
    public GameObject groundPlanePrefab;
    public GameObject nodePrefab;
    public GameObject playerPrefab;

    private GameObject actualPlayerObject;
    private GameObject playerStartNode;
    private List<GameObject> nodes;

    // Use this for initialization
    void Start()
    {
        // initialize node list
        nodes = new List<GameObject>();

        // set up limtis of grid size
        int nodeCount = (int)gridSize.x * (int)gridSize.y;
        float maxX = ((gridSize.x - 1) / 2) * 22.5f;
        float maxY = ((gridSize.y - 1) / 2) * 22.5f;
        float minX = ((gridSize.x - 1) / 2) * -22.5f;
        float minY = ((gridSize.y - 1) / 2) * -22.5f;

        // ground plane spawn
        Instantiate<GameObject>(groundPlanePrefab, this.transform);

        // setting up local variables for position
        Vector3 newPos = nodePrefab.transform.position;
        var tmpx = nodePrefab.transform.position.x;
        var tmpy = nodePrefab.transform.position.y;
        var tmpz = nodePrefab.transform.position.z;

         // spawn center node  2,2 
        newPos = new Vector3(tmpx - maxX + maxX, tmpy, tmpz - maxY + maxY);
        var newNode0 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode0.transform.position = newPos;
        nodes.Add(newNode0);

        // spawn bottom left node  0,0 
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz - maxY);
        var newNode1 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode1.transform.position = newPos;
        nodes.Add(newNode1);

        // spawn bottom right node 4,0
        newPos = new Vector3(tmpx - minX, tmpy, tmpz - maxY);
        var newNode2 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode2.transform.position = newPos;
        nodes.Add(newNode2);

        // spawn top left node  0,4 
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz - minY);
        var newNode3 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode3.transform.position = newPos;
        nodes.Add(newNode3);

        // spawn top right node  4,4 
        newPos = new Vector3(tmpx - minX, tmpy, tmpz - minY);
        var newNode4 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode4.transform.position = newPos;
        nodes.Add(newNode4);
        
        // node spawn
        while (nodes.Count != nodeCount)
        {
            // spawn all nodes to center of grid
            newPos = new Vector3(tmpx - maxX + maxX, tmpy, tmpz - maxY + maxY);
            var newNode = Instantiate<GameObject>(nodePrefab, this.transform);
            newNode.transform.position = newPos;
            nodes.Add(newNode);          
        }
        
        // fixed player spawn
        playerStartNode = nodes[0];
        var nodex = playerStartNode.transform.position.x;
        var nodey = playerStartNode.transform.position.y;
        var nodez = playerStartNode.transform.position.z;
        var player = Instantiate<GameObject>(playerPrefab);
        Vector3 playerPos = new Vector3(nodex, nodey + 5f, nodez);
        player.transform.position = playerPos;
        actualPlayerObject = player;
    }
	
	// Update is called once per frame
	void Update()
    {
        // randomized player spawn        
        int index = Random.Range(0, nodes.Count);
        playerStartNode = nodes[index];
        var nodex = playerStartNode.transform.position.x;
        var nodey = playerStartNode.transform.position.y;
        var nodez = playerStartNode.transform.position.z;
        Vector3 playerPos = new Vector3(nodex, nodey + 5f, nodez);
        actualPlayerObject.transform.position = playerPos;
        
        //// mouse click the nodes to move the player to its location
        //if (Input.GetMouseButtonDown(0))
        //{
        //    foreach (GameObject node in nodes)
        //    {
        //        for(int i = 0; i > 10; i++)
        //        {
        //            if (Input.mousePosition == node.transform.position)
        //            {
        //                var nodex1 = node.transform.position.x;
        //                var nodey1 = node.transform.position.y;
        //                var nodez1 = node.transform.position.z;
        //                Vector3 playerPos1 = new Vector3(nodex1, nodey1 + 5f, nodez1);
        //                actualPlayerObject.transform.position = playerPos1;
        //            }
        //        }
        //    }           
        //}
        //Debug.Log(Input.mousePosition);
    }
}
