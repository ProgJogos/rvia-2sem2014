#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class Menu_Editor : MonoBehaviour
{
	
		[MenuItem("Window/MapToolkit", false, 0)]
	static public void CreateManager ()
	{
		Camera.main.orthographic = true;
		Transform cam = Camera.main.transform;
		cam.position =new Vector3(0,1,0);
		cam.rotation = Quaternion.Euler(90,0,0);
		
		
		if(GameObject.Find ("Manager") ==null){
			GameObject mana = new GameObject("Manager");
		    mana.AddComponent("Manager");
		}else{
			if(GameObject.Find ("Manager").GetComponent<Manager>() ==null){
				GameObject mana = GameObject.Find ("Manager");
			mana.AddComponent("Manager");
			}
		}
	}
	
}
#endif