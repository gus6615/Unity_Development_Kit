using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ �����ϴ� �̹��� �� ����� ���ҽ��� �����մϴ�.
/// </summary>
public class ResourceManager : MonoBehaviour
{
    public void Init()
    {
        /*
         �ʱ�ȭ ���� �ڵ� ����
         */
    }


    /// <summary>
    /// ���ҽ��� �ѹ��� �ҷ����� �Լ��̴�.
    /// </summary>
    /// <typeparam name="T">������ Ÿ��</typeparam>
    /// <param name="path">���ҽ� ���� ���</param>
    public T[] LoadAll<T>(string path) where T : Object
    {
        T[] resource = Resources.LoadAll<T>(path);

        if (resource == null)
        {
            Debug.LogError($"Failed to load Resource : {path}");
            return null;
        }
        Debug.Log($"Load Resource '{path}' is Successful. [{typeof(T)} : {resource.Length}]");

        return resource;
    }


    /// <summary>
    /// ���ҽ��� �ϳ��� �ҷ����� �Լ��̴�.
    /// </summary>
    /// <typeparam name="T">������ Ÿ��</typeparam>
    /// <param name="path">���ҽ� ���� ���</param>
    public T Load<T>(string path) where T : Object
    {
        T resource = Resources.Load<T>(path);

        if (resource == null)
        {
            Debug.Log($"Failed to load Resource : {path}");
            return null;
        }

        return resource;
    }
}
