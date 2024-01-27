using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;



class KeyboardLayout : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);

    public static string GetCurrentKeyboardLayout()
    {
        StringBuilder name = new StringBuilder(9);
        GetKeyboardLayoutName(name);
        return name.ToString();
    }

    private void Start()
    {
        string keyboardLayout = KeyboardLayout.GetCurrentKeyboardLayout();
        Debug.Log(keyboardLayout);
    }
}