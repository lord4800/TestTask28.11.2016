using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveTo : MonoBehaviour {
	private Transform waypoints;
	private Transform waypoint;
	private int waypointIndex = -1;
	public Transform firstpoint;

	NavMeshAgent agent;
	// Use this for initialization
	void Start () 
	{
		
		waypoints = GameObject.Find("WayPoints").transform;
		moveTo(firstpoint);
		agent = GetComponent<NavMeshAgent>();

	}


	void moveTo(Transform _goal)
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = _goal.position;
	}
	public void newWayPoint(List<Transform> list)
	{
		//waypointIndex = Random.Range(0, list.Count); 
		moveTo(list[0]);
	}

}
