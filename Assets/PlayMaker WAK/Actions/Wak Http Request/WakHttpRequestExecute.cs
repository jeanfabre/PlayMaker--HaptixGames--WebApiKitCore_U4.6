// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Web Player")]
	[Tooltip("Gets data from a url and store it in variables. See Unity WWW docs for more details.")]
	public class WakHttpRequestExecute : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayMakerWakHttpRequest))]
		[Tooltip("The Game Object with the PlayMaker Wak Http Request component")]
		public FsmGameObject gameObject;

		[RequiredField]
		[Tooltip("Url to call. Leave to none to use the default")]
		public FsmString url;
		
		[ActionSection("Results")]
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Gets text from the url.")]
		public FsmString storeText;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Gets a Texture from the url.")]
		public FsmTexture storeTexture;

		/* could this be supported?
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(MovieTexture))]
		[Tooltip("Gets a Texture from the url.")]
		public FsmObject storeMovieTexture;
		*/
		[UIHint(UIHint.Variable)]
		[Tooltip("Error message if there was an error during the download.")]
		public FsmString errorString;
		
		[UIHint(UIHint.Variable)] 
		[Tooltip("How far the download progressed (0-1).")]
		public FsmFloat progress;
		
		[ActionSection("Events")] 
		
		[Tooltip("Event to send when the data has finished loading (progress = 1).")]
		public FsmEvent isDone;
		
		[Tooltip("Event to send if there was an error.")]
		public FsmEvent isError;

		public override void Reset()
		{
			gameObject = null;
			url = new FsmString(){UseVariable=true};
			storeText = null;
			storeTexture = null;
			errorString = null;
			progress = null;
			isDone = null;
		}
		
		public override void OnEnter()
		{
			if (string.IsNullOrEmpty(url.Value))
			{
				Finish();
				return;
			}
			
			//wwwObject = new WWW(url.Value);
		}
		
		/*
		public override void OnUpdate()
		{
			if (wwwObject == null)
			{
				errorString.Value = "WWW Object is Null!";
				Finish();
				return;
			}
			
			errorString.Value = wwwObject.error;
			
			if (!string.IsNullOrEmpty(wwwObject.error))
			{
				Finish();
				Fsm.Event(isError);
				return;
			}
			
			progress.Value = wwwObject.progress;
			
			if (progress.Value.Equals(1f))
			{
				storeText.Value = wwwObject.text;
				storeTexture.Value = wwwObject.texture;
				
				storeMovieTexture.Value = wwwObject.movie;
				
				errorString.Value = wwwObject.error;
				
				Fsm.Event(string.IsNullOrEmpty(errorString.Value) ? isDone : isError);
				
				Finish();
			}
		}
		*/
	}
}