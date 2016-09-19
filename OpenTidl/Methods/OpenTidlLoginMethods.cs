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
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidl.Transport;
using OpenTidl.Methods;
using OpenTidl.Enums;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region login methods

        public async Task<OpenTidlSession> LoginWithFacebook(String accessToken)
        {
            return new OpenTidlSession(this, HandleLoginResponse(await RestClient.Process<LoginModel>("/login/facebook", null, new
            {
                accessToken = accessToken,
                token = Configuration.Token,
                clientUniqueKey = Configuration.ClientUniqueKey,
                clientVersion = Configuration.ClientVersion
            }, "POST"), LoginType.Facebook));
        }

        public async Task<OpenTidlSession> LoginWithSpidToken(String accessToken, String spidUserId)
        {
            return new OpenTidlSession(this, HandleLoginResponse(await RestClient.Process<LoginModel>("/login/spid/token", null, new
            {
                accessToken = accessToken,
                spidUserId = spidUserId,
                token = Configuration.Token,
                clientUniqueKey = Configuration.ClientUniqueKey,
                clientVersion = Configuration.ClientVersion
            }, "POST"), LoginType.Spid));
        }

        public async Task<OpenTidlSession> LoginWithToken(String authenticationToken)
        {
            return new OpenTidlSession(this, HandleLoginResponse(await RestClient.Process<LoginModel>("/login/token", null, new
            {
                authenticationToken = authenticationToken,
                token = Configuration.Token,
                clientUniqueKey = Configuration.ClientUniqueKey,
                clientVersion = Configuration.ClientVersion
            }, "POST"), LoginType.Token));
        }

        public async Task<OpenTidlSession> LoginWithTwitter(String accessToken, String accessTokenSecret)
        {
            return new OpenTidlSession(this, HandleLoginResponse(await RestClient.Process<LoginModel>("/login/twitter", null, new
            {
                accessToken = accessToken,
                accessTokenSecret = accessTokenSecret,
                token = Configuration.Token,
                clientUniqueKey = Configuration.ClientUniqueKey,
                clientVersion = Configuration.ClientVersion
            }, "POST"), LoginType.Twitter));
        }

        public async Task<OpenTidlSession> LoginWithUsername(String username, String password)
        {
            return new OpenTidlSession(this, HandleLoginResponse(await RestClient.Process<LoginModel>("/login/username", null, new
            {
                username = username,
                password = password,
                token = Configuration.Token,
                clientUniqueKey = Configuration.ClientUniqueKey,
                clientVersion = Configuration.ClientVersion
            }, "POST"), LoginType.Username));
        }

        #endregion


        #region session methods

        public async Task<OpenTidlSession> RestoreSession(String sessionId)
        {
            return new OpenTidlSession(this, LoginModel.FromSession(HandleResponse(await RestClient.Process<SessionModel>(
                RestUtility.FormatUrl("/sessions/{sessionId}", new { sessionId = sessionId }),
                null, null, "GET"))));
        }

        #endregion


        #region user methods

        public async Task<RecoverPasswordResponseModel> RecoverPassword(String username)
        {
            return HandleResponse(await RestClient.Process<RecoverPasswordResponseModel>(
                RestUtility.FormatUrl("/users/{username}/recoverpassword", new { username = username }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }
        
        #endregion
    }
}
