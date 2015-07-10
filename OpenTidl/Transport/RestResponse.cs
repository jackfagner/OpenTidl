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
using OpenTidl.Models.Base;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace OpenTidl.Transport
{
    public class RestResponse<T> where T : ModelBase
    {
        #region properties

        public T Model { get; private set; }
        public Int32 StatusCode { get; private set; }
        public Exception Exception { get; internal set; }

        #endregion


        #region methods
        
        private TModel DeserializeObject<TModel>(String data) where TModel : class
        {
            if (String.IsNullOrEmpty(data))
                return Activator.CreateInstance<TModel>();
            var serializer = new DataContractJsonSerializer(typeof(TModel));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return serializer.ReadObject(ms) as TModel;
            }

        }

        #endregion


        #region construction

        public RestResponse(String responseData, Int32 statusCode)
        {
            if (statusCode < 300)
                this.Model = DeserializeObject<T>(responseData);
            if (statusCode >= 400)
                this.Exception = new OpenTidlException(DeserializeObject<ErrorModel>(responseData));
            this.StatusCode = statusCode;
        }

        public RestResponse(Exception ex)
        {
            this.Exception = ex;
        }

        #endregion
    }
}
