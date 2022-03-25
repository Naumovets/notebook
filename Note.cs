using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Note
    {
        public static Dictionary<string,Validation> fieldsValidation = new Dictionary<string, Validation>();
        public string Surname { set; get; }
        public string Name { set; get; }
        public string SecondName { set; get; }
        public string Phone { set; get; }
        public string Country { set; get; }
        public string DateOfBirth { set; get; }
        public string Position { set; get; }
        public string Organization { set; get; }
        public string Remark { set; get; }
        public int Id { set; get; }
        static Note()
        {
            fieldsValidation.Add("Name", new Validation(true,1,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ- ".ToCharArray()));
            fieldsValidation.Add("Id", new Validation(true,1,10, "1234567890".ToCharArray()));
            fieldsValidation.Add("Surname", new Validation(true,1,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ- ".ToCharArray()));
            fieldsValidation.Add("SecondName", new Validation(false,0,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ- ".ToCharArray()));
            fieldsValidation.Add("Phone", new Validation(true,5,11, "1234567890".ToCharArray()));
            fieldsValidation.Add("Country", new Validation(false,0,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ-".ToCharArray()));
            fieldsValidation.Add("DateOfBirth", new Validation(false,10,10, "1234567890.".ToCharArray()));
            fieldsValidation.Add("Organization", new Validation(false,0,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ-".ToCharArray()));
            fieldsValidation.Add("Position", new Validation(false,0,20, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ-".ToCharArray()));
            fieldsValidation.Add("Remark", new Validation(false,0,200, "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ1234567890,.?!()\\+-=№@'\"&$;:^ ".ToCharArray()));
        }

        public override string ToString()
        {
            string s = "\n";
            s += $"\tID: {this.Id}\n";
            s += $"\tФамилия: {this.Surname}\n";
            s += $"\tИмя: {this.Name}\n";
            s += $"\tОтчество: {this.SecondName}\n";
            s += $"\tНомер телефона: {this.Phone}\n";
            s += $"\tСтрана: {this.Country}\n";
            s += $"\tДата рождения: {this.DateOfBirth}\n";
            s += $"\tОрганизация: {this.Organization}\n";
            s += $"\tДолжность: {this.Position}\n";
            s += $"\tПримечание: {this.Remark}";
            return s;
        }

        public string ToShortString()
        {
            return $"{Id} {Surname} {Name} {Phone}";
        }
    }
}
