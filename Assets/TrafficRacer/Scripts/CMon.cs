using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CMon : MonoBehaviour
{
	public static CMon Instance;
	
			public Text scoreText;
	
	void Awake()
	{
		Instance = this;
		
	}
	int score;
	
	

	
	
	public void Score()
		{
			score++;
			scoreText.text = "Score "+ score;
			
		}
}
