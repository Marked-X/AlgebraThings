using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Algebra
{
    public static Vector3 Subtraction(Vector3 first, Vector3 second)
    {
        return first - second;
    }

    public static float Length(Vector3 vector)
    {
        float result = Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
        return result;
    }

    public static Vector3 Normalized(Vector3 vector)
    {
        float length = Length(vector);
        Vector3 result = new Vector3(vector.x / length, vector.y / length);
        return result;
    }

    public static float ScalarProduct(Vector3 first, Vector3 second)
    {
        float result = first.x * second.x + first.y * second.y + first.z * second.z;
        return result;
    }

    public static float VectorAngle(Vector3 first, Vector3 second)
    {
        float result = ScalarProduct(first, second) / (Length(first) * Length(second));
        result = Mathf.Acos(result);
        return result;
    }
}
