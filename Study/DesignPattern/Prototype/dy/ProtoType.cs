using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignPattern.Prototype
{
    public abstract class WeaponPrototype : ICloneable
    {
        public string Name;
        public string Type;
        public string Parent;
        public int MinAttack;
        public int MaxAttack;

        public abstract object Clone();

        protected T DeepCopy<T>(T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }

    public class Bow : WeaponPrototype
    {
        public int Distance;

        public override object Clone()
        {
            return DeepCopy(this);
        }
    }

    public class MagicBow : Bow
    {
        public string Spell;
        public override object Clone()
        {
            return DeepCopy(this);
        }
    }
}
