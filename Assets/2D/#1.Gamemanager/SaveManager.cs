using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public long gold;
    public List<int> hasItems;
    public List<int> hasUpgrades;

    public SaveData()
    {
        gold = 0;
        hasItems = new List<int>();
        hasUpgrades = new List<int>();
    }
}

/// <summary>
/// ���� ������ ���� ��Ʈ�ѷ��Դϴ�.
/// ���� ���� ������ ������ ���ϽŴٸ� �ڳ� ���� SDK�� Ȱ���ϴ� ���� ��õ�帳�ϴ�.
/// ���̺� ���� ���: {User}/AppData/LocalLow/{Company}
/// </summary>
public class SaveManager : MonoBehaviour
{
    private SaveData saveData;
    public SaveData SaveData
    {
        get
        {
            if (saveData == null)
                Debug.LogError("Error! SaveData is NULL!");
            return saveData;
        }
    }

    private string savePath;

    public void Init()
    {
        saveData = new SaveData();
        savePath = Path.Combine(Application.persistentDataPath, "SaveData.json");

        LoadGame();
    }

    public void SaveGame()
    {
        string _saveJson = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, _saveJson);
    }

    public void LoadGame()
    {
        if (!CheckSaveFile())
        {
            Debug.Log("SaveData is not exised! So system creats a new SaveData.");
            SaveGame();
            return;
        }

        string _loadJson = File.ReadAllText(savePath);
        saveData = JsonUtility.FromJson<SaveData>(_loadJson);
    }

    private bool CheckSaveFile() => File.Exists(Path.Combine(Application.persistentDataPath, "SaveData.json"));
}
