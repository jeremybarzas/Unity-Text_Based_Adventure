using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public Vector2 gridSize;
    public GameObject groundPlanePrefab;
    public GameObject nodePrefab;    
    public GameObject playerPrefab;

    private GameObject tmpNode;

    private GameObject playerStartNode;
    private List<GameObject> nodes;
	
    // Use this for initialization
	void Start()
    {
        // ground plane spawn
        Instantiate<GameObject>(groundPlanePrefab, this.transform);
        nodes = new List<GameObject>();

        // set up limtis of grid size
        int nodeCount = (int)gridSize.x * (int)gridSize.y;
        float maxX = ((gridSize.x - 1) / 2) * 22.5f;
        float maxY = ((gridSize.y - 1) / 2) * 22.5f;
        float minX = ((gridSize.x - 1) / 2) * -22.5f;
        float minY = ((gridSize.y - 1) / 2) * -22.5f;

        // node spawn
        while (nodes.Count != nodeCount)
        {
            var tmpx = nodePrefab.transform.position.x;
            var tmpy = nodePrefab.transform.position.y;
            var tmpz = nodePrefab.transform.position.z;
            var newNode = Instantiate<GameObject>(nodePrefab, this.transform);
            Vector3 newPos = new Vector3(tmpx - 45f, tmpy, tmpz - 45f);      
            newNode.transform.position = newPos;
            nodes.Add(newNode);
        }
        
        // randomized player spawn
        int index = Random.Range(0, nodeCount - 1);
        playerStartNode = nodes[index];

        // fixed player spawn
        playerStartNode = nodes[0];
        var nodex = playerStartNode.transform.position.x;
        var nodey = playerStartNode.transform.position.y;
        var nodez = playerStartNode.transform.position.z;
        var player = Instantiate<GameObject>(playerPrefab);
        Vector3 newPos2 = new Vector3(nodex, nodey + 5f, nodez);
        player.transform.position = newPos2;
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
