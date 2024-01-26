using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    private const int AUTOSAVE_TIME = 60 * 5;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Save.LoadGame();
        StartCoroutine(AutoSave());
    }

    void Update()
    {
        // ������ ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Save.SaveData.gold += 100;

        // �� ���� ���������Ʈ ������ �ҷ�����
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Data.GoogleSheet.DownloadAllSO();
        }

        // ���� ������ ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            JemSO jemSO = GameManager.Data.JemSOList[0];
            Debug.Log($"'{jemSO.Price}' of '{jemSO.Name}'");
        }
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(AUTOSAVE_TIME);

        Debug.Log("AutoSave starts.");
        GameManager.Save.SaveGame();
        StartCoroutine(AutoSave());
    }

    public void OnClickButton()
    {
        GameManager.Sound.PlaySE("ClickButton");
    }
}
