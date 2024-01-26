using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ʹ� Scriptable Object�� �����˴ϴ�.
/// ���� �б� �����̸�, ���� ���࿡ �ʿ��� ��ҵ��� �����Դϴ�.
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField] private GoogleSheetManager googleSheet;
    public GoogleSheetManager GoogleSheet => googleSheet;



    [SerializeField] private JemSO jemSO;

    [SerializeField]
    private List<JemSO> jemSOList;
    public List<JemSO> JemSOList => jemSOList;

    public void Init()
    {
        jemSOList = new List<JemSO>();
        jemSOList.AddRange(GameManager.Resource.LoadAll<JemSO>("SO/JemSO"));

        GoogleSheet.Init();
    }
}
