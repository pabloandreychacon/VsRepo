using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Numeric
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
}
