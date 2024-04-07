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


    /// <summary>
    /// �����տ��� ���ӿ�����Ʈ�� �ҷ��� �����ϴ� �Լ��̴�.
    /// </summary>
    /// <param name="path">�������� ������ ���ҽ� ���� ���</param>
    public GameObject Instantiate(string path, Transform parent)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");

        if (prefab == null)
        {
            Debug.LogWarning($"Failed to load prefab! {path}");
            return null;
        }

        GameObject go = Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if (index > 0)
            go.name = go.name.Substring(0, index);

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            Debug.LogWarning($"Failed to destory GameObject!");
            return;
        }

        Object.Destroy(go);
    }
}
