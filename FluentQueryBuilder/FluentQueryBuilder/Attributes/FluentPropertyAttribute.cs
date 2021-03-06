﻿using System;

namespace FluentQueryBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FluentPropertyAttribute : Attribute
    {
        /// <summary>
        /// Name of the property for mapping and serializaton/deserialization process. 
        /// If not set, property name itself will be used.
        /// Should not be empty string.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Indicates, whether property is readonly.
        /// If value is 'true', property will be mapped only 'from' Fluentobject, but will be ignored when mapping 'to' FluentObject.
        /// Paramter is 'false' by default.
        /// </summary>
        public bool IsReadony { get; private set; }

        public FluentPropertyAttribute(string name = null, bool isReadonly = false)
        {
            if (name != null && string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter 'name' can not be empty string.", "name");

            Name = name;
            IsReadony = isReadonly;
        }
    }
}
