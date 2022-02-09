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
                Brend = dataForXml[1],
                Year = short.Parse(dataForXml[2]),
                Engine = float.Parse(dataForXml[3]),
                Dors = byte.Parse(dataForXml[4])
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
                    Brend=tempArr[1],
                    Year=short.Parse(tempArr[2]),
                    Engine=float.Parse(tempArr[3]),
                    Dors=byte.Parse(tempArr[4])
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
