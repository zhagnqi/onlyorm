using System;
using System.Reflection;
using OnlyOrm.Attributes;
using OnlyOrm.Exceptions;

namespace OnlyOrm.Exetnds
{
    public static class MappingAttributeExtend
    {
        public static string GetMappingName<T>(this T type) where T: MemberInfo
        {
            if(type.IsDefined(typeof(AbstractMappingAttribute), true))
            {
                AbstractMappingAttribute attribute = type.GetCustomAttribute<AbstractMappingAttribute>();
                return attribute.GetMappingName();
            }

            return type.Name;
        }

        public static string GetMasterKeyStr(this Type type, PropertyInfo[] props)
        {
           foreach(var prop in props)
           {
               if(prop.IsDefined(typeof(MasterKeyAttribute)))
               {
                    AbstractMappingAttribute attribute = type.GetCustomAttribute<AbstractMappingAttribute>();
                    return attribute.GetMappingName();
               }
           }

           throw new NoMasterExceptions();
        }
    }
}