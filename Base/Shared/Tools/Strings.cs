using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Strings
    {
        public class CodeDecode
        {
            private static string _decoded;
            private static string _coded;

            public static string Encode(string passwordDecoded)
            {
                var Result = "";
                // recorre password letra por letra
                for (var I = 0; I < passwordDecoded.Length; I++)
                {
                    // extrae cada letra
                    var Current = Convert.ToChar(passwordDecoded.Substring(I, 1));
                    // cada letra se convierte en una nueva Codificada
                    var Converted = (char)(Convert.ToByte(Current) + 1);
                    // cada letra se suma a una cadena nueva
                    Result += Converted;
                }
                _coded = Result;
                return _coded;
            }

            public static string Decode(string passwordCoded)
            {
                var Result = "";
                // recorre password letra por letra
                for (var I = 0; I < passwordCoded.Length; I++)
                {
                    // extrae cada letra
                    var Current = Convert.ToChar(passwordCoded.Substring(I, 1));
                    // cada letra se convierte en una nueva Decodificada
                    var Converted = (char)(Convert.ToByte(Current) - 1);
                    // cada letra se suma a una cadena nueva
                    Result += Converted;
                }
                _decoded = Result;
                return _decoded;
            }
        }
    }
}
