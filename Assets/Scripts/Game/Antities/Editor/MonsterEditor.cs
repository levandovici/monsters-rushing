using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Monster))]
public class MonsterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        Antity antity = (Antity)target;

        if (GUILayout.Button("Generate GUID"))
        {
            antity.NewGUID();
            EditorUtility.SetDirty(target);
        }
    }
}