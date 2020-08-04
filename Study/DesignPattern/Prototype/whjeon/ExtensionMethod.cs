using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DesignPattern.Prototype.whjeon
{
    public static class ExtensionMethod
    {
        public static T DeepCopy<T>(this T self)
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
}
