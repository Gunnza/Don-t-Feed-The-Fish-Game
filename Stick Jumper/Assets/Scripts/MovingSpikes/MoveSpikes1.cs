using UnityEngine;
using System.Collections;

public class MoveSpikes1 : MonoBehaviour {
	
	public float speed = 2;
	

	// Update is called once per frame
	void Update () {
		
		if(Score.score >= MoveSpikes.startSpikes)
		{
		 	transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}
