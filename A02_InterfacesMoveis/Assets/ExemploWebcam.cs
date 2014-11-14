using UnityEngine;
using System.Collections;

public class ExemploWebcam : MonoBehaviour {

	WebCamTexture camTex;
	public Transform quad;

	// Use this for initialization
	void Start () {
		camTex = new WebCamTexture(300, 200, 15);
		camTex.Play();
		quad.renderer.material.SetTexture("_MainTex", camTex);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
