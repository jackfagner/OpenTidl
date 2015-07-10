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
using OpenTidl.Transport;

namespace OpenTidl.Models
{
    [DataContract]
    public class TrackModel : ModelBase
    {
        [DataMember(Name = "album")]
        public AlbumModel Album { get; private set; }

        [DataMember(Name = "allowStreaming")]
        public Boolean AllowStreaming { get; private set; }

        [DataMember(Name = "artist")]
        public ArtistModel Artist { get; private set; }

        [DataMember(Name = "artists")]
        public ArtistModel[] Artists { get; private set; }

        [DataMember(Name = "duration")]
        public Int32 Duration { get; private set; }

        [DataMember(Name = "id")]
        public Int32 Id { get; private set; }

        [DataMember(Name = "streamReady")]
        public Boolean StreamReady { get; private set; }

        [IgnoreDataMember]
        public DateTime? StreamStartDate { get; private set; }

        [DataMember(Name = "title")]
        public String Title { get; private set; }

        [DataMember(Name = "trackNumber")]
        public Int32 TrackNumber { get; private set; }

        [DataMember(Name = "version")]
        public String Version { get; private set; }

        [DataMember(Name = "volumeNumber")]
        public Int32 VolumeNumber { get; private set; }


        #region json helpers

        [DataMember(Name = "streamStartDate")]
        private String StreamStartDateHelper
        {
            get { return RestUtility.FormatDate(StreamStartDate); }
            set { StreamStartDate = RestUtility.ParseDate(value); }
        }

        #endregion
    }
}
