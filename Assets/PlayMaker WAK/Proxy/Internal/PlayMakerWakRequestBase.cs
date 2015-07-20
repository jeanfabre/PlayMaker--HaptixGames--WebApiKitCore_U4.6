using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using hg.ApiWebKit;

public abstract class PlayMakerWakRequestBase : MonoBehaviour {

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


	[Serializable]
	public class OnSuccessEvent : UnityEvent<bool>
	{
	}
	
	[SerializeField]
	public OnSuccessEvent OnSuccess = new OnSuccessEvent();
	
	[SerializeField]
	public UnityEvent OnFailure = new UnityEvent();
	
	[SerializeField]
	public UnityEvent OnComplete = new UnityEvent();


	/*
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
