using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public float Speed = 0.5f;
	public GameObject pref;
	public float TimeLife = 1f;



	float timerLife = 0;
	// Use this for initialization
	void Start () {
		timerLife = TimeLife;
	}

	void OnCollisionEnter(Collision collision) 
	{
		GameObject GO = collision.gameObject;
		ContactPoint contact = collision.contacts[0];
		if (GO.tag == "Enemy")
		{
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			DestroyObject(gameObject);
			Instantiate(pref, pos, rot);
			Instantiate(pref, pos, rot);
			Instantiate(pref, pos, rot);
			Instantiate(pref, pos, rot);
		}

	}
	// Update is called once per frame
	void Update () {
		timerLife -= Time.deltaTime;

		if (timerLife <= 0)
		{
			DestroyObject(gameObject);
		}
		transform.Translate(new Vector3(0,0,Speed));
	}
}
