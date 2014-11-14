using UnityEngine;
using System.Collections;

public class ExemploAcelerometro : MonoBehaviour 
{	
	public float limite = 1f;
	
	public Vector3 gravidade;
	public float diferenca;
	
	void Start () 
	{
		
	}

	void Update () 
	{
		Debug.DrawRay(Vector3.zero, Input.acceleration, Color.green);
		
		if(Input.GetKeyDown(KeyCode.A)) {
			gravidade = Input.acceleration;
		}
		
		diferenca = Vector3.Angle(gravidade, Input.acceleration);
		//Debug.DrawRay(Vector3.zero, diferenca, Color.blue);
		
		
		if(diferenca > limite) 
		{
			Camera.main.backgroundColor = Color.red;
		}
		else
		{
			Camera.main.backgroundColor = Color.yellow;
		}
		
	}
}
