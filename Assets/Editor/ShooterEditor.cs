using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Shooter))]
public class ShooterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("AI", EditorStyles.boldLabel);
        
        var shooter = target as Shooter;

        shooter.useAI = EditorGUILayout.Toggle("Use AI", shooter.useAI);

        using (new EditorGUI.DisabledScope(!shooter.useAI))
        {
            shooter.firingDelayVariance = EditorGUILayout.FloatField("Firing Delay Variance", shooter.firingDelayVariance);
            shooter.minimumFiringDelay = EditorGUILayout.FloatField("Minimum Firing Delay", shooter.minimumFiringDelay);
        }
    }
}
