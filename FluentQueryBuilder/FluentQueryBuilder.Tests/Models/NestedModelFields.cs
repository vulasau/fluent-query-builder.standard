using System;
using FluentQueryBuilder.Attributes;

namespace FluentQueryBuilder.Tests.Models
{
    [FluentEntity("NestedModelFields")]
    public abstract class NestedModelFields
    {
        public static string MODEL_NAME = "NestedModelFields";
        public static string NUMBER_PROPERTY_NAME = "Number";
        public static string DATE_PROPERTY_NAME = "Date";
        public static string TEXT_PROPERTY_NAME = "Text";

        [FluentProperty]
        public int Number { get; set; }

        [FluentProperty]
        public DateTime Date { get; set; }

        [FluentProperty]
        public string Text { get; set; }
    }
}
