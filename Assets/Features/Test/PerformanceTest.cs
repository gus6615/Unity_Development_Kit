using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PerformanceTest : MonoBehaviour
{
    delegate void TestDelegate();

    float sum;
    List<SpriteRenderer> spriteRenderers;
    SpriteRenderer spriteRenderer;
    SpriteRenderer tempSR;
    Type type;

    private void Start()
    {
        spriteRenderers = new List<SpriteRenderer>();
        tempSR = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // MeasurePerformance(() => { sum = 1 + 2; }, 1000000);
        // MeasurePerformance(() => { sum = 1 - 2; }, 1000000);
        // MeasurePerformance(() => { sum = 1 * 2; }, 1000000);
        // MeasurePerformance(() => { sum = 1 / 2; }, 1000000);
        // MeasurePerformance(() => { spriteRenderer = new SpriteRenderer(); }, 1000000);
        // MeasurePerformance(() => { type = typeof(SpriteRenderer); }, 1000000);
        MeasurePerformance(() => { spriteRenderer = tempSR; }, 1000000);
        // MeasurePerformance(() => { spriteRenderers.Add(this.GetComponent<SpriteRenderer>()); }, 1000000);
        // MeasurePerformance(() => { this.GetComponent<SpriteRenderer>(); }, 1000000);
        // MeasurePerformance(() => { this.AddComponent<SpriteRenderer>(); }, 100000); // 0 하나 빠진 것
        // MeasurePerformance(() => { this.TryGetComponent(out spriteRenderer); }, 1000000);        
    }

    public void MeasurePerformance(Action action, int loopCount)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        for (int i = 0; i < loopCount; i++)
            action();

        stopwatch.Stop();

        UnityEngine.Debug.Log($"측정 결과: {stopwatch.ElapsedMilliseconds} ms 경과");
    }
}
