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
using OpenTidl.Enums;
using OpenTidl.Models.Base;
using System.Runtime.Serialization;
using OpenTidl.Transport;

namespace OpenTidl.Models
{
    [DataContract]
    public class PlaylistModel : ModelBase
    {
        [IgnoreDataMember]
        public DateTime? Created { get; private set; }

        [DataMember(Name = "creator")]
        public CreatorModel Creator { get; private set; }

        [DataMember(Name = "description")]
        public String Description { get; private set; }

        [DataMember(Name = "duration")]
        public Int32 Duration { get; private set; }

        [DataMember(Name = "id")]
        public Int32 Id { get; private set; }

        [DataMember(Name = "image")]
        public String Image { get; private set; }

        [IgnoreDataMember]
        public DateTime? LastUpdated { get; private set; }

        [DataMember(Name = "numberOfTracks")]
        public Int32 NumberOfTracks { get; private set; }

        [DataMember(Name = "offlineDateAdded")]
        public Int64 OfflineDateAdded { get; private set; }

        [DataMember(Name = "title")]
        public String Title { get; private set; }

        [IgnoreDataMember]
        public PlaylistType Type { get; private set; }

        [DataMember(Name = "uuid")]
        public String Uuid { get; private set; }



        [DataMember(Name = "url")]
        public String Url { get; private set; }

        [DataMember(Name = "publicPlaylist")]
        public Boolean PublicPlaylist { get; private set; }


        #region json helpers

        [DataMember(Name = "type")]
        private String TypeEnumHelper
        {
            get { return Type.ToString(); }
            set { Type = RestUtility.ParseEnum<PlaylistType>(value); }
        }

        [DataMember(Name = "created")]
        private String CreatedDateHelper
        {
            get { return RestUtility.FormatDate(Created); }
            set { Created = RestUtility.ParseDate(value); }
        }

        [DataMember(Name = "lastUpdated")]
        private String LastUpdatedDateHelper
        {
            get { return RestUtility.FormatDate(LastUpdated); }
            set { LastUpdated = RestUtility.ParseDate(value); }
        }

        #endregion
    }
}
