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
    private int nodeCount;

    // this function needs instatiate, add to list, and set a key of some sort
    // to every node scaled by the gridSize Vector 2 variable
    private List<GameObject> GenerateGrid()
    {
        // store in temp variable to me modified
        List<GameObject> tmpNodes = nodes;

        // ground plane spawn
        var newGroundPlane = Instantiate<GameObject>(groundPlanePrefab, this.transform);

        // scale ground plane by grid size
        // currently not working as intended
        //if (gridSize.x != 5 || gridSize.y != 5)
        //{
        //    var xSize = gridSize.x;
        //    var ySize = gridSize.y;

        //    var xScale = (float)xSize * 2.75;
        //    var yScale = (float)xSize * 2.75;

        //    Vector3 newScale = new Vector3((float)xScale, 1, (float)yScale);
        //    newGroundPlane.transform.localScale = newScale;
        //}

        // setting up local variables for position
        Vector3 newPos = nodePrefab.transform.position;
        var tmpx = newPos.x;
        var tmpy = newPos.y;
        var tmpz = newPos.z;

        // gets the outside boundaries of the groundPlane
        float maxX = ((gridSize.x - 1) / 2) * 22.5f;
        float maxY = ((gridSize.y - 1) / 2) * 22.5f;
        float minX = ((gridSize.x - 1) / 2) * -22.5f;
        float minY = ((gridSize.y - 1) / 2) * -22.5f;

        /*===================== Start Manual Node Generatation =========================*/

        /*===================== X = 0 =========================*/

        // spawn node  0,0 
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz - maxY);
        var newNode00 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode00.transform.position = newPos;
        tmpNodes.Add(newNode00);

        // spawn node 0,1
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz + minY / 2);
        var newNode01 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode01.transform.position = newPos;
        tmpNodes.Add(newNode01);

        // spawn node 0,2 
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz);
        var newNode02 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode02.transform.position = newPos;
        tmpNodes.Add(newNode02);       

        // spawn node 0,3
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz - minY / 2);
        var newNode03 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode03.transform.position = newPos;
        tmpNodes.Add(newNode03);

        // spawn node  0,4 
        newPos = new Vector3(tmpx - maxX, tmpy, tmpz - minY);
        var newNode04 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode04.transform.position = newPos;
        tmpNodes.Add(newNode04);

        /*===================== X = 1 =========================*/

        // spawn node 1,0
        newPos = new Vector3(tmpx - maxX / 2, tmpy, tmpz + minY);
        var newNode10 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode10.transform.position = newPos;
        tmpNodes.Add(newNode10);

        // spawn node  1,1 
        newPos = new Vector3(tmpx + minX / 2, tmpy, tmpz + minY / 2);
        var newNode11 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode11.transform.position = newPos;
        tmpNodes.Add(newNode11);

        // spawn node 1,2
        newPos = new Vector3(tmpx + minX / 2, tmpy, tmpz);
        var newNode12 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode12.transform.position = newPos;
        tmpNodes.Add(newNode12);

        // spawn node  1,3 
        newPos = new Vector3(tmpx - maxX / 2, tmpy, tmpz - minY / 2);
        var newNode13 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode13.transform.position = newPos;
        tmpNodes.Add(newNode13);

        // spawn node 1,4
        newPos = new Vector3(tmpx - maxX / 2, tmpy, tmpz - minY);
        var newNode14 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode14.transform.position = newPos;
        tmpNodes.Add(newNode14);

        /*===================== X = 2 =========================*/

        // spawn node 2,0 
        newPos = new Vector3(tmpx, tmpy, tmpz - maxY);
        var newNode20 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode20.transform.position = newPos;
        tmpNodes.Add(newNode20);
       
        // spawn node 2,1
        newPos = new Vector3(tmpx, tmpy, tmpz + minY / 2);
        var newNode21 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode21.transform.position = newPos;
        tmpNodes.Add(newNode21);
        
        // spawn node 2,2
        newPos = new Vector3(tmpx, tmpy, tmpz);
        var newNode22 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode22.transform.position = newPos;
        tmpNodes.Add(newNode22);

        // spawn node 2,3
        newPos = new Vector3(tmpx, tmpy, tmpz - minY / 2);
        var newNode23 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode23.transform.position = newPos;
        tmpNodes.Add(newNode23);

        // spawn node 2,4 
        newPos = new Vector3(tmpx, tmpy, tmpz + maxY);
        var newNode24 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode24.transform.position = newPos;
        tmpNodes.Add(newNode24);

        /*===================== X = 3 =========================*/

        // spawn node 3,0
        newPos = new Vector3(tmpx - minX / 2, tmpy, tmpz - maxY);
        var newNode30 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode30.transform.position = newPos;
        tmpNodes.Add(newNode30);

        // spawn node  3,1 
        newPos = new Vector3(tmpx + maxX / 2, tmpy, tmpz + minY / 2);
        var newNode31 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode31.transform.position = newPos;
        tmpNodes.Add(newNode31);

        // spawn node 3,2
        newPos = new Vector3(tmpx - minX / 2, tmpy, tmpz);
        var newNode32 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode32.transform.position = newPos;
        tmpNodes.Add(newNode32);

        // spawn node  3,3 
        newPos = new Vector3(tmpx - minX / 2, tmpy, tmpz - minY / 2);
        var newNode33 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode33.transform.position = newPos;
        tmpNodes.Add(newNode33);

        // spawn node 3,4
        newPos = new Vector3(tmpx - minX / 2, tmpy, tmpz + maxY);
        var newNode34 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode34.transform.position = newPos;
        tmpNodes.Add(newNode34);

        /*===================== X = 4 =========================*/

        // spawn node 4,0
        newPos = new Vector3(tmpx - minX, tmpy, tmpz - maxY);
        var newNode40 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode40.transform.position = newPos;
        tmpNodes.Add(newNode40);

        // spawn node 4,1
        newPos = new Vector3(tmpx + maxX, tmpy, tmpz + minY / 2);
        var newNode41 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode41.transform.position = newPos;
        tmpNodes.Add(newNode41);

        // spawn node 4,2 
        newPos = new Vector3(tmpx + maxX, tmpy, tmpz);
        var newNode42 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode42.transform.position = newPos;
        tmpNodes.Add(newNode42);
        
        // spawn node 4,3
        newPos = new Vector3(tmpx + maxX, tmpy, tmpz - minY / 2);
        var newNode43 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode43.transform.position = newPos;
        tmpNodes.Add(newNode43);

        // spawn 4,4 
        newPos = new Vector3(tmpx - minX, tmpy, tmpz - minY);
        var newNode44 = Instantiate<GameObject>(nodePrefab, this.transform);
        newNode44.transform.position = newPos;
        tmpNodes.Add(newNode44);

        /*===================== End Manual Node Generatation =========================*/

        //looped node spawn
        //only works in same location currently
        while (nodes.Count != nodeCount)
        {
            newPos = new Vector3(tmpx - maxX + maxX, tmpy, tmpz - maxY + maxY);
            var newNode = Instantiate<GameObject>(nodePrefab, this.transform);
            newNode.transform.position = newPos;
            tmpNodes.Add(newNode);
        }

        return tmpNodes;
    }
    
    // check to see it mouse position is within node bounds
    private bool GetMouseClick()
    {
        foreach (GameObject node in nodes)
        {
            bool pass0 = false;
            bool pass1 = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                var mouseX = Input.mousePosition.x;
                var mouseY = Input.mousePosition.y;
                var nodeX = node.transform.position.x;
                var nodeZ = node.transform.position.z;
                // within 22.5 of the center of node on x axis
                // if mouse x is <= node x + 22.5 and  mouse x is >= node z - 22.5
                if (mouseX <= nodeX + 22.5 && mouseX >= nodeX - 22.5)
                {
                    pass0 = true;
                }
                // within 22.5 of the center of node on y/z axis
                // if mouse y is <= node y + 22.5 and  mouse y is >= node z - 22.5
                if (mouseY <= nodeZ + 22.5 && mouseY >= nodeZ - 22.5)
                {
                    pass1 = true;
                }
                if (pass0 == true && pass1 == true)
                {
                    var nodex1 = node.transform.position.x;
                    var nodey1 = node.transform.position.y;
                    var nodez1 = node.transform.position.z;
                    Vector3 playerPos1 = new Vector3(nodex1, nodey1 + 5f, nodez1);
                    actualPlayerObject.transform.position = playerPos1;

                    return true;
                }
            }
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {
        // initialize node list
        nodes = new List<GameObject>();

        // store the amount of nodes in list
        nodeCount = (int)gridSize.x * (int)gridSize.y;       

        // Generate the groundPlane and node objects
        nodes = GenerateGrid();        

        // random player player start node
        int index = Random.Range(0, nodes.Count);
        playerStartNode = nodes[index];

        // fixed player player start node
        //playerStartNode = nodes[0];

        // instantiate the player at start node position
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
        // mouse click inside the nodes to move the player to its location
        if (Input.GetMouseButtonDown(0))
        {
            GetMouseClick();
        }
        Debug.Log(Input.mousePosition);

        //// randomized player movement        
        //int index = Random.Range(0, nodes.Count);
        //playerStartNode = nodes[index];
        //var nodex = playerStartNode.transform.position.x;
        //var nodey = playerStartNode.transform.position.y;
        //var nodez = playerStartNode.transform.position.z;
        //Vector3 playerPos = new Vector3(nodex, nodey + 5f, nodez);
        //actualPlayerObject.transform.position = playerPos;
    }
}
