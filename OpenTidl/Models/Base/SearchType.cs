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

namespace OpenTidl.Models.Base
{
    public class SearchType
    {
        #region properties

        public Boolean Albums { get; private set; }
        public Boolean Artists { get; private set; }
        public Boolean Playlists { get; private set; }
        public Boolean Tracks { get; private set; }
        public Boolean Videos { get; private set; }

        #endregion


        #region methods

        public override string ToString()
        {
            var types = new List<String>();
            if (this.Albums) types.Add("ALBUMS");
            if (this.Artists) types.Add("ARTISTS");
            if (this.Playlists) types.Add("PLAYLISTS");
            if (this.Tracks) types.Add("TRACKS");
            if (this.Videos) types.Add("VIDEOS");
            return String.Join(",", types);
        }

        #endregion


        #region construction

        public static SearchType ALL
        {
            get
            {
                return new SearchType(true, true, true, true, true);
            }
        }

        public static SearchType ALBUMS
        {
            get
            {
                return new SearchType(true, false, false, false, false);
            }
        }

        public static SearchType ARTISTS
        {
            get
            {
                return new SearchType(false, true, false, false, false);
            }
        }

        public static SearchType PLAYLISTS
        {
            get
            {
                return new SearchType(false, false, true, false, false);
            }
        }

        public static SearchType TRACKS
        {
            get
            {
                return new SearchType(false, false, false, true, false);
            }
        }

        public static SearchType VIDEOS
        {
            get
            {
                return new SearchType(false, false, false, false, true);
            }
        }

        public static SearchType Select(Boolean albums, Boolean artists, Boolean playlists, Boolean tracks, Boolean videos)
        {
            return new SearchType(albums, artists, playlists, tracks, videos);
        }

        private SearchType(Boolean albums, Boolean artists, Boolean playlists, Boolean tracks, Boolean videos)
        {
            this.Albums = albums;
            this.Artists = artists;
            this.Playlists = playlists;
            this.Tracks = tracks;
            this.Videos = videos;
        }

        #endregion
    }
}
