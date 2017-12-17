using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts{
	public class ExecuteAction : MonoBehaviour {

		//private Rigidbody2D charar;
		// Use this for initialization
		void Start () {
			//charar = GetComponent<Rigidbody2D> ();
		}
		
		// Update is called once per frame
		void Update () {
			/*if (transform.rotation != new Quaternion (0, 0, 0, 0)) {
				transform.rotation = new Quaternion (0, 0, 0, 0);
			}*/
		}




		public void Move(float xmov,float ymov)
		{
			Rigidbody2D charar=GetComponent<Rigidbody2D> ();
			SpriteRenderer AGC = GetComponent<SpriteRenderer> ();
			if (charar == null) {
				System.Console.WriteLine ("error");
			} else {
				if (xmov < 0&&ymov<=0) {
					AGC.flipX = true;
				} 
				else if(xmov>0&&ymov<=00){
					AGC.flipX = false;
				}
				charar.velocity = charar.velocity + new Vector2 (xmov, ymov);


			}
		}
	}
}