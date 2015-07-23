using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class PlayMakerWakHttpRequest : PlayMakerWakRequestBase {

	public enum RequestType {GET,POST};
	public string Uri ="http://www.example.com/test";

	public RequestType type = RequestType.GET;


	public bool RequestSectionToggle = false;

	public bool HeaderSectionToggle = false;

	public bool ConfigSectionToggle = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region implemented abstract members of PlayMakerWakRequestBase


	public override void ExecuteRequest ()
	{
		throw new System.NotImplementedException ();
	}


	public override void CancelRequest ()
	{
		throw new System.NotImplementedException ();
	}


	#endregion

}
