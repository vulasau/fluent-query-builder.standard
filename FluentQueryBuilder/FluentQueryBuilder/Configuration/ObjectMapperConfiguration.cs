﻿using System;

namespace FluentQueryBuilder.Configuration
{
    public static class ObjectMapperConfiguration
    {
        public static IConditionResolver ConditionResolver { get; private set; }
        public static IConverterResolver ConverterResolver { get; private set; }
        public static IConverterFactory ConverterFactory { get; private set; }

        static ObjectMapperConfiguration()
        {
            ConverterResolver = new ConverterResolver();
            ConverterFactory = new ConverterFactory();
        }

        public static void Use(IConditionResolver conditionResolver)
        {
            if (conditionResolver == null)
                throw new ArgumentNullException("conditionResolver", "'ConditionResolver' parameter should be set to non nullable value.");

            ConditionResolver = conditionResolver;
        }

        public static void Use(IConverterResolver converterResolver)
        {
            if (converterResolver == null)
                throw new ArgumentNullException("converterResolver", "'ConverterResolver' parameter should be set to non nullable value.");

            ConverterResolver = converterResolver;
        }

        public static void Use(IConverterFactory converterFactory)
        {
            if (converterFactory == null)
                throw new ArgumentNullException("converterFactory", "'ConverterFactory' parameter should be set to non nullable value.");

            ConverterFactory = converterFactory;
        }
    }
}
