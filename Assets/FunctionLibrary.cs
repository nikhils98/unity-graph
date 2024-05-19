using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class FunctionLibrary
{
    static readonly Function[] functions = { Wave, MultiWave, Ripple };

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    }

    public delegate float Function(float x, float z, float t);

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x + z + t));
    }

    static float MultiWave(float x, float z, float t)
    {
        float y = Sin(PI * (x + t));
        y += 0.5f * Sin(2f * PI * (z + t));
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (2f / 3f);
    }

    static float Ripple(float x, float z, float t)
    {
        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
}
