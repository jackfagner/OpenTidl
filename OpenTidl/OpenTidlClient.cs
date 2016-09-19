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
using OpenTidl.Transport;
using System.IO;
using OpenTidl.Models.Base;
using OpenTidl.Models;
using OpenTidl.Methods;
using OpenTidl.Enums;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region fields

        private const String FALLBACK_COUNTRY_CODE = "US";
        private Lazy<String> _defaultCountryCode;

        #endregion


        #region properties

        public ClientConfiguration Configuration { get; private set; }
        internal RestClient RestClient { get; private set; }

        private String LastSessionCountryCode { get; set; }
        private String DefaultCountryCode { get { return _defaultCountryCode.Value; } }
        
        #endregion


        #region methods

        internal T HandleResponse<T>(RestResponse<T> response) where T : ModelBase
        {
            if (response.Exception != null)
                throw response.Exception;
            return response.Model;
        }

        private LoginModel HandleLoginResponse(RestResponse<LoginModel> response, LoginType loginType)
        {
            if (response.Exception != null)
                throw response.Exception;
            var model = response.Model;
            if (model != null)
            {
                this.LastSessionCountryCode = model.CountryCode;
                model.LoginType = loginType;
            }
            return model;
        }

        private String GetCountryCode()
        {
            return !String.IsNullOrEmpty(LastSessionCountryCode) ? LastSessionCountryCode : DefaultCountryCode;
        }

        private String GetDefaultCountryCode()
        {
            CountryModel cc = null;
            try
            {
                cc = this.GetCountry(1000);
            }
            catch { }
            if (cc != null && !String.IsNullOrEmpty(cc.CountryCode))
                return cc.CountryCode;
            if (Configuration != null && !String.IsNullOrEmpty(Configuration.DefaultCountryCode))
                return Configuration.DefaultCountryCode;
            return FALLBACK_COUNTRY_CODE;
        }

        /*
        public T Sync<T>(Task<T> task, Int32? timeout = null)
        {
            if (timeout.HasValue && !task.Wait(timeout.Value))
                throw new TimeoutException();
            return task.Result;
        }

        public Byte[] Sync(Stream stream, Int32? timeout = null)
        {
            using (var ms = new MemoryStream())
            {
                var task = stream.CopyToAsync(ms);
                if (timeout.HasValue && !task.Wait(timeout.Value))
                    throw new TimeoutException();
                else if (!timeout.HasValue)
                    task.Wait();
                return ms.ToArray();
            }
        }*/

        #endregion


        #region construction

        public OpenTidlClient(ClientConfiguration config)
        {
            this.Configuration = config;
            this.RestClient = new RestClient(config.ApiEndpoint, config.UserAgent);
            this._defaultCountryCode = new Lazy<String>(() => GetDefaultCountryCode());
        }

        #endregion
    }
}
