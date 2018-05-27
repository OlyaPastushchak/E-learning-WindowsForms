using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace E_learning_WinForms
{
    class Serialization
    {
        public static void SerializeInXML(string fileName, List<Circle> circles)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Circle>));
            Stream serialStream = new FileStream(fileName, FileMode.Create);

            xmlser.Serialize(serialStream, circles);
            serialStream.Close();
        }

        public static List<Circle> DeserializeFromXML(string fileName)
        {
            List<Circle> deserializedCircles = null;
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Circle>));
            using (FileStream serialStream = new FileStream(fileName, FileMode.Open))
            {
                deserializedCircles = (List<Circle>)xmlser.Deserialize(serialStream);
            }

            if (deserializedCircles == null)
            {
                throw new ApplicationException(string.Format("Can't deserialize file"));
            }

            return deserializedCircles;
        }
    }
}
