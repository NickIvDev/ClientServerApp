using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    // формирование необходимого формата для отправки серверу
    internal class GetDataForServer
    {
        public string GetDataStrForSerever(string _brend, short _year, float _engine, byte _dors) 
        {
            // определяем число элементов (по умолчанию 2)
            byte count = 2;
            if (_engine != 0)
            {
                count++;
            }
            if (_dors != 0)
            {
                count++;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"{count}*");
            sb.Append($"{_brend}*");
            sb.Append($"{_year}*");
            sb.Append($"{_engine}*");
            sb.Append($"{_dors}");

            return sb.ToString();
        }

        public byte[] GetDataToByteArrForSerever(string _brend, short _year, float _engine, byte _dors) 
        {
            //// формируем значение бренда автомобиля в ascii символы
            //byte[] brend = Encoding.ASCII.GetBytes(_brend);


            //// формируем значение года автомобиля в 16х систему
            //byte[] qwe = Encoding.Unicode.GetBytes(_year.ToString());
            //string year = Convert.ToString(_year, 16).ToUpper();

            //// формируем значение года автомобиля в 16х систему
            //string engine = Convert.ToString(_dors, 16).ToUpper();

            return default;
        }
    }
}
