using UnityEngine;
using System.Collections;

public class MyInterface : MonoBehaviour
{

	private string menuName = "Menu";
	private bool mo_home = true;
	private bool mo_resolution;
	private bool mo_language;
	private bool mo_maptype;
	private bool  mo_quality;
	private bool mo_wheel;
	private bool mo_help;
	private bool sub_resolution;
	private bool sub_language;
	private bool sub_maptype;
	private bool  sub_quality;
	private bool sub_mark;
	string sec_resolution;
	string sec_language;
	string sec_quality;
	string sec_maptype;
	string modeName = "2D";
	private float posX;
	private float posY;
	float w_value;
	float h_value;
	float btn_rect_x;
	float btn_width;
	float btn_height;
	float Interval;
	private int selected = -1;
	Manager mg;
	Vector2 scrollPosition;
	
	void OnGUI ()
	{
		posX = Screen.width * 0.5f;
		posY = Screen.height * 0.5f;
		
		w_value = (posX - (posX * 0.4f * 0.5f)) * 0.5f;
		h_value = (posY - (posY * 0.52f * 0.5f)) * 0.5f;
			
		btn_rect_x = w_value * 0.5f * 0.1f;
		btn_width = w_value * 0.9f;
		btn_height = h_value * 0.3f;
		
		Interval = btn_height * 1.1f;
		
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		mg = GameObject.Find ("Manager").GetComponent<Manager> (); 
		
		Rect menuWindow_Rect = new Rect (posX * 0.01f, 54, posX * 0.4f, posY * 0.938f);
		GUI.Window (0, menuWindow_Rect, (GUI.WindowFunction)DoWindow, menuName);
		ActivateMenu (menuWindow_Rect);
	}
	
	void MainOption ()
	{
		mo_home = false;
		mo_resolution = false;
		mo_language = false;
		mo_maptype = false;
		mo_quality = false;
		mo_wheel = false;
		mo_help = false;
	}
	
	void SubOption ()
	{
		sub_resolution = false;
		sub_language = false;
		sub_maptype = false;
		sub_quality = false;
		//sub_wheel = false;
		scrollPosition = Vector2.zero;
	}
	
	void GoHome ()
	{
		MainOption ();
		SubOption ();
		menuName = "Menu";
		mo_home = true;
	}
	
