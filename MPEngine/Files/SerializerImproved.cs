using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace MPEngine.Files
{
    /// <summary>
    /// Serializes and deserializes objects with types derived from
    /// the types provided to the constructor.
    /// </summary>
    public class SerializerImproved
    {
        private Type[] _extraTypes;
        /// <summary>
        /// A cache for the serializers.
        /// </summary>
        private Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();

        public SerializerImproved(IEnumerable<Type> types)
        {
            var extraTypesList = new List<Type>();
            foreach (var baseType in types)
            {
                var allTypes = baseType.GetTypeInfo().Assembly.GetTypes();
                var extras = from type in allTypes
                             where type.GetTypeInfo().IsSubclassOf(baseType)
                             select type;
                extraTypesList.Add(baseType);
                extraTypesList.AddRange(extras);
            }
            _extraTypes = extraTypesList.ToArray();
        }

        #region Serialize

        public void Serialize(Stream stream, object o)
        {
            GetSerializer(o.GetType()).Serialize(stream, o);
        }

        public void Serialize(TextWriter output, object o)
        {
            GetSerializer(o.GetType()).Serialize(output, o);
        }

        public void Serialize(XmlWriter writer, object o)
        {
            GetSerializer(o.GetType()).Serialize(writer, o);
        }

        public T Deserialize<T>(TextReader input)
        {
            return (T)GetSerializer(typeof(T)).Deserialize(input);
        }

        public T Deserialize<T>(Stream stream)
        {
            return (T) GetSerializer(typeof(T)).Deserialize(stream);
        }

        public T Deserialize<T>(XmlReader reader)
        {
            return (T)GetSerializer(typeof(T)).Deserialize(reader);
        }

        #endregion

        private XmlSerializer GetSerializer(Type type)
        {
            if (!_serializers.TryGetValue(type, out XmlSerializer serializer))
            {
                serializer = new XmlSerializer(type, _extraTypes);
                _serializers.Add(type, serializer);
            }
            return serializer;
        }
    }
}