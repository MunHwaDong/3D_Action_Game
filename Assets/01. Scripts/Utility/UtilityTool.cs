using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityTool
{
    public static KeyCode StringToKeyCode(string key)
    {
        KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), key);

        return keyCode;
    }
}
