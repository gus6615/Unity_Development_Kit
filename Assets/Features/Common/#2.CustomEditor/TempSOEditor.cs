using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TempSO))]
public class TempSOEditor : Editor
{
    TempSO _tempSO;

    int attackCol = TempSO.attackCol;
    int attackRow = TempSO.attackRow;
    bool[] attackRange;

    private void OnEnable()
    {
        _tempSO = target as TempSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("공격 범위");

        attackRange = _tempSO.AttackRange;

        for (int i = 0; i < attackRange.Length; i++)
        {
            if (i % attackCol == 0)
                GUILayout.BeginHorizontal();

            GUI.color = Color.white;
            if (attackRange[i])
                GUI.color = Color.red;

            if (i == attackCol * attackRow >> 1)
                GUI.color = Color.green;

            SerializedProperty property = serializedObject.FindProperty("attackRange").GetArrayElementAtIndex(i);
            attackRange[i] = EditorGUILayout.Toggle(attackRange[i]);
            property.boolValue = attackRange[i];

            if (i % attackCol == attackCol - 1)
                GUILayout.EndHorizontal();
        }
    }
}
