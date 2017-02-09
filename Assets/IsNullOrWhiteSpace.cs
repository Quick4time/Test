using UnityEngine;
using System.Collections;

/// <summary>
/// Проверка string на значение null или пробелы в тексте.
/// </summary>
public static class StringExtention
{
    public static bool IsNullorWhiteSpace (this string s)
    {
    return s == null || s.Trim().Length == 0; 
    }
}

