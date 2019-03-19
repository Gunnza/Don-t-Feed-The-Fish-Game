using UnityEngine;
using System.Collections;

public class SpikePooler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.gameObject.tag == ("SpikesBottom")) //Enemy hits pooler 
        {
            myTrigger.gameObject.transform.position = new Vector3(9.2f, -5.04f, 0); //rest positon of spikes at bottom
        }

        if (myTrigger.gameObject.tag == ("SpikesTop")) //Enemy hits pooler 
        {
            myTrigger.gameObject.transform.position = new Vector3(9.2f, 5.21f, 0); //rest positon of spikes at top
        }
    }


}