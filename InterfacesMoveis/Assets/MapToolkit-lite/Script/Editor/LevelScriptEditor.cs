#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(Manager))]
public class LevelScriptEditor : Editor
{
	
		public enum License
	{
		GoogleMapsAPI,
		GoogleMapsAPI_forBusiness
	};
	
	public enum ScreenResolution
	{
		High,
		Low
	};

	public enum MapQuality
	{
		High,
		Low
	};
	
	public enum MapType
	{
		Roadmap,
		Satellite,
		Hybrid,
		Terrain
	};
	
	public enum MarkAccess
	{
		Local,
		Web
	};

	public enum BuildingAccess
	{
		Local,
		Web
	};
	
	public enum Orientation
	{
		Portrait,
		Landscape
	};
	
	
	Manager mg;
	ScreenResolution resolution;
	License license;
	MapQuality quality;
	MapType maptype;
	float  wheelSpeed;
	MarkAccess markAccess;
	BuildingAccess buildingAccess;
	bool _isCompile;
		private Orientation ori;
	
	public override void OnInspectorGUI ()
	{

		mg = (Manager)target;
			
		if (GUI.GetNameOfFocusedControl () == null)
			GUI.FocusControl ("");
		
		if(mg.sy_Map != null && mg.sy_CurrentStatus != null &&mg.sy_Editor != null && mg.sy_Map != null && mg.sy_OtherOption != null){

		GUILayout.Space (6f);
		GUI.backgroundColor = Color.black;
		GUIStyle myButtonStyle = new GUIStyle (GUI.skin.box);
		myButtonStyle.normal.textColor = Color.white;
		GUILayout.Box ("Google Maps API licensing", myButtonStyle, GUILayout.ExpandWidth (true));
		GUI.backgroundColor = Color.white;	
		GUILayout.Space (6f);
		
			//License

	    string str_license = System.Enum.GetName (typeof(License), mg.sy_Editor.license);
		license = (License)System.Enum.Parse (typeof(License), str_license);
		mg.sy_Editor.license = (int)(License)EditorGUILayout.EnumPopup ("License", license);

		if(license == License.GoogleMapsAPI){
			mg.sy_Map.apikey[0] =EditorGUILayout.TextField (" ▶API Key",mg.sy_Map.apikey[0]);
			mg.sy_Map.apikey[1]="";
			mg.sy_Map.apikey[2]="";
		}
		else if(license == License.GoogleMapsAPI_forBusiness){
			mg.sy_Map.apikey[0]="";
			mg.sy_Map.apikey[1] =EditorGUILayout.TextField (" ▶Client ID",mg.sy_Map.apikey[1]);
			mg.sy_Map.apikey[2]=EditorGUILayout.TextField (" ▶Signature", mg.sy_Map.apikey[2]);
		}

		if(mg.sy_Map.apikey[0].Length<5 &&( mg.sy_Map.apikey[1].Length<5 ||mg.sy_Map.apikey[2].Length<5)){
			GUI.enabled = false;
		}
		GUILayout.Space (6f);
		GUI.backgroundColor = Color.black;
		myButtonStyle.normal.textColor = Color.white;
		GUILayout.Box ("Coordinates Setting", myButtonStyle, GUILayout.ExpandWidth (true));
		GUI.backgroundColor = Color.white;	
		GUILayout.Space (6f);
		
		if(mg.sy_Editor !=null){
		mg.sy_Editor.longitude_x = EditorGUILayout.TextField ("longitudeX", mg.sy_Editor.longitude_x);
		mg.sy_Editor.latitude_y = EditorGUILayout.TextField ("latitudeY", mg.sy_Editor.latitude_y);
		mg.sy_Editor.zoom = EditorGUILayout.IntField ("Zoom", mg.sy_Editor.zoom);
		}
		

		BeginContents ();

		 mg.sy_Map.language = EditorGUILayout.TextField ("Language", mg.sy_Map.language);
		
		//ScreenResolution

		string str_resolution = System.Enum.GetName (typeof(ScreenResolution), mg.sy_Editor.resolution);
		resolution = (ScreenResolution)System.Enum.Parse (typeof(ScreenResolution), str_resolution);
		mg.sy_Editor.resolution = (int)(ScreenResolution)EditorGUILayout.EnumPopup ("Resolution", resolution);
		
		//MapQuality
		string str_quality = System.Enum.GetName (typeof(MapQuality), mg.sy_Editor.quality);
		quality = (MapQuality)System.Enum.Parse (typeof(MapQuality), str_quality);
		mg.sy_Editor.quality = (int)(MapQuality)EditorGUILayout.EnumPopup ("Quality", quality);
		
		//MapType
		string str_maptype = System.Enum.GetName (typeof(MapType), mg.sy_Editor.maptype);
		maptype = (MapType)System.Enum.Parse (typeof(MapType), str_maptype);
		mg.sy_Editor.maptype = (int)(MapType)EditorGUILayout.EnumPopup ("Map type", maptype);
		
		//WheelSpeed
		mg.sy_Map.wheelSpeed=EditorGUILayout.Slider("Wheel Speed",mg.sy_Map.wheelSpeed,2,10);

		EndContents ();
	#if UNITY_ANDROID || UNITY_IPHONE		
				string str_ori = System.Enum.GetName (typeof(Orientation), mg.sy_Editor.ori);
		ori = (Orientation)System.Enum.Parse (typeof(Orientation), str_ori);
		mg.sy_Editor.ori = (int)(Orientation)EditorGUILayout.EnumPopup ("Default Orientation", ori);
			GUILayout.Space (6f);
#endif 
				#if UNITY_WEBPLAYER
			mg.sy_Map.phpurl = EditorGUILayout.TextField ("PHP URL", mg.sy_Map.phpurl );
			GUILayout.Space (6f);
			#endif 
		}
	}
	
	static public void BeginContents ()
	{
		GUILayout.BeginHorizontal ();
		GUILayout.Space (5f);
		EditorGUILayout.BeginHorizontal ("AS TextArea", GUILayout.MinHeight (10f));
		GUILayout.BeginVertical ();
		GUILayout.Space (5f);
	}

	static public void EndContents ()
	{
		GUILayout.Space (5f);
		GUILayout.EndVertical ();
		EditorGUILayout.EndHorizontal ();
		GUILayout.Space (5f);
		GUILayout.EndHorizontal ();
		GUILayout.Space (5f);
	}
}
#endif