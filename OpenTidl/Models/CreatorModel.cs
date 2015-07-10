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

namespace OpenTidl.Models
{
    [DataContract]
    public class CreatorModel : ModelBase
    {
        [DataMember(Name = "id")]
        public Int32 Id { get; private set; }

        [DataMember(Name = "name")]
        public String Name { get; private set; }



        [DataMember(Name = "child")]
        public Boolean Child { get; private set; }

        [DataMember(Name = "parent")]
        public Boolean Parent { get; private set; }
    }
}
