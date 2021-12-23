using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

	
	
    void OnTriggerEnter(Collider other)
	{
		
		
		if (other.tag == "Player")
		{
			
			CMon.Instance.Score();
			Destroy(this.gameObject);
		}
		/*/score++;
		print(score);
		Destroy(this.gameObject);/*/
	}
	
}
