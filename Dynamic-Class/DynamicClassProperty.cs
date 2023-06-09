﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicClass
{
    public class DynamicClassProperty : DynamicObject
    {
        private readonly Dictionary<string, KeyValuePair<Type, object?>> _fields;

        public DynamicClassProperty(List<Temp> fields)
        {
            _fields = new Dictionary<string, KeyValuePair<Type, object?>>();
            fields.ForEach(x => _fields.Add(x.FieldName,
                new KeyValuePair<Type, object?>(x.FieldType, null)));
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (!_fields.ContainsKey(binder.Name)) return false;
            var type = _fields[binder.Name].Key;
            if (value?.GetType() == type)
            {
                _fields[binder.Name] = new KeyValuePair<Type, object?>(type, value);
                return true;
            }
            else throw new Exception("Value " + value + " is not of type " + type.Name);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = _fields[binder.Name].Value;
            return true;
        }

        public class Temp
        {
            public Temp(string name, Type type)
            {
                this.FieldName = name;
                this.FieldType = type;
            }

            public readonly string FieldName;

            public readonly Type FieldType;
        }
    }

}
