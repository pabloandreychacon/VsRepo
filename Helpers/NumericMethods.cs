using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class NumericMethods
    {
        public class NumericValidators
        {
            // IsNumeric Function
            public static bool IsNumeric(object expression)
            {
                // Variable to collect the Return value of the TryParse method.
                // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
                // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
                // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
                var IsNum = Double.TryParse(Convert.ToString(expression), System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out double RetNum);
                return IsNum;
            }

            // IsPositiveNumeric Function
            public static bool IsPositiveNumeric(object expression)
            {
                // Variable to collect the Return value of the TryParse method.
                // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
                // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
                // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
                var IsNum = Double.TryParse(Convert.ToString(expression), System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out double RetNum);
                // es positivo
                if (RetNum < 0) IsNum = false;
                return IsNum;
            }
        }

        public static class Redondeo
        {
            public enum RedondeoTypes
            {
                /// <summary>
                /// redondeo para usar en ventas
                /// por de fecto empieza en 0
                /// </summary>
                Ninguno,
                Centecimales,
                Decimales,
                SinDecimales,
                Unidades,
                Decenas
            }

            public static decimal ApplyRound(decimal numberToRound, RedondeoTypes roundType)
            {
                var newNumber = 0.0m;
                switch (roundType)
                {
                    case RedondeoTypes.Ninguno:
                        newNumber = Math.Round(numberToRound, 2);
                        break;
                    case RedondeoTypes.Centecimales:
                        /// Redondondear centecimales, ej. 4.23 = 4.25. 
                        /// En este caso el último decimal siempre será igual a 0 ó 5                        
                        if (numberToRound - Math.Round(numberToRound, 1) > 0)
                        {
                            var centesimas = numberToRound - Math.Round(numberToRound, 1);
                            if (ExtensionMethods.IsBetween(centesimas, 0.01m, 0.05m))
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.05m;
                            }
                            else
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.1m;
                            }
                        }
                        else
                        {
                            if (numberToRound - Math.Round(numberToRound, 1) < 0)
                            {
                                newNumber = Math.Round(numberToRound, 1);
                            }
                            else
                            {
                                newNumber = numberToRound;
                            }
                        }
                        break;
                    case RedondeoTypes.Decimales:
                        /// Redondondear decimales, 4.23 = 4.50. 
                        /// El centecimal será 0, y el decimal 5 (de .01 a .50) ó 0 (>=.51)
                        numberToRound = Math.Round(numberToRound / 10, 2);
                        if (numberToRound - Math.Round(numberToRound, 1) > 0)
                        {
                            if (ExtensionMethods.IsBetween(numberToRound - Math.Round(numberToRound, 1), 0.01m, 0.05m))
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.05m;
                            }
                            else
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.1m;
                            }
                        }
                        else
                        {
                            if (numberToRound - Math.Round(numberToRound, 1) < 0)
                            {
                                newNumber = Math.Round(numberToRound, 1);
                            }
                            else
                            {
                                newNumber = numberToRound;
                            }
                        }
                        newNumber = newNumber * 10;
                        break;
                    case RedondeoTypes.SinDecimales:
                        newNumber = Math.Round(numberToRound, 0);
                        break;
                    case RedondeoTypes.Unidades:
                        /// Redondear unidades, ej. 23.86 = 25,  27.42 = 30, 
                        /// se eliminan los decimales. Las unidades serán 5 ó 0
                        numberToRound = Math.Round(numberToRound / 100, 2);
                        var absolute = Math.Abs(numberToRound - Math.Round(numberToRound, 1));
                        if (absolute == 0.05m)
                        {
                            newNumber = numberToRound;
                        }
                        else
                        {
                            //newNumber = 
                            if (numberToRound - Math.Round(numberToRound, 1) > 0)
                            {
                                if (ExtensionMethods.IsBetween(numberToRound - Math.Round(numberToRound, 1), 0.01m, 0.05m))
                                {
                                    newNumber = Math.Round(numberToRound, 1) + 0.05m;
                                }
                                else
                                {
                                    newNumber = Math.Round(numberToRound, 1) + 0.1m;
                                }
                            }
                            else
                            {
                                if (numberToRound - Math.Round(numberToRound, 1) < 0)
                                {
                                    newNumber = Math.Round(numberToRound, 1);
                                }
                                else
                                {
                                    newNumber = numberToRound;
                                }
                            }

                        }
                        newNumber = newNumber * 100;
                        break;
                    case RedondeoTypes.Decenas:
                        /// Redondear decenas, ej. 185 = 200, 142 = 150, 
                        /// las decenas serán igual a 5 ó 0
                        numberToRound = Math.Round(numberToRound / 1000, 2);
                        //vlcn_monto1 = 
                        if (numberToRound - Math.Round(numberToRound, 1) > 0)
                        {
                            if (ExtensionMethods.IsBetween(numberToRound - Math.Round(numberToRound, 1), 0.01m, 0.05m))
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.05m;
                            }
                            else
                            {
                                newNumber = Math.Round(numberToRound, 1) + 0.1m;
                            }
                        }
                        else
                        {
                            if (numberToRound - Math.Round(numberToRound, 1) < 0)
                            {
                                newNumber = Math.Round(numberToRound, 1);
                            }
                            else
                            {
                                newNumber = numberToRound;
                            }
                        }
                        newNumber = newNumber * 1000;
                        break;
                    default:
                        newNumber = Math.Round(numberToRound, 2);
                        break;
                }
                return newNumber;
            }
        }


    }

    public class StringMethods
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
