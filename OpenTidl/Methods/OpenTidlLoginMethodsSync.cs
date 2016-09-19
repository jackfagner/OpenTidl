/*
    Copyright (C) 2016  Jack Fagner

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
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region login methods

        public OpenTidlSession LoginWithFacebook(String accessToken, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.LoginWithFacebook(accessToken), timeout);
        }

        public OpenTidlSession LoginWithSpidToken(String accessToken, String spidUserId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.LoginWithSpidToken(accessToken, spidUserId), timeout);
        }

        public OpenTidlSession LoginWithToken(String authenticationToken, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.LoginWithToken(authenticationToken), timeout);
        }

        public OpenTidlSession LoginWithTwitter(String accessToken, String accessTokenSecret, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.LoginWithTwitter(accessToken, accessTokenSecret), timeout);
        }

        public OpenTidlSession LoginWithUsername(String username, String password, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.LoginWithUsername(username, password), timeout);
        }

        #endregion


        #region session methods

        public OpenTidlSession RestoreSession(String sessionId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RestoreSession(sessionId), timeout);
        }

        #endregion


        #region user methods

        public RecoverPasswordResponseModel RecoverPassword(String username, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RecoverPassword(username), timeout);
        }

        #endregion
    }
}
