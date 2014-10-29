using UnityEngine;
using System.Collections;

public class ExemploToque : MonoBehaviour {

	public Vector2 origem;
	public Vector2 posAtual;
	public Vector2 diferenca;

	void Start () {
		Input.multiTouchEnabled = false;
	}
	
	void Update () {
		if(Input.touchCount > 0)
		{
			// se acabou de comecar o toque
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				origem = Input.GetTouch(0).position;
				posAtual = origem;
			}
			
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				posAtual = Input.GetTouch(0).position;
				diferenca = posAtual - origem;
				Debug.DrawRay (Vector3.zero, diferenca, Color.red);
			}
			
			print(Input.GetTouch(0).position);
		}
	}
}
