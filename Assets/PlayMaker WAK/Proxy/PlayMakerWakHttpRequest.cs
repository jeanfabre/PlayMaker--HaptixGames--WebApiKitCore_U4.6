using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayMakerWakHttpRequest : MonoBehaviour {

	public enum RequestType {GET,POST};
	public string Uri ="http://www.example.com/test";

	public RequestType type = RequestType.GET;


	public bool RequestSectionToggle = false;

	public bool HeaderSectionToggle = false;

	public List<PlayMakerWakHeaderDefinition> Headers;

	public bool ConfigSectionToggle = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
