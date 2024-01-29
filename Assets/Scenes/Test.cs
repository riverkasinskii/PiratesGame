using System;
using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    void DoOperation(int a, int b, Action<int, int> op) => op(a, b);

    private IEnumerator Start()
    {
        DoOperation(10, 6, Add);
        yield return new WaitForSeconds(1);

        static void Add(int x, int y) => print($"{x} + {y} = {x + y}");
    }
}
