/*
    Copyright (C) 2015  Jack Fagner

    This file is part of OpenTidl.

    OpenTidl is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    OpenTidl is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with OpenTidl.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace OpenTidl.Transport
{
    internal static class RestUtility
    {
        internal static String GetFormEncodedString(Object data)
        {
            if (data == null)
                return null;
            return String.Join("&", data.GetType().GetProperties().Select(o =>
                String.Format("{0}={1}", WebUtility.UrlEncode(o.Name), FormEncode(o.GetValue(data)))));
        }

        private static String FormEncode(Object value)
        {
            if (value == null)
                return String.Empty;
            return WebUtility.UrlEncode(value.ToString());
        }

        internal static String FormatUrl(String format, Object data)
        {
            var dict = data == null ? new Dictionary<String, String>() : 
                data.GetType().GetProperties().ToDictionary(o => o.Name, o => FormEncode(o.GetValue(data)));
            return Regex.Replace(format, @"\{(\w+)\}", (m) => {
                return dict.ContainsKey(m.Groups[1].Value) ? dict[m.Groups[1].Value] : "";
            }, RegexOptions.Singleline);
        }

        internal static T ParseEnum<T>(String value) where T : struct
        {
            T result;
            if (Enum.TryParse(value, true, out result))
                return result;
            return (T)Enum.ToObject(typeof(T), 0);
            //return Enum.GetValues(typeof(T)).OfType<T>().FirstOrDefault();
        }

        internal static String FormatDate(DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            return "";
        }

        internal static DateTime? ParseDate(String value)
        {
            if (String.IsNullOrEmpty(value))
                return null;
            DateTime date;
            if (DateTime.TryParse(value, out date))
                return date;
            return null;
        }

        internal static Boolean ParseImageSize(String sizeStr, out Int32 width, out Int32 height)
        {
            width = 0;
            height = 0;
            var match = Regex.Match(sizeStr ?? "", @"_(?<w>\d+)x(?<h>\d+)$", RegexOptions.Singleline);
            if (!match.Success)
                return false;
            width = Int32.Parse(match.Groups["w"].Value);
            height = Int32.Parse(match.Groups["h"].Value);
            return true;
        }
    }
}
