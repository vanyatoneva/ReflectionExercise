using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] propertyInfos = objType.GetProperties()
                .Where(p=> p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            
            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                IEnumerable<MyValidationAttribute> attr = propertyInfo.GetCustomAttributes(true).
                    Where(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType())).
                    Cast<MyValidationAttribute>();

                foreach(MyValidationAttribute attrib in attr)
                {
                    if (!attrib.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }
                    
                }
            }

            return true;
        }
    }
}
