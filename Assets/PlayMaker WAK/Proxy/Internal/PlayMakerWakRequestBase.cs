using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using hg.ApiWebKit;

using HutongGames.PlayMaker.Ecosystem.Utils;

[Serializable]
public class RequestDataEntry
{

	public string key = "";
	public string value = "";

	public RequestDataEntry(string Key)
	{
		this.key = Key;
	}

	public RequestDataEntry(string Key,string Value)
	{
		this.key = Key;
		this.value = Value;
	}
	
}

[Serializable]
public class RequestHeaderEntry
{
	public string key;
	public string value;

	public RequestHeaderEntry(string Key)
	{
		this.key = Key;
	}
	
	public RequestHeaderEntry(string Key,string Value)
	{
		this.key = Key;
		this.value = Value;
	}
	
}

public abstract class PlayMakerWakRequestBase : MonoBehaviour {


	public List<RequestDataEntry> datas;

	public List<RequestHeaderEntry> Headers;


	/// <summary>
	/// The progress of the request. Ranges from 0 to 1.
	/// </summary>
	public float progress = 0f;

	public string errorMessage = "";

	public bool hasError = false;
	
	public bool inProgress= false;

	/// <summary>
	/// The text result of the request
	/// </summary>
	public string textResult;

	/// <summary>
	/// The texture result of the request
	/// </summary>
	public Texture textureResult;

	/// <summary>
	/// The movie texture result of the request
	/// </summary>
	public MovieTexture movieTextureResult;

	/// <summary>
	/// The audioClip result of the request
	/// </summary>
	public AudioClip audioClipResult;

	/// <summary>
	/// Call this method to proceed with the request operation
	/// </summary>
	public abstract void ExecuteRequest();


	/// <summary>
	/// Call this method to cancel the current request operation
	/// </summary>
	public abstract void CancelRequest();


	/// <summary>
	/// Used to remember the user preference for the inspector Unity Events toggle section
	/// </summary>
	public bool UnityEventSectionToggle = false;

	[SerializeField]
	public UnityEvent OnSuccess = new UnityEvent();
	
	[Serializable]
	public class OnFailureUnityEvent : UnityEvent<string>{}

	[SerializeField]
	public OnFailureUnityEvent OnFailure = new OnFailureUnityEvent();
	
	[SerializeField]
	public UnityEvent OnComplete = new UnityEvent();


	/// <summary>
	/// Used to remember the user preference for the inspector PlayMaker Events toggle section
	/// </summary>
	public bool PlayMakerEventSectionToggle = false;

	/// <summary>
	/// Common setup for PlayMaker Event Target
	/// </summary>
	public PlayMakerEventTarget EventTarget;

	[EventTargetVariable("EventTarget")]
	public PlayMakerEvent OnSuccessEvent = new PlayMakerEvent("none");

	[EventTargetVariable("EventTarget")]
	public PlayMakerEvent OnFailureEvent = new PlayMakerEvent("none");

	[EventTargetVariable("EventTarget")]
	public PlayMakerEvent OnCompleteEvent = new PlayMakerEvent("none");

	/// <summary>
	/// Used to remember the user preference for the inspector debug Events toggle section
	/// </summary>
	public bool DebugEventSectionToggle = false;

	/* not sure we need this if we have Unity Events and PlayMaker events. But delegates woudl be nice too in all cases.
	public virtual void OnSuccess(  core.http.HttpResponse response)
	{

		Debug.Log("Success");
	}
	
	private void OnFailure(core.http.HttpResponse response)
	{	
		Debug.Log("Faulted because: " + string.Join(" ; ", operation.FaultReasons.ToArray()));
	}
	
	private void OnComplete(core.http.HttpResponse response)
	{
		Debug.Log("Completed");
	}
	*/


}
