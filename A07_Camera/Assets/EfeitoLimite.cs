using UnityEngine;
using System.Collections;

public class EfeitoLimite : MonoBehaviour
{
		public float limite;
		private WebCamTexture webTex;
		
		private Color[] ultimoFrame;
		private Texture2D novaTex;
		
		private float mudou;
		private float total;
		public float variacao;
		
		public float limiteAlarme;

		void Start ()
		{
				webTex = GetComponent<MostrarWebcam> ().webTex;
				novaTex = new Texture2D (320, 240);
				ultimoFrame = null;
		}
	
		void Update ()
		{
				if (webTex.didUpdateThisFrame) {
						mudou = 0;
						Color[] pixels = webTex.GetPixels ();
						if (ultimoFrame == null) {
								ultimoFrame = new Color[pixels.Length];
						}
						for (int i = 0; i < pixels.Length; i++) {
								if (pixels [i].grayscale >= limite) {
										pixels [i] = Color.clear;
								} else {
										pixels [i] = Color.black;
								}
								if (pixels [i] != ultimoFrame [i]) {
										mudou++;
								}
						}
						variacao = mudou / pixels.Length;
						// ultimo frame recebe frame atual
						ultimoFrame = pixels;
						novaTex.SetPixels (pixels);
						novaTex.Apply ();
						renderer.material.SetTexture ("_MainTex", novaTex);
						if (variacao >= limiteAlarme) {
								Debug.Log ("Perdeu o jogo!");
						}
				}
				
		}
}

