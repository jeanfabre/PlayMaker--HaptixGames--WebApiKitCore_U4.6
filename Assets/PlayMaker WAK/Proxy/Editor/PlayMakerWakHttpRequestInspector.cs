
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using System.Linq;

using Rotorz.ReorderableList;


[CustomEditor(typeof(PlayMakerWakHttpRequest))]
public class PlayMakerWakHttpRequestInspector : Editor
{
	PlayMakerWakHttpRequest _target;

	Vector2 _previewScroll;


	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		if(_target==null)
		{
			_target = (PlayMakerWakHttpRequest)target;
		}

		_target.Uri = EditorGUILayout.TextField("Uri",_target.Uri);

		int _dataEntryCount = _target.datas.Count;
		_target.RequestSectionToggle = EditorGUILayout.Foldout(_target.RequestSectionToggle,"Data ("+_dataEntryCount+")");
		
		if (_target.RequestSectionToggle)
		{
			EditorGUI.indentLevel++;
			ReorderableListGUI.Title("Data");
					

			EditorGUI.BeginChangeCheck();
			ReorderableListGUI.ListField(_target.datas,DrawDataEntryItem,38);
			
			if (EditorGUI.EndChangeCheck())
			{
				EditorUtility.SetDirty(_target);
			}

			EditorGUI.indentLevel--;
		}

		int _headerEntryCount = _target.Headers.Count;
		_target.HeaderSectionToggle = EditorGUILayout.Foldout(_target.HeaderSectionToggle,"Headers ("+_headerEntryCount+")");
	
		if (_target.HeaderSectionToggle)
		{
			EditorGUI.indentLevel++;
			ReorderableListGUI.Title("Headers");

			EditorGUI.BeginChangeCheck();
			ReorderableListGUI.ListField(_target.Headers,DrawHeaderEntryItem,38);
			
			if (EditorGUI.EndChangeCheck())
			{
				EditorUtility.SetDirty(_target);
			}

			EditorGUI.indentLevel--;
		}

		_target.UnityEventSectionToggle = EditorGUILayout.Foldout(_target.UnityEventSectionToggle,"Unity Events (0)");
		
		if (_target.UnityEventSectionToggle)
		{
			SerializedProperty onSuccessProperty = serializedObject.FindProperty("OnSuccess");

			if (onSuccessProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(onSuccessProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}

			SerializedProperty onFailureProperty = serializedObject.FindProperty("OnFailure");
			
			if (onFailureProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(onFailureProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}
			SerializedProperty onCompleteProperty = serializedObject.FindProperty("OnComplete");
			
			if (onCompleteProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(onCompleteProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}
		}

		_target.PlayMakerEventSectionToggle = EditorGUILayout.Foldout(_target.PlayMakerEventSectionToggle,"PlayMaker Events (3)");
		
		if (_target.PlayMakerEventSectionToggle)
		{
			SerializedProperty EventTargetProperty = serializedObject.FindProperty("EventTarget");
			
			if (EventTargetProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(EventTargetProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}


			SerializedProperty OnSuccessEventProperty = serializedObject.FindProperty("OnSuccessEvent");
			
			if (OnSuccessEventProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(OnSuccessEventProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}

			SerializedProperty OnFailureEventProperty = serializedObject.FindProperty("OnFailureEvent");
			
			if (OnFailureEventProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(OnFailureEventProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}

			SerializedProperty OnCompleteEventProperty = serializedObject.FindProperty("OnCompleteEvent");
			
			if (OnCompleteEventProperty!=null)
			{
				EditorGUIUtility.LookLikeControls();
				EditorGUILayout.PropertyField(OnCompleteEventProperty);
				
				if(GUI.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}

		}

		_target.DebugEventSectionToggle = EditorGUILayout.Foldout(_target.DebugEventSectionToggle,"Debug");
		
		if (_target.DebugEventSectionToggle)
		{
			if (GUILayout.Button("Test"))
			{
				if (string.IsNullOrEmpty(_target.textResult))
				{
				_target.textResult = "This is just a test, doing nothing\n" +
					"But really it shoudl call the url, and display here the result";
				}else
				{
					_target.textResult = "";
				}
				// here we would make the http request and log the result.
			}

			if (!string.IsNullOrEmpty(_target.textResult))
			{
				GUILayout.Label("Preview of the result:");
				GUIStyle style = new GUIStyle(EditorStyles.textField);
				style.wordWrap = true;
				
				float height = style.CalcHeight(new GUIContent(_target.textResult), Screen.width);
				
				Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(height));

				rect.height += 4;
				GUI.skin.box.alignment = TextAnchor.UpperLeft;
				GUI.Box(rect,_target.textResult);
				//GUI.changed = false;
				//string text = EditorGUI.TextArea(rect, _target.textResult, style);
				if (GUI.changed)
				{
					//_target.textResult = text;
				}

				GUILayout.Space(4);
				/*
				_previewScroll = GUILayout.BeginScrollView(_previewScroll,"box", GUILayout.Height (200));
				GUI.skin.box.alignment = TextAnchor.UpperLeft;
				GUILayout.Box(_target.textResult,"label",null);
				GUILayout.EndScrollView();
				*/
			}

		}

	}


	private RequestDataEntry DrawDataEntryItem(Rect position, RequestDataEntry value) {
		
		if (value==null)
		{
			Debug.Log("hello");
			value =  new RequestDataEntry("Data "+ (_target.datas.Count));
		}

		// TODO: better handling of GUi Rect...
		Rect _keyPos = position;
		_keyPos.height /=2;

		Rect _keyPosLabel = _keyPos;
		_keyPosLabel.width = 36;
		GUI.Label(_keyPosLabel,"Key");
		_keyPos.x = _keyPos.x + _keyPosLabel.width/2;
		_keyPos.width -= _keyPosLabel.width/2;
		value.key = EditorGUI.TextField(_keyPos,value.key);


		Rect _valuePos = position;
		_valuePos.height /=2;
		_valuePos.y = position.y +_valuePos.height +2;

		Rect _valuePosLabel = _valuePos;
		_valuePosLabel.width = 36;
		GUI.Label(_valuePosLabel,"Value");
		_valuePos.x = _valuePos.x + _valuePosLabel.width/2;
		_valuePos.width -= _valuePosLabel.width/2;
		value.value = EditorGUI.TextField(_valuePos,value.value);
		 
		return value;
	}

	private RequestHeaderEntry DrawHeaderEntryItem(Rect position, RequestHeaderEntry value) {
		
		if (value==null)
		{
			value =  new RequestHeaderEntry("Header "+ (_target.Headers.Count));
		}
		
		// TODO: better handling of GUi Rect...
		Rect _keyPos = position;
		_keyPos.height /=2;
		
		Rect _keyPosLabel = _keyPos;
		_keyPosLabel.width = 36;
		GUI.Label(_keyPosLabel,"Key");
		_keyPos.x = _keyPos.x + _keyPosLabel.width/2;
		_keyPos.width -= _keyPosLabel.width/2;
		value.key = EditorGUI.TextField(_keyPos,value.key);
		
		
		Rect _valuePos = position;
		_valuePos.height /=2;
		_valuePos.y = position.y +_valuePos.height +2;
		
		Rect _valuePosLabel = _valuePos;
		_valuePosLabel.width = 36;
		GUI.Label(_valuePosLabel,"Value");
		_valuePos.x = _valuePos.x + _valuePosLabel.width/2;
		_valuePos.width -= _valuePosLabel.width/2;
		value.value = EditorGUI.TextField(_valuePos,value.value);
		
		return value;
	}

}

