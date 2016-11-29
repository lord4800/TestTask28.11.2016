using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	public float FindRadius = 2f;
	Ray r;
	float f;
	RaycastHit hit;

	public float TimeShot = 1f;

	public float speed = 0.05f;

	public GameObject rocket;

	public Camera cam;

	float timerShot;

	Transform enemy = null;

	Transform Head;
	// Use this for initialization
	void Start () {
		Head = GameObject.Find("GunCentr").GetComponent<Transform>();
		enemy = null;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemy == null)
		{
			findEnemy();
		}
		else
		{
			turnToEnemy();
			shot();
		}

	}

	void shot()
	{
		timerShot -= Time.deltaTime;

		if (timerShot <= 0)
		{
			timerShot = TimeShot;
			//TODO: make killing function
			Instantiate(rocket, Head.GetChild(0).transform.position, Head.transform.rotation);
			Instantiate(rocket, Head.GetChild(1).transform.position, Head.transform.rotation);
		}
	}

	void findEnemy()
	{
		
		Vector3 forward = transform.TransformDirection(Vector3.forward) * FindRadius;
		Vector3 vector;
		for (float h = -180.0f; h< 180.0f;h +=2f)
		{

			vector = Quaternion.AngleAxis(h, Vector3.up) * forward;

			if (Physics.Raycast(transform.position, vector, out hit, FindRadius, LayerMask.GetMask("Default")))
			{

				Debug.DrawLine(transform.position, hit.point, Color.green);
				if (hit.transform.tag == "Enemy")
				{
					enemy = hit.transform.GetComponent<Transform>();

				}

			}

		}

	}



	void turnToEnemy()
	{
		var difference = Quaternion.Angle(enemy.rotation,Head.rotation);
		if (difference > 1f){
			Head.rotation = Quaternion.Slerp(Head.rotation, Quaternion.LookRotation(enemy.position-Head.position) ,  speed);
			enemy = null;
		}
		else
		{
			Head.LookAt(enemy);
		}
	}

}

