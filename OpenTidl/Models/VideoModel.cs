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
using OpenTidl.Enums;
using System.Runtime.Serialization;
using OpenTidl.Transport;

namespace OpenTidl.Models
{
    [DataContract]
    public class VideoModel : ModelBase
    {
        [DataMember(Name = "artist")]
        public ArtistModel Artist { get; private set; }

        [DataMember(Name = "artists")]
        public ArtistModel[] Artists { get; private set; }

        [DataMember(Name = "duration")]
        public Int32 Duration { get; private set; }

        [DataMember(Name = "id")]
        public Int32 Id { get; private set; }

        [DataMember(Name = "imageId")]
        public String ImageId { get; private set; }

        [DataMember(Name = "imagePath")]
        public String ImagePath { get; private set; }

        [IgnoreDataMember]
        public VideoQuality Quality { get; private set; }

        [IgnoreDataMember]
        public DateTime? ReleaseDate { get; private set; }

        [DataMember(Name = "streamReady")]
        public Boolean StreamReady { get; private set; }

        [IgnoreDataMember]
        public DateTime? StreamStartDate { get; private set; }

        [DataMember(Name = "title")]
        public String Title { get; private set; }


        #region json helpers

        [DataMember(Name = "quality")]
        private String QualityEnumHelper
        {
            get { return Quality.ToString(); }
            set { Quality = RestUtility.ParseEnum<VideoQuality>(value); }
        }

        [DataMember(Name = "releaseDate")]
        private String ReleaseDateHelper
        {
            get { return RestUtility.FormatDate(ReleaseDate); }
            set { ReleaseDate = RestUtility.ParseDate(value); }
        }

        [DataMember(Name = "streamStartDate")]
        private String StreamStartDateHelper
        {
            get { return RestUtility.FormatDate(StreamStartDate); }
            set { StreamStartDate = RestUtility.ParseDate(value); }
        }

        #endregion
    }
}
