using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnragedState))]
public class RageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Start Rage"))
        {
            ((EnragedState)target).StartRage();
        }

        if (GUILayout.Button("Stop Rage"))
        {
            ((EnragedState)target).StopRage();
        }
    }
}
