using UnityEngine;
using System.Collections;

public class MoveSpikes : MonoBehaviour {
	
	public float speed = 2;
	public static float startSpikes = 3;
	public GameObject spikesCollider;
	
	// Update is called once per frame
	void Update () {
		if(Score.score >= startSpikes)
		{
			 StartCoroutine(WaitForSpikes());
			 transform.Translate(-Vector3.right * speed * Time.deltaTime);
		}
	}
	
	IEnumerator WaitForSpikes()
	{
		yield return new WaitForSeconds(3);	
		spikesCollider.SetActive(true);
	}
	
}
