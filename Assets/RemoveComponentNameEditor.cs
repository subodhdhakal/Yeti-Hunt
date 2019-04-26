using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveComponentName : MonoBehaviour
{

    public void RemoveComponents()
    {
        Component[] components = GetComponentsInChildren(typeof(RegisterRage), true);

        foreach (var c in components)
        {
            DestroyImmediate(c);
        }
    }
}