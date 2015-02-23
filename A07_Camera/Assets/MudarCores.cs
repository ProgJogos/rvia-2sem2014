using UnityEngine;
using System.Collections;

public class MudarCores : MonoBehaviour
{

		public Color cor1;
		public Color cor2;
		public float tempo;
		private float timer;
		
		void Start ()
		{
				Camera.main.backgroundColor = cor1;
				timer = 0;
		}
	
		void Update ()
		{
				timer += Time.deltaTime;
				
				//Camera.main.backgroundColor = 
				
				/*HSBColor.Lerp (
					HSBColor.FromColor (cor1), 
					HSBColor.FromColor (cor2), 
					Mathf.Clamp01 (timer / tempo)).ToColor ();*/
				
				/*Color.Lerp (cor1, cor2,
			            Mathf.Clamp01 (timer / tempo));*/
			            
				if (timer > tempo) {
						timer = 0;
						Camera.main.backgroundColor = 
			   			HSBColor.ToColor (new HSBColor (
							0.5f,
							Random.value,
							0.7f));
				}
		}
}
