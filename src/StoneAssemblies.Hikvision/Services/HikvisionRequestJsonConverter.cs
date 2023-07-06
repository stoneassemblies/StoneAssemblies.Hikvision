namespace StoneAssemblies.Hikvision.Services;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoneAssemblies.Hikvision.Models;

//public class HikvisionRequestJsonConverter : JsonConverter
//{
//    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
//    {
//        if (value is null)
//        {
//            return;
//        }

//        var fromObject = JObject.FromObject(value);
//        var contentName = nameof(Request<object>.Content);
//        var propertyValue = fromObject[contentName];

//        var propertyName = (value as IRequest)?.Name;
//        if (propertyName != null)
//        {
//            fromObject.Add(propertyName, propertyValue);
//            fromObject.Remove(contentName);
//        }

//        fromObject.WriteTo(writer);
//    }

//    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
//    {
//        throw new NotImplementedException();
//    }

//    public override bool CanConvert(Type objectType)
//    {
//        if (objectType.IsGenericType && objectType.GetGenericArguments().Length == 1)
//        {
//            var genericArgument = objectType.GetGenericArguments()[0];
//            var makeGenericType = typeof(Request<>).MakeGenericType(genericArgument);
//            if (makeGenericType == objectType)
//            {
//                return true;
//            }
//        }

//        return false;
//    }
//}