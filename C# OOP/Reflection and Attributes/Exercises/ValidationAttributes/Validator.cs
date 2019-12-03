using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                IEnumerable<MyValidationAttribute> propAttributes = property.GetCustomAttributes().Where(x => x is MyValidationAttribute).Cast<MyValidationAttribute>();

                foreach (var propAttribute in propAttributes)
                {
                    bool result = propAttribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }

                }
            }

            return true; ;
        }
    }
}
