using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Engine.Files
{
    /// <summary>
    /// Deserializes types derived from T.
    /// </summary>
    /// <typeparam name="T">Types derived from T may be deserialzed by this.</typeparam>
    public class Serializer<T>
    {
        /// <summary>
        /// A dictionary mapping a type's name to its serializer.
        /// </summary>
        private Dictionary<string, XmlSerializer> _serializers = new Dictionary<string, XmlSerializer>();
        private XmlSerializerNamespaces _xmlns = new XmlSerializerNamespaces();

        /// <summary>
        /// Creates an XML deserialized for types derived from T.
        /// </summary>
        public Serializer()
        {
            // Build type names dictionary.
            _xmlns.Add("", "");
            var assembly = typeof(T).GetTypeInfo().Assembly;
            var types = assembly.GetTypes();
            foreach (var type in types)
                AddTypeToDictionary(type);
        }

        /// <summary>
        /// Deserializes a single T from an xml representation.
        /// </summary>
        /// <param name="tStr">XML string of a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        public T Deserialize(string tStr)
        {
            // Get the type.
            var xml = XmlReader.Create(new StringReader(tStr));
            xml.MoveToContent();
            if (!_serializers.TryGetValue(xml.Name, out XmlSerializer serializer))
                throw new ArgumentException($"Did not find type {xml.Name} that derives from {typeof(T).Name}");

            // Deserialize.
            var deserializedEntity = serializer.Deserialize(xml);

            return (T) deserializedEntity;
        }

        /// <summary>
        /// Deserializes a list of T.
        /// </summary>
        /// <param name="tStrs">List of serialized objects.</param>
        /// <returns>List of deserialized objects.</returns>
        public IList<T> DeserializeList(IList<string> tStrs)
        {
            var entities = new List<T>(tStrs.Count);
            entities.AddRange(tStrs.Select(Deserialize));
            return entities;
        }

        public string Serialize(T o)
        {
            var stream = new StringWriter();
            Serialize(stream, o);
            return stream.ToString();
        }

        public void Serialize(TextWriter output, T o)
        {
            var xml = XmlWriter.Create(output, new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true
            });
            if (!_serializers.TryGetValue(o.GetType().Name, out XmlSerializer serializer))
                throw new ArgumentException($"Could not find serializer for type {o.GetType().Name}");
            serializer.Serialize(xml, o, _xmlns);
        }


        public bool SerializeList(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }

        #region Helpers

        private XmlAttributeOverrides GetOverrides(Type type)
        {
            var overrides = new XmlAttributeOverrides();
            var attrs = new XmlAttributes
            {
                XmlIgnore = true
            };

            var searchType = type;
            while (!searchType.Name.Equals(typeof(object).Name))
            {
                // Ignore interfaces that are properties.
                var properties = searchType.GetRuntimeProperties();
                foreach (var propertyInfo in properties)
                {
                    var propertyType = propertyInfo.PropertyType;
                    if (propertyType.GetTypeInfo().IsInterface)
                        overrides.Add(searchType, propertyInfo.Name, attrs);
                }
                // Ignore interfaces that are fields.
                var fields = searchType.GetRuntimeFields();
                foreach (var fieldInfo in fields)
                {
                    var fieldType = fieldInfo.FieldType;
                    if (fieldType.GetTypeInfo().IsInterface)
                        overrides.Add(searchType, fieldInfo.Name, attrs);
                }

                // Next type.
                searchType = searchType.GetTypeInfo().BaseType;
            }

            return overrides;
        }

        private void AddTypeToDictionary(Type type)
        {
            var ctor = type.GetTypeInfo().GetConstructor(Type.EmptyTypes);
            // Add the type if it has a parameterless ctor and derives from T.
            var shouldAdd = type.GetTypeInfo().IsSubclassOf(typeof(T))
                 && ctor != null;
            // Or, add the type if it is T and has a parameterless ctor.
            shouldAdd = (type == typeof(T) && ctor != null) || shouldAdd;

            if (shouldAdd && !_serializers.ContainsKey(type.Name))
            {
                // Add serializer to serializer dictionary.
                var overrides = GetOverrides(type);
                var serializer = new XmlSerializer(type, overrides);
                _serializers.Add(type.Name, serializer);
            }
        }

        #endregion
    }
}