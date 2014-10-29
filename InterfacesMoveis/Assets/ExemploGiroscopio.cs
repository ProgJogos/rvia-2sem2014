using UnityEngine;
using System.Collections;

public class ExemploGiroscopio : MonoBehaviour 
{

	void Start () 
	{
		// ligando o gyro
		Input.gyro.enabled = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	void Update () 
	{
		
		Debug.DrawRay(Vector3.zero, Input.gyro.gravity, Color.red);
	}
}
