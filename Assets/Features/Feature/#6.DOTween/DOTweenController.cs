using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class DOTweenController : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    private void Start()
    {
        //DOTween.Init(false, true, LogBehaviour.Verbose).SetCapacity(200, 50);
        //자동으로 설정해주니 그냥 써도 됨 => 만약 필요 시 위처럼 초기화
    }

    // Update is called once per frame
    void Update()
    {
        #region 이동 관련
        if (Input.GetKeyDown(KeyCode.W))
            cube.transform.DOLocalMoveX(cube.transform.position.x + 1.0f, 1.0f);
        if (Input.GetKeyDown(KeyCode.A))
            cube.transform.DOLocalMoveZ(cube.transform.position.z - 1.0f, 1.0f);
        if (Input.GetKeyDown(KeyCode.S))
            cube.transform.DOLocalMoveX(cube.transform.position.x - 1.0f, 1.0f);
        if (Input.GetKeyDown(KeyCode.D))
            cube.transform.DOLocalMoveZ(cube.transform.position.z + 1.0f, 1.0f);

        if (Input.GetKeyDown(KeyCode.Space))
            cube.transform.DOMove(cube.transform.position + Vector3.up, 1.0f).SetLoops(2, LoopType.Yoyo);
        #endregion

        #region 흔들림 관련
        if (Input.GetKeyDown(KeyCode.Q))
            cube.transform.DOShakePosition(1.0f, 1.0f, 10, 90.0f, false, true);
        if (Input.GetKeyDown(KeyCode.E))
            cube.transform.DOShakeRotation(1.0f, 45.0f, 10, 90.0f, false).SetDelay(1.0f);
        #endregion
    }
}
