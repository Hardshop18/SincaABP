﻿using System;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public class Utf8JsonVfpSerializer : IVfpSerializer, ITransientDependency
    {
        private static readonly JsonSerializerSettings VfpSerializerSettings;

        static Utf8JsonVfpSerializer()
        {
            VfpSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new ResolverWithPrivateSetters(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        byte[] IVfpSerializer.Serialize(object obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, VfpSerializerSettings);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public object Deserialize(byte[] value, Type type)
        {
            var jsonString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject(jsonString, type, VfpSerializerSettings);
        }

        public class ResolverWithPrivateSetters : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                if (prop.Writable)
                {
                    return prop;
                }

                prop.Writable = member.As<PropertyInfo>()?.GetSetMethod(true) != null;

                return prop;
            }
        }
    }
}