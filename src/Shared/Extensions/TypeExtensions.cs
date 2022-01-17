﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Shared.Extensions;
public static class TypeExtensions
{
    public static List<string> GetNestedClassesStaticStringValues(this Type type)
    {
        var values = new List<string>();
        foreach (var prop in type.GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        {
            object? propertyValue = prop.GetValue(null);
            if (propertyValue?.ToString() is string propertyString)
            {
                values.Add(propertyString);
            }
        }

        return values;
    }
}
