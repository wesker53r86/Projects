using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
	public class UserControl : MonoBehaviour {
		KeyCode key;
		ExecuteAction aa;
		float MovMod = 0.5f;
		float Jumpmod = 10f;
		// Use this for initialization
		void Start () {
			
			
		}
		
		// Update is called once per frame
		void Update () {
			Rigidbody2D charar = GetComponent<Rigidbody2D> ();
			aa = GetComponent<ExecuteAction> ();
			if (Input.anyKey) {
				if(Input.GetKey(KeyCode.A))
					{
						aa.Move(-MovMod,0);
					}
				if (Input.GetKey (KeyCode.D)) 
				{
					aa.Move (MovMod, 0);
				}
				if (Input.GetKey (KeyCode.Space)) {
					if (charar.velocity.y == 0) {
						aa.Move (0, Jumpmod);
					}
				}
			}




		}
	}
}
