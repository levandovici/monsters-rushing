using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Target;

[CustomEditor(typeof(TowerLookAtComponent))]
public class TowerLookAtEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TowerLookAtComponent lookAt = (TowerLookAtComponent)target;

        TowerTargetComponent trgt = lookAt.GetComponent<TowerTargetComponent>();

        if(trgt != null)
        {
            if(trgt.FindTargetType == EFindTarget.Radius)
            {
                base.OnInspectorGUI();
            }
            else
            {
                GUILayout.Label("This component is not used,");
                GUILayout.Label("because TargetType is Forward!");
            }
        }
        else
        {
            base.OnInspectorGUI();
        }
    }
}