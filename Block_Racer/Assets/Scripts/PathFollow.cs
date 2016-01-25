using UnityEngine;
using System.Collections;

public class PathFollow : MonoBehaviour {
	
	public Path        path;
	public Transform   startPathNode;
	public Transform   nextNodeMarker;
	public int         currentNode = 0;
	
	// Use this for initialization
	void Start () {
		
		// If the user set the starting path node, find it here.
		for(int i = 0; i < path.nodes.Length; i++)
		{
			if(startPathNode == path.nodes[i])
			{
				currentNode = i;
				break;
			}
		}
		
		// nextNodeMarker is used by other components
		// to follow the path.
		if(!nextNodeMarker)
			nextNodeMarker = new GameObject().transform;
	}
	
	void Test(int nodeIndex, out float distance, out float dot, bool primary)
	{
		// Keep the index within the array.
		if(nodeIndex >= path.nodes.Length) nodeIndex = 0;
		if(nodeIndex < 0) nodeIndex = path.nodes.Length-1;
		
		// Get the nodes
		Transform curNode = path.nodes[nodeIndex];		
		Transform nextNode = path.nodes[(nodeIndex+1)%path.nodes.Length];
		
		// Do some math
		Vector3 difference = (nextNode.position - curNode.position);
		distance = difference.magnitude;
		Vector3 direction = difference / distance;
		
		// Dot is used to find out where the closest point on the line is
		// It gets the length, parallel to direction, of the difference between the current node and this.
		dot = Vector3.Dot(direction, transform.position - curNode.position);
		
		// This code is called at most twice - a primary call and a secondary call.
		if(primary) {
			// Draw lines showing what's going on.
			Debug.DrawLine(curNode.position,nextNode.position,Color.yellow);
			Debug.DrawLine(curNode.position + dot * direction, transform.position,Color.red);	
		}
		else
		{
			// Draw lines showing testing for the next node pair.
			Debug.DrawLine(curNode.position,nextNode.position,Color.grey);
			Debug.DrawLine(curNode.position + dot * direction, transform.position,Color.grey);
		}
	}
	
	// Update is called once per frame
	// This determines how far along we have travelled down the path.
	void Update () {
		
		// Determine how far along we are between A and B.
		float distance, dot;
		Test(currentNode, out distance, out dot, true);
		
		// Have we gone past B?
		if( dot > distance )
		{
			// Test to see if we will go between (or past) the next pair of waypoints.
			// This is done to prevent flicker when it isn't between either the current
			// or the next.
			Test(currentNode+1, out distance, out dot, false);
			
			// Are we in between the next set of waypoints (or past them)?
			if( dot >= 0 )
			{
				// Increase node index.
				currentNode++;
				
				// Keep it within array.
				if(currentNode >= path.nodes.Length) currentNode = 0;	
				
				// Move marker.
				nextNodeMarker.position = path.nodes[currentNode].position;
			}
			else
			{
				// Make the move-to position the average of the two nodes.
				int nextNode = currentNode+1;
				
				// Keep it within array.
				if(nextNode >= path.nodes.Length) nextNode = 0;
				
				nextNodeMarker.position = (path.nodes[currentNode].position + path.nodes[nextNode].position)/2;
			}
		}
		// Have we slipped before A?
		else if( dot < 0 )
		{
			// Test to see if we will go between (or past) the previous pair of waypoints.
			// This is done to prevent flicker when it isn't between either the current
			// or the previous.
			Test(currentNode-1, out distance, out dot, false);
			
			// Are we in between the previous set of waypoints (or past them)?
			if( dot <= distance )
			{
				// Decrease node index.
				currentNode--;
				
				// Keep it within array.
				if(currentNode < 0) currentNode = path.nodes.Length-1;
			
				// Move marker.
				nextNodeMarker.position = path.nodes[currentNode].position;
			}
			else
			{
				// Make the move-to position the average of the two nodes.
				int prevNode = currentNode-1;
				
				// Keep it within array.
				if(prevNode < 0) prevNode = path.nodes.Length-1;
				
				nextNodeMarker.position = (path.nodes[currentNode].position + path.nodes[prevNode].position)/2;
			}
		}
		else
		{
			nextNodeMarker.position = path.nodes[currentNode].position;
		}
	}
}
