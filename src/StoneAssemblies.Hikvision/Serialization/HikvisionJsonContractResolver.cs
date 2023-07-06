using StoneAssemblies.Hikvision.Models;

namespace StoneAssemblies.Hikvision.Serialization;

using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class HikvisionJsonContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        if (member is PropertyInfo propertyInfo)
        {
            var memberReflectedType = member.ReflectedType;
            if (memberReflectedType is not null && memberReflectedType.IsGenericType && memberReflectedType.GetGenericArguments().Length == 1)
            {
                var genericArgument = memberReflectedType.GetGenericArguments()[0];
                var makeGenericType = typeof(HikvisionJsonContent<>).MakeGenericType(genericArgument);
                if (makeGenericType == memberReflectedType && jsonProperty.PropertyName == nameof(HikvisionJsonContent<object>.Content))
                {
                    jsonProperty.PropertyName = genericArgument.Name;
                }
            }

            var jsonPropertyPropertyName = jsonProperty.PropertyName!.ToArray();
            if (propertyInfo.PropertyType != typeof(string) && (propertyInfo.PropertyType.IsClass || propertyInfo.PropertyType.IsArray))
            {
                jsonPropertyPropertyName[0] = char.ToUpper(jsonPropertyPropertyName[0]);
            }
            else
            {
                jsonPropertyPropertyName[0] = char.ToLower(jsonPropertyPropertyName[0]);
            }

            jsonProperty.PropertyName = new string(jsonPropertyPropertyName);
        }

        return jsonProperty;
    }
}