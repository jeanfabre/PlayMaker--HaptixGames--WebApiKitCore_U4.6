﻿
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


	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		if(_target==null)
		{
			_target = (PlayMakerWakHttpRequest)target;
		}

		_target.Uri = EditorGUILayout.TextField("Uri",_target.Uri);

		_target.RequestSectionToggle = EditorGUILayout.Foldout(_target.RequestSectionToggle,"Data");
		
		if (_target.RequestSectionToggle)
		{
			EditorGUI.indentLevel++;
			ReorderableListGUI.Title("Data");
					

			EditorGUI.BeginChangeCheck();
			ReorderableListGUI.ListField(_target.datas,DrawDataEntryItem,38);
			
			if (EditorGUI.EndChangeCheck())
			{
				Debug.Log("change");
				EditorUtility.SetDirty(_target);
			}


			EditorGUI.indentLevel--;
		}

		_target.HeaderSectionToggle = EditorGUILayout.Foldout(_target.HeaderSectionToggle,"Headers");
	
		if (_target.HeaderSectionToggle)
		{
			EditorGUI.indentLevel++;
				ReorderableListGUI.Title("Headers");
			/*
			EditorGUI.BeginChangeCheck();
			ReorderableListGUI.ListField
			
			if (EditorGUI.EndChangeCheck())
			{
				Debug.Log("change");
				EditorUtility.SetDirty(_target);
			}
			*/
			GUILayout.TextField("here goes a list of headers/values");
			GUILayout.Space(10);
			EditorGUI.indentLevel--;
		}

		_target.UnityEventSectionToggle = EditorGUILayout.Foldout(_target.UnityEventSectionToggle,"Unity Events");
		
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

		_target.PlayMakerEventSectionToggle = EditorGUILayout.Foldout(_target.PlayMakerEventSectionToggle,"PlayMaker Events");
		
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

		GUILayout.Space(10);
		if (GUILayout.Button("Test"))
		{
			// here we would make the http request and log the result.
		}

		GUILayout.TextArea("-- preview of the result -- ");

	}


	private RequestDataEntry DrawDataEntryItem(Rect position, RequestDataEntry value) {
		
		if (value==null)
		{
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

}

