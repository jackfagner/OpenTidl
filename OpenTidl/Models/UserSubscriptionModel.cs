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
    public class UserSubscriptionModel : ModelBase
    {
        [IgnoreDataMember]
        public SoundQuality HighestSoundQuality { get; private set; }

        [DataMember(Name = "status")]
        public String Status { get; private set; }

        [DataMember(Name = "subscription")]
        public SubscriptionModel Subscription { get; private set; }

        [IgnoreDataMember]
        public DateTime? ValidUntil { get; private set; }


        [DataMember(Name = "premiumAccess")]
        public Boolean PremiumAccess { get; private set; }

        [DataMember(Name = "canGetTrial")]
        public Boolean CanGetTrial { get; private set; }


        [IgnoreDataMember]
        public Boolean IsBasicSubscription
        {
            get { return this.Subscription != null && this.Subscription.Type == SubscriptionType.BASIC; }
        }

        [IgnoreDataMember]
        public Boolean IsFreeSubscription
        {
            get { return this.Subscription != null && this.Subscription.Type == SubscriptionType.FREE; }
        }

        [IgnoreDataMember]
        public Boolean IsHifiAvailable
        {
            get { return (Int32)this.HighestSoundQuality >= (Int32)SoundQuality.LOSSLESS; }
        }


        #region json helpers

        [DataMember(Name = "highestSoundQuality")]
        private String HighestSoundQualityEnumHelper
        {
            get { return HighestSoundQuality.ToString(); }
            set { HighestSoundQuality = RestUtility.ParseEnum<SoundQuality>(value); }
        }

        [DataMember(Name = "validUntil")]
        private String ValidUntilDateHelper
        {
            get { return RestUtility.FormatDate(ValidUntil); }
            set { ValidUntil = RestUtility.ParseDate(value); }
        }

        #endregion
    }
}
