using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Obj))]
public class ObjEditor : Editor
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