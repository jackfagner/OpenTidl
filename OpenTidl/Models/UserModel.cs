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
using OpenTidl.Enums;
using OpenTidl.Transport;

namespace OpenTidl.Models
{
    [DataContract]
    public class UserModel : ModelBase
    {
        [IgnoreDataMember]
        public DateTime? DateOfBirth { get; private set; }

        [DataMember(Name = "email")]
        public String Email { get; private set; }

        [DataMember(Name = "facebookUid")]
        public Int64 FacebookUid { get; private set; }

        [DataMember(Name = "firstName")]
        public String FirstName { get; private set; }

        [IgnoreDataMember]
        public UserGender Gender { get; private set; }

        [DataMember(Name = "id")]
        public Int64 Id { get; private set; }

        [DataMember(Name = "lastName")]
        public String LastName { get; private set; }

        [DataMember(Name = "newsletter")]
        public Boolean Newsletter { get; private set; }

        [DataMember(Name = "picture")]
        public String Picture { get; private set; }

        [DataMember(Name = "username")]
        public String Username { get; private set; }


        #region json helpers

        [DataMember(Name = "gender")]
        private String GenderEnumHelper
        {
            get { return Gender.ToString().Substring(0, 1).ToLower(); }
            set 
            {
                switch ((value ?? "").ToLower())
                {
                    case "f":
                        Gender = UserGender.Female;
                        break;
                    case "m":
                        Gender = UserGender.Male;
                        break;
                    default:
                        Gender = UserGender.NotSpecified;
                        break;
                }
            }
        }

        [DataMember(Name = "dateOfBirth")]
        private String DateOfBirthHelper
        {
            get { return RestUtility.FormatDate(DateOfBirth); }
            set { DateOfBirth = RestUtility.ParseDate(value); }
        }

        #endregion
    }
}
