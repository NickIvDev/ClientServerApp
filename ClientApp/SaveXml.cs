using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientApp
{
    internal class SaveXml
    {
        // сохранение в xml для запроса по id
        public void SaveXmlForId(string[] dataForXml) 
        {
            CarModelForXml model = new CarModelForXml()
            {
                Id = int.Parse(dataForXml[0]),
                CountTypes = byte.Parse(dataForXml[1]),
                Brend = dataForXml[2],
                Year = short.Parse(dataForXml[3]),
                Engine = float.Parse(dataForXml[4]),
                Dors = byte.Parse(dataForXml[5])
            };

            string fileName = $"dataId_{model.Id}.xml";
            XmlSerializer formater = new XmlSerializer(typeof(CarModelForXml));
            using (FileStream fs = new FileStream(fileName,FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, model);
            }
        }

        // сохранение в xml для запроса на получение всех данных
        public void SaveXmlForAllData(string[] dataForXml)
        {
            List<CarModelForXml> model = new List<CarModelForXml>();
            foreach (var item in dataForXml)
            {
                string[] tempArr = item.Split("*");
                model.Add(new CarModelForXml() 
                {
                    Id=int.Parse(tempArr[0]),
                    CountTypes = byte.Parse(tempArr[1]),
                    Brend =tempArr[2],
                    Year=short.Parse(tempArr[3]),
                    Engine=float.Parse(tempArr[4]),
                    Dors=byte.Parse(tempArr[5])
                });
            }

            string fileName = "allData.xml";
            XmlSerializer formater = new XmlSerializer(typeof(List<CarModelForXml>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, model);
            }
        }
    }
}
