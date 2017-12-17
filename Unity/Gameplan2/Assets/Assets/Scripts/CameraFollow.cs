using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// manipulate the camera to follow two or more objects
	Vector3 delta;
	public float damp = 0.15f;
	Vector3 vel = Vector3.zero;
	Vector3 midtotal;
	public Transform[] players;
	Camera c;
	// Use this for initialization
	void Start () {
		c = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 less, more;
		int sizeofarray = players.Length;
		midtotal = players [0].position;
		less = players [0].position;
		more = players [0].position;
		for (int i = 1; i < sizeofarray; i++) {
			midtotal = (midtotal + players [i].position) / 2;
			less = Vector3.Min (players[i].position,less);
			more = Vector3.Max (players[i].position,more);
		}
		midtotal.z = -1;
		Vector3 sizee = (more - less);
		float sizer = sizee.x/2;
		if (sizer < sizee.y) {
			sizer = sizee.y;
		}
		if (sizer < 5) {
			sizer = 5;
		}
		c.orthographicSize = sizer / 2 + 1;
		transform.position = Vector3.SmoothDamp (transform.position, midtotal, ref vel, damp);

	}
}
