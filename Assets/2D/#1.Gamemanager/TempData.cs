using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӽ� Scriptable Object ������ Ŭ����
/// </summary>
[CreateAssetMenu(fileName = "TempData", menuName = "Scriptable Object/TempData")]
public class TempData : ScriptableObject
{
    [SerializeField]
    private string _id;
    public string ID => _id;

    [SerializeField]
    private string _pw;
    public string PW => _pw;

    [SerializeField]
    private TempStructure tempStructure;

    public void Show() => Debug.Log($"ID: {_id} | PW: {_pw}");
}

[System.Serializable]
public struct TempStructure
{
    [SerializeField]
    private List<int> elements;
}