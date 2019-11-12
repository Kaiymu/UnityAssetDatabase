using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItemExemple
{
    [MenuItem("Custom menu item/Create cube")]
    public static void CreateCube()
    {
        Object.Instantiate(Resources.Load("PrefabCube"));
    }
}
