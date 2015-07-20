// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("WAK")]
	[Tooltip("Gets data from a url and store it in variables. See Unity WWW docs for more details.")]
	public class WakHttpRequestExecute : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayMakerWakRequestBase))]
		[Tooltip("The Game Object with the PlayMaker Wak Request component")]
		public FsmOwnerDefault gameObject;

		
		[ActionSection("Results")]
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Gets text from the request.")]
		public FsmString storeText;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Gets a Texture from the requesst.")]
		public FsmTexture storeTexture;

		/* could this be supported?
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(MovieTexture))]
		[Tooltip("Gets a Texture from the request.")]
		public FsmObject storeMovieTexture;
		*/

		[UIHint(UIHint.Variable)]
		[Tooltip("Error message if there was an error during the download.")]
		public FsmString errorString;
		
		[UIHint(UIHint.Variable)] 
		[Tooltip("How far the request download progressed (0-1).")]
		public FsmFloat progress;

		[ActionSection("Events")]
		
		[Tooltip("Event to send when the request has successfully finished (progress = 1).")]
		public FsmEvent onSuccess;

		[Tooltip("Event to send when the request has finished (progress = 1).")]
		public FsmEvent onComplete;

		[Tooltip("Event to send if there was an error.")]
		public FsmEvent onFailure;


		PlayMakerWakRequestBase _wakRequestBase;

		public override void Reset()
		{
			gameObject = null;

			storeText = null;
			storeTexture = null;
			errorString = null;

			progress = null;

			onSuccess = null;
			onComplete = null;
			onFailure = null;
		}
		
		public override void OnEnter()
		{

			ExecuteRequest();
		}

		void ExecuteRequest()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			if (go == null)
			{
				errorString.Value = "GameObject is Null";
				Fsm.Event(onFailure);
				Finish();
				return;
			}

			_wakRequestBase = go.GetComponent<PlayMakerWakRequestBase>();
			if (_wakRequestBase == null)
			{
				errorString.Value = "PlayMakerWakRequestBase not found on GameObject"+go.name;
				Fsm.Event(onFailure);
				Finish();
				return;
			}

			_wakRequestBase.ExecuteRequest();

		}

		public override void OnUpdate()
		{
			if (_wakRequestBase==null)
			{
				return;
			}

			progress.Value = _wakRequestBase.progress;

			if (_wakRequestBase.progress.Equals(1f))
			{
				storeText.Value = _wakRequestBase.textResult;
				storeTexture.Value = _wakRequestBase.textureResult;
				
				//storeMovieTexture.Value = _wakRequestBase.movieTextureResult;

				//storeAudioClip.Value = _wakRequestBase.audioClipResult;

				errorString.Value = _wakRequestBase.errorMessage;
				
				Fsm.Event(string.IsNullOrEmpty(errorString.Value) ? onSuccess : onFailure);

				Fsm.Event(onComplete);
				
				Finish();
			}
		}

	}
}