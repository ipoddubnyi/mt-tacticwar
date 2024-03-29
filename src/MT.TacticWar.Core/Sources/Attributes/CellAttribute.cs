﻿using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CellAttribute : Attribute
    {
        public CellAttribute(string name, Type schemaType)
        {
            Name = name;
            SchemaType = schemaType;
            Code = 'C';
        }

        public string Name { get; set; }
        public Type SchemaType { get; set; }
        public char Code { get; set; }
    }
}
