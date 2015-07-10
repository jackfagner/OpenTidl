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

namespace OpenTidl.Enums
{
    public enum StreamResponseType
    {
        OK = 0,
        INVALID_SESSION = 1,
        BAD_NETWORK = 2,
        NO_NETWORK = 3,
        OFFLINE_NOT_AVAILABLE = 4,
        STREAMING_NOT_ALLOWED = 5,
        STREAMING_PRIVILEGES_LOST = 6,
        STREAMING_TRACK_NOT_READY = 7,
        API_ERROR = 8
    }
}
