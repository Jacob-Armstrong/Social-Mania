using System;
using System.Collections.Generic;
using UnityEngine;

public static class CalcUtils
{
    private static readonly int charA = Convert.ToInt32('a');

    private static readonly Dictionary<int, string> units = new Dictionary<int, string>
    {
        {0, ""},
        {1, "K"},
        {2, "M"},
        {3, "B"},
        {4, "T"}
    };

    public static string FormatNumber(double value)
    {
        if (value < 1d)
        {
            return "0";
        }

        var n = (int)Math.Log(value, 1000);
        var m = (double)value / Mathf.Pow(1000, n);
        string unit;

        if (n < units.Count)
        {
            unit = units[n];
        }
        else
        {
            var unitInt = n - units.Count;
            var secondUnit = unitInt % 26;
            var firstUnit = unitInt / 26;
            unit = Convert.ToChar(firstUnit + charA).ToString() + Convert.ToChar(secondUnit + charA).ToString();
        }

        if(value >= 1000)
            return (Math.Floor(m * 100) / 100).ToString("0.##") + unit;
        else
            return Math.Floor(value).ToString();
    }

    public static double StringToNumber(string value)
    {
        int i;

        string num = "";
        string unit = "";

        for(i = 0; i < value.Length; ++i)
        {
            if(Convert.ToInt32(value[i]) >= 96)
            {
                unit += value[i];
            }
            else
            {
                num += value[i];
            }
        }

        double baseNum = Convert.ToDouble(num);
        int pow = 0;

        if(unit.Length == 2)
        {
            pow = 3 * ((Convert.ToInt32(unit[0]) - charA) * 26 + Convert.ToInt32(unit[0] - charA) + units.Count);
        }
        else if(unit.Length == 1)
        {
            foreach(KeyValuePair<int, string> pair in units)
            {
                if(pair.Value == unit.ToUpper())
                {
                    pow = pair.Key * 3;
                }
            }
        }

        return baseNum * Math.Pow(10, pow);
    }
}
