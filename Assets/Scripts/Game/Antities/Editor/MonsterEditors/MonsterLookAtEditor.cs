using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Target;

[CustomEditor(typeof(MonsterLookAtComponent))]
public class MonsterLookAtEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MonsterLookAtComponent lookAt = (MonsterLookAtComponent)target;

        MonsterTargetComponent trgt = lookAt.GetComponent<MonsterTargetComponent>();

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