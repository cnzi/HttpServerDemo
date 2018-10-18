using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace HttpServerDemo
{

    public class BaseHeader
    {
        public string Body { get; set; }

        public Encoding Encoding { get; set; }

        public string Content_Type { get; set; }

        public string Content_Length { get; set; }

        public string Content_Encoding { get; set; }

        public string ContentLanguage { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// 不支持枚举类型约束，所以采取下列方案:)
        /// </summary>
        protected string GetHeaderByKey(Enum header)
        {
            var fieldName = GetDescription(header);
            if (fieldName == null) return null;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) return null;
            return Headers[fieldName];
        }

        protected string GetHeaderByKey(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) return null;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) return null;
            return Headers[fieldName];
        }

        public string GetDescription(Enum value)
        {
            var valueType = value.GetType();
            var memberName = Enum.GetName(valueType, value);
            if (memberName == null) return null;
            var fieldInfo = valueType.GetField(memberName);
            var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            if (attribute == null) return null;
            return (attribute as DescriptionAttribute).Description;
        }

        /// <summary>
        /// 不支持枚举类型约束，所以采取下列方案:)
        /// </summary>
        protected void SetHeaderByKey(Enum header, string value)
        {
            var fieldName = GetDescription(header);
            if (fieldName == null) return;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) Headers.Add(fieldName, value);
            Headers[fieldName] = value;
        }

        protected void SetHeaderByKey(string fieldName, string value)
        {
            if (string.IsNullOrEmpty(fieldName)) return;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) Headers.Add(fieldName, value);
            Headers[fieldName] = value;
        }
    }
}
