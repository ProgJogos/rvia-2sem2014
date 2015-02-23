using UnityEngine;
using System.Collections;

public class MostrarWebcam : MonoBehaviour
{

		public WebCamTexture webTex;
		void Awake ()
		{
				webTex = new WebCamTexture (
				320, 240, 30);
				//renderer.material.SetTexture (
				//"_MainTex",
				//webTex);
				webTex.Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
