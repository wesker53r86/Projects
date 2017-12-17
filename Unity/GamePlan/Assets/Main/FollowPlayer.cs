using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public Transform target2;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (target&&target2) {
			Camera c=Camera.main;
			Vector3 point = c.WorldToViewportPoint(target.position);
			Vector3 targs = (target2.position + target.position) / 2;
			Vector3 sizerr = target.position - target2.position;
			/*if (targs.x < 0) {
				targs.x = targs.x * -1;
			}
			if (targs.y < 0) {
				targs.y = targs.y * -1;
			}
			if (targs.z < 0) {
				targs.z = targs.z * -1;
			}*/
			Vector3 delta = targs - c.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,  point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			float item1 = Mathf.Abs((float)sizerr.x);
			float item2 = Mathf.Abs ((float)sizerr.y);
			float sizer;
			if (item1 > item2) {
				sizer = item1;
			} else {
				sizer = item2;
			}
			if ((sizer/2) > 5) {
				c.orthographicSize = sizer/2;
			} else {
				c.orthographicSize = 5;
			}
		}
		
	}
}
