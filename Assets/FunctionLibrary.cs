using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class FunctionLibrary
{
    static readonly Function[] functions = { Wave, MultiWave };

    public enum FunctionName
    {
        Wave,
        MultiWave
    }

    public delegate float Function(float x, float t);

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }

    static float MultiWave(float x, float t)
    {
        float y = Sin(PI * (x + t));
        y += 0.5f * Sin(2f * PI * (x + t));
        return y * (2f / 3f);
    }
}
