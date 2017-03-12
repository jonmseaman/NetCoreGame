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
    /// Serializes and deserializes objects with types derived from T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializerImproved<T>
    {
        private Type[] _extraTypes;
        /// <summary>
        /// A cache for the serializers.
        /// </summary>
        private Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();

        public SerializerImproved()
        {
            var allTypes = typeof(T).GetTypeInfo().Assembly.GetTypes();
            var extras = from type in allTypes
                         where type.GetTypeInfo().IsSubclassOf(typeof(T)) || type == typeof(T)
                         select type;
            _extraTypes = extras.ToArray();
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

        public T1 Deserialize<T1>(TextReader input)
        {
            return (T1)GetSerializer(typeof(T1)).Deserialize(input);
        }

        public T1 Deserialize<T1>(Stream stream)
        {
            return (T1) GetSerializer(typeof(T1)).Deserialize(stream);
        }

        public T1 Deserialize<T1>(XmlReader reader)
        {
            return (T1)GetSerializer(typeof(T1)).Deserialize(reader);
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