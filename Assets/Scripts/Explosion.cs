using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float TimeLife = 1f;
	float timerLife = 0;
	// Use this for initialization
	void Start () {
		timerLife = TimeLife;
	}
	
	// Update is called once per frame
	void Update () {
		timerLife -= Time.deltaTime;

		if (timerLife <= 0)
		{
			DestroyObject(gameObject);
		}
	}
}
