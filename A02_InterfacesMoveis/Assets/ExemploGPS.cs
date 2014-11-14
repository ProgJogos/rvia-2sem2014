using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExemploGPS : MonoBehaviour {

	public float lat1 = -23.61652f;
	public float lon1 = -46.63878f;
	public float lat2 = -23.61652f;
	public float lon2 = -46.63878f;
	public float distancia;
	
	// Use this for initialization
	void Start () {
		Input.location.Start();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = Input.location.status.ToString();
		distancia = distance (lat1, lon1, lat2, lon2, 'K');
		if (Input.location.status == LocationServiceStatus.Running) 
		{
			/*
			GetComponent<Text>().text += "\nalt: " +
				Input.location.lastData.altitude.ToString() + 
					"\nlat: " + Input.location.lastData.latitude +
					"\nlon: " + Input.location.lastData.longitude;
			lat: -23.61652
			lon: -46.63878
			*/
			
		}
	}
	
	private float distance(float lat1, float lon1, float lat2, float lon2, char unit) {
		float theta = lon1 - lon2;
		float dist = Mathf.Sin(Mathf.Deg2Rad * lat1) * Mathf.Sin(Mathf.Deg2Rad * lat2) + 
			Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2) * Mathf.Cos(Mathf.Deg2Rad * theta);
		dist = Mathf.Acos(dist);
		dist = Mathf.Rad2Deg * dist;
		dist = dist * 60 * 1.1515f;
		if (unit == 'K') {
			dist = dist * 1.609344f;
		} else if (unit == 'N') {
			dist = dist * 0.8684f;
		}
		return (dist);
	}
	
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts decimal degrees to radians             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private float deg2rad(float deg) {
		return (deg * Mathf.PI / 180.0f);
	}
	
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts radians to decimal degrees             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private float rad2deg(float rad) {
		return (rad / Mathf.PI * 180.0f);
	}
}
