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
using System.Runtime.Serialization;

namespace OpenTidl.Models.Base
{
    [DataContract]
    public class JsonList<T> : ModelBase
    {
        [DataMember(Name = "limit")]
        public Int32 Limit { get; private set; }

        [DataMember(Name = "offset")]
	    public Int32 Offset { get; private set; }

        [DataMember(Name = "totalNumberOfItems")]
        public Int32 TotalNumberOfItems { get; private set; }
        
        [DataMember(Name = "items")]
        public T[] Items { get; private set; }
    }
}
