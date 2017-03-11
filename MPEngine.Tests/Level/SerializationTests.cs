﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using MPEngine.Entity;
using MPEngine.Level;
using MPEngine.Serialization;
using Xunit;

namespace MPEngine.Tests.Level
{
    public class SerializationTests
    {
        public class LevelDefinitionTest
        {
            public string LevelName { get; set; } = "First Level";
            public string FileName { get; set; } = "firstLevel.xml";
            public List<Creature> CreatureList { get; set; } = new List<Creature>(3)
            {
                new Creature()
                {
                    Attributes = new CreatureAttributes()
                    {
                        Agility = 3,
                        Intellect = 3,
                        Spirit = 8,
                        Stamina = 9,
                        Strength = 9,
                        Energy = 100,
                        MaxEnergy = 100,
                        Health = 150,
                        MaxHealth = 150,
                        Experience = 200L,
                        Level = 4
                    },
                    Location = new Location(15, 12)
                },
                new Creature()
                {
                    Location = new Location(4, 4)
                },
                new Creature()
                {
                    Location = new Location(10, 30)
                }
            };
            public Player Player { get; set; } = new Player()
            {
                Name = "Jonathan"
            };
        }
        private List<Creature> _creatures = new List<Creature>()
        {
            new Player()
            {
                Name = "Jon"
            },
            new Creature()
        };

        [Fact]
        public void SerializeListTest()
        {
            var list = _creatures;
            var serializer = new Serializer<Creature>();
            var xmlwriter = XmlWriter.Create(Console.Out);
            
            foreach (var creature in list)
            {
                var str = serializer.Serialize(creature);
                Console.WriteLine(str);
            }
        }

        [Fact]
        public void SerializeListTestWithExtraTypes()
        {
            var list = _creatures;
            var allTypes = typeof(Creature).GetTypeInfo().Assembly.GetTypes();
            var extras = from type in allTypes
                where type.GetTypeInfo().IsSubclassOf(typeof(Creature)) || type == typeof(Creature)
                select type;
            var serializer = new XmlSerializer(typeof(List<Creature>), extras.ToArray());
            serializer.Serialize(Console.Out, list);
        }

        [Fact]
        public void SerializeLevelDefinitionTest()
        {
            Console.WriteLine(new string('=', 80));
            var definition = new LevelDefinitionTest();

            // Make serializer.
            var serializer = new SerializerImproved<Creature>();
            serializer.Serialize(Console.Out, definition);
            Console.WriteLine();
            Console.WriteLine(new string('=', 80));
        }

        [Fact]
        public void DeserializeLevelDefinitionTest()
        {
            var serializer = new SerializerImproved<Creature>();
            var fname = "./Data/LevelDefinitionTest1.xml";
            var input = File.OpenRead(fname);
            var reader = XmlReader.Create(input);
            var definition = serializer.Deserialize<LevelDefinitionTest>(reader);
            Assert.NotNull(definition);
            Assert.NotEmpty(definition.CreatureList);
            Assert.NotNull(definition.Player);
        }
    }
}
