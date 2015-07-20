
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
			/*
			EditorGUI.BeginChangeCheck();
			ReorderableListGUI.ListField
			
			if (EditorGUI.EndChangeCheck())
			{
				Debug.Log("change");
				EditorUtility.SetDirty(_target);
			}
			*/
			GUILayout.TextField("here goes a list of key/values");
			GUILayout.Space(10);
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

		GUILayout.Space(10);
		if (GUILayout.Button("Test"))
		{
			// here we would make the http request and log the result.
		}

		GUILayout.TextArea("-- preview of the result -- ");
	}
	/*
	private ColorReference DrawListItem(Rect position, ColorReference value) {
		
		if (value==null)
		{
			
			value =  new ColorReference("Color "+ (_target.References.Count),_target.NextUid);
			_target.NextUid ++;
		}
		
		if (value.Editable)
		{
			value.Name = EditorGUI.TextField(position,value.Name);
		}else{
			GUI.Label(position,value.Name);
		}
		return value;
	}
	*/
}

