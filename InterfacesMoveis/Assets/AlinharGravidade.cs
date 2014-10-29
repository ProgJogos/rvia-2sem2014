using UnityEngine;
using System.Collections;

public class AlinharGravidade : MonoBehaviour 
{
	public float suavizacao;

	void Start ()
	{
		Input.gyro.enabled = true;
		Physics.gravity = Input.gyro.gravity.normalized * -9.8f;
	}

	void Update () 
	{
		Vector3 diferenca = Vector3.up - Input.gyro.gravity;
		
		//transform.up = diferenca;
		
		transform.up = Vector3.Slerp(
			transform.up,
			Input.gyro.gravity,
			Time.deltaTime * suavizacao);
		
	}
}
