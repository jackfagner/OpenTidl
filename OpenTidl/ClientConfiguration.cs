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
using System.Net.NetworkInformation;

namespace OpenTidl
{
    public class ClientConfiguration
    {
        #region static properties

        private static Lazy<ClientConfiguration> _defaultSettings = new Lazy<ClientConfiguration>(() =>
            new ClientConfiguration("https://api.tidalhifi.com/v1", "okhttp/2.4.0",
                "kgsOOmYk3zShYrNP", DefaultClientUniqueKey, "1.10.2", "US"));

        public static ClientConfiguration Default
        {
            get { return _defaultSettings.Value; }
        }

        #endregion


        #region properties

        public String ApiEndpoint { get; private set; }
        public String UserAgent { get; private set; }
        public String Token { get; private set; }
        public String ClientUniqueKey { get; private set; }
        public String ClientVersion { get; private set; }
        public String DefaultCountryCode { get; private set; }
        
        #endregion


        #region methods

        private static String DefaultClientUniqueKey
        {
            get
            {
                var macAddress = NetworkInterface.GetAllNetworkInterfaces().Where(i => 
                    i.OperationalStatus == OperationalStatus.Up && i.NetworkInterfaceType != NetworkInterfaceType.Loopback).OrderByDescending(i => 
                        i.Speed).Select(i => i.GetPhysicalAddress().GetAddressBytes()).FirstOrDefault();
                if (macAddress == null)
                    return "123456789012345";
                return String.Join("", macAddress.Skip(1).Select(b => b.ToString("000")));
            }
        }

        #endregion


        #region construction

        public ClientConfiguration(String apiEndpoint, String userAgent, String token, String clientUniqueKey, String clientVersion, String defaultCountryCode)
        {
            this.ApiEndpoint = apiEndpoint;
            this.UserAgent = userAgent;
            this.Token = token;
            this.ClientUniqueKey = clientUniqueKey;
            this.ClientVersion = clientVersion;
            this.DefaultCountryCode = defaultCountryCode;
        }

        #endregion
    }
}
