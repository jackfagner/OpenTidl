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
using System.Threading;
using System.IO;
using OpenTidl.Models.Base;
using System.Runtime.Serialization;

namespace OpenTidl.Transport
{
    internal class RestClient
    {
        #region properties

        internal String ApiEndpoint { get; private set; }
        internal String UserAgent { get; private set; }

        #endregion


        #region methods
        
        internal async Task<RestResponse<T>> Process<T>(String path, Object query, Object request, String method) where T : ModelBase
        {
            var encoding = new UTF8Encoding(false);
            var queryString = RestUtility.GetFormEncodedString(query);
            var url = String.IsNullOrEmpty(queryString) ? String.Format("{0}{1}", ApiEndpoint, path) : 
                String.Format("{0}{1}?{2}", ApiEndpoint, path, queryString);
            var req = CreateRequest(url, method);
            if (request != null)
            {
                req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                using (var sw = new StreamWriter(req.GetRequestStream(), encoding))
                    sw.Write(RestUtility.GetFormEncodedString(request));
            }
            HttpWebResponse response;
            try
            {
                response = (await req.GetResponseAsync()) as HttpWebResponse;
            }
            catch (WebException webEx)
            {
                response = webEx.Response as HttpWebResponse;
            }
            catch (Exception ex)
            {
                return new RestResponse<T>(ex);
            }
            using (var sr = new StreamReader(response.GetResponseStream(), encoding))
            {
                return new RestResponse<T>(sr.ReadToEnd(), (Int32)response.StatusCode);
            }
        }

        internal Stream GetStream(String url)
        {
            try
            {
                var response = GetWebResponse(url);
                if (response != null)
                    return response.GetResponseStream();
            }
            catch { }
            return null;
        }

        internal HttpWebResponse GetWebResponse(String url)
        {
            var req = CreateRequest(url, "GET");
            req.Timeout = 2000;
            try
            {
                return req.GetResponse() as HttpWebResponse;
            }
            catch
            {
                return null;
            }
        }

        private HttpWebRequest CreateRequest(String url, String method)
        {
            var req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.UserAgent = this.UserAgent;
            req.Method = method;
            return req;
        }

        #endregion


        #region construction

        internal RestClient(String apiEndpoint, String userAgent)
        {
            this.ApiEndpoint = apiEndpoint ?? "";
            this.UserAgent = userAgent;
        }

        #endregion
    }
}