	void DoWindow (int windowID)
	{
			
		Rect rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
		
		if (mo_home) {
			if (GUI.Button (rec, "Help")) {
				Vector3 pos = new Vector3 (0.74f, 0.13f, 0);
				Vector3 scale = new Vector3 (0.5f, 0.23f, 1);	
				mg.sy_CurrentStatus.isHelp = !mg.sy_CurrentStatus.isHelp;
				if (mg.sy_CurrentStatus.isHelp) {
					GameObject help = new GameObject ("Help");
					GUITexture _help = help.AddComponent (typeof(GUITexture))as GUITexture;
					_help.texture = Resources.Load ("UI/Help")as Texture;				
					_help.transform.position = pos;
					_help.transform.localScale = scale;
				} else {
					GameObject.Destroy (GameObject.Find ("Help"));
				}
			}
			rec.y += Interval;
			if (GUI.Button (rec, "Resolution")) {
				MainOption ();
				SubOption ();
				menuName = "Resolution";
				mo_resolution = true;
				sec_resolution = mg.sy_Map.resolution.ToString ();
				
			}
			rec.y += Interval;
			if (GUI.Button (rec, "Language")) { 
				MainOption ();
				SubOption ();
				menuName = "Language";
				mo_language = true;
				for (int i=0; i<langCode.Length; i++) {
					if (mg.sy_Map.language.Equals (langCode [i])) {
						sec_language = langTile [i];
						break;
					}
				}
			}
			rec.y += Interval;
			if (GUI.Button (rec, "Map Type")) {
				MainOption ();
				SubOption ();
				menuName = "Map Type";
				mo_maptype = true;
				sec_maptype = mg.sy_Map.maptype.ToString ();
			}
			rec.y += Interval;
			if (GUI.Button (rec, "Quality")) {
				MainOption ();
				SubOption ();
				menuName = "Quality";
				mo_quality = true;
				sec_quality = mg.sy_Map.quality.ToString ();
			}
			rec.y += Interval;
			if (GUI.Button (rec, "Wheel Speed")) {
				MainOption ();
				SubOption ();
				menuName = "Wheel Speed";
				mo_wheel = true;
			}
			rec.y += Interval;
			if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
				if (GUI.Button (rec, modeName + " Mode")) {
					if (mg.sy_CurrentStatus.is3DCam) {
						modeName = "2D";
						mg.GeneralMode ();
					} else {
						modeName = "3D";
						mg.VrMode ();
					}
				}
			} else {
				if (GUI.Button (rec, "Menual")) {
					MainOption ();
					SubOption ();
					menuName = "Menual";
					mo_help = true;
				}
			}
		}
		Op_GoHome ();
		Op_Resolution ();
		Op_Language ();
		Op_MapType ();
		Op_Quality ();
		Op_WheelSpeed ();
		Op_Help ();
	}
	
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Home Munue
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
	void Op_GoHome ()
	{
		Rect home_rec = new Rect (btn_rect_x, h_value * 2.18f, btn_width, btn_height);
		if (mo_resolution || mo_language || mo_maptype || mo_quality || mo_wheel || mo_help) {
			if (GUI.Button (home_rec, "Back")) {
				GoHome ();
			}
		}
	}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Resolution
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

	void Op_Resolution ()
	{
		string[] tile = new string[]{"high","low"};		
		if (mo_resolution) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
			if (GUI.Button (sub_rec, sec_resolution)) {
				sub_resolution = true;
			}
			sub_rec.y += Interval;
			if (sub_resolution) {
				DropDownList (tile.Length, sub_rec, Interval, tile, "resolution");
			}
		}	
	}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Language
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	string[] langTile = {"Afrikaans","Albanian","Basque","Belarusian","Bulgarian","Catalan","Chinese [Simplified]","Chinese [Traditional]","Croatian","Czech","Danish","Dutch","English","Estonian","Faeroese",
		"Finnish","French","Galician", "Gaelic","German","Greek","Hawaiian","Hungarian","Icelandic","Indonesian","Irish","Italian","Japanese","Korean","Macedonian","Norwegian","Polish","Portuguese","Romanian",
		"Russian","Serbian","Slovak","Slovenian","Spanish","Swedish","Turkish","Ukranian"};
	string[] langCode = {
		"af","sq","eu","be","bg","ca","zh-cn","zh-tw","hr","cs","da","nl","en","et","fo","fi","fr","gl","gd","de","el","haw","hu","is","in","ga","it","ja","ko","mk","no","pl","pt","ro","ru","sr","sk","sl","es","sv","tr","uk"};
	
	void Op_Language ()
	{	
		if (mo_language) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
			if (GUI.Button (sub_rec, sec_language)) {
				sub_language = true;
			}
			Rect rList = new Rect (0, 0, 0, (btn_height * langTile.Length) + ((Interval - btn_height) * langTile.Length));
			if (sub_language) {
				scrollPosition = GUI.BeginScrollView (new Rect (btn_rect_x, (h_value * 0.2f) + Interval, btn_width, h_value * 1.6f), scrollPosition, rList, false, false);
				
				sub_rec.y = 0;
				sub_rec.x = 0;
				sub_rec.width = btn_width * 0.9f;
				DropDownList (langTile.Length, sub_rec, Interval, langTile, "language");
				GUI.EndScrollView ();
			}
		
		}	
	}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  MapType
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	void Op_MapType ()
	{
			
		string[] tile = new string[]{"roadmap","satellite","hybrid","terrain"};
		if (mo_maptype) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
			if (GUI.Button (sub_rec, sec_maptype)) {
				sub_maptype = true;
			}
			sub_rec.y += Interval;
			if (sub_maptype) {
				DropDownList (tile.Length, sub_rec, Interval, tile, "maptype");
			}
		}	
	}
	
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Quality
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Op_Quality ()
	{
		string[] tile = new string[]{"high","low"};
		if (mo_quality) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
			if (GUI.Button (sub_rec, sec_quality)) {
				sub_quality = true;
			}
			sub_rec.y += Interval;
			if (sub_quality) {
				DropDownList (tile.Length, sub_rec, Interval, tile, "quality");
			}
		}	
	}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Wheel Speed
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

	void Op_WheelSpeed ()
	{
	
		if (mo_wheel) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);

			mg.sy_Map.wheelSpeed = GUI.HorizontalSlider (sub_rec, mg.sy_Map.wheelSpeed, 2, 10);
			GUI.Label (new Rect (btn_rect_x, h_value * 0.3f, btn_width, btn_height), "(Slow)");
			GUI.Label (new Rect (btn_rect_x * 8.1f, h_value * 0.3f, btn_width, btn_height), "(Normal)");
			GUI.Label (new Rect (btn_rect_x * 16.2f, h_value * 0.3f, btn_width, btn_height), "(Fast)");
			sub_rec.y += Interval;

		}	
	}
	
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////  Help
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void Op_Help ()
	{
		if (mo_help) {
			Rect sub_rec = new Rect (btn_rect_x, h_value * 0.2f, btn_width, btn_height);
			if (GUI.Button (sub_rec, "Homepage")) {
				Application.OpenURL("www.motivebuild.com");
			}
			sub_rec.y += Interval;
			if (GUI.Button (sub_rec, "Video")) {
				Application.OpenURL("http://www.motivebuild.com/bbs/board.php?bo_table=A03");
			}

		}	
	}
	
	void DropDownList (int numRows, Rect rec, float Interval, string[] tile, string option)
	{
		for (int i = 0; i < numRows; i++) {
			bool fClicked = false;
			string rowLabel = "( " + tile [i] + " )";
			if (i == selected) {
				fClicked = GUI.Button (rec, rowLabel);
			} else {
				fClicked = GUI.Button (rec, rowLabel);
			}
			if (fClicked) {
				SubOption ();
				ChangeValue (option, i);
			}
			rec.y += Interval;
		}
	}
	
	void ChangeValue (string option, int num)
	{
		if (option.Equals ("resolution")) {
			sec_resolution = mg.ChangeScreenResolution (num);
		} else if (option.Equals ("language")) {
			mg.sy_Map.language = langCode [num];
			sec_language = langTile [num];
			mg.RefreshMap ();
		} else if (option.Equals ("maptype")) {
			mg.sy_CurrentStatus.isMenu = true;
			sec_maptype = mg.ChangeType (num);
			mg.RefreshMap ();
		} else if (option.Equals ("quality")) {
			sec_quality = mg.ChangeQuality (num);
			mg.RefreshMap ();
		} else if (option.Equals ("wheel")) {
			//	sec_wheel = mg.ChangeWheelSpeed (num);
		} 
	}
	
	void ActivateMenu (Rect menuWindow_Rect)
	{
		if (Input.GetMouseButtonDown (0)) {
			if (Event.current != null && Event.current.isMouse) {
				if (menuWindow_Rect.Contains (Event.current.mousePosition)) {
					mg.sy_CurrentStatus.isMenu = true;
				} else {
					mg.sy_CurrentStatus.isMenu = false;
				}
			}
		}
	}
}