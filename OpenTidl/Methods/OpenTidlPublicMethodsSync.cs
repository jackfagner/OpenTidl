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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidl.Transport;
using OpenTidl.Enums;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region album methods

        public AlbumModel GetAlbum(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetAlbum(albumId), timeout);
        }

        public ModelArray<AlbumModel> GetAlbums(IEnumerable<Int32> albumIds, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetAlbums(albumIds), timeout);
        }

        public JsonList<AlbumModel> GetSimilarAlbums(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetSimilarAlbums(albumId), timeout);
        }

        public JsonList<TrackModel> GetAlbumTracks(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetAlbumTracks(albumId), timeout);
        }

        public AlbumReviewModel GetAlbumReview(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetAlbumReview(albumId), timeout);
        }

        #endregion


        #region artist methods

        public ArtistModel GetArtist(Int32 artistId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtist(artistId), timeout);
        }

        public JsonList<AlbumModel> GetArtistAlbums(Int32 artistId, AlbumFilter filter, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtistAlbums(artistId, filter, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<TrackModel> GetRadioFromArtist(Int32 artistId, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetRadioFromArtist(artistId, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<ArtistModel> GetSimilarArtists(Int32 artistId, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetSimilarArtists(artistId, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<TrackModel> GetArtistTopTracks(Int32 artistId, Int32? offset, Int32? limit , Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtistTopTracks(artistId, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<VideoModel> GetArtistVideos(Int32 artistId, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtistVideos(artistId, offset ?? 0, limit ?? 9999), timeout);
        }

        public ArtistBiographyModel GetArtistBiography(Int32 artistId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtistBiography(artistId), timeout);
        }

        public JsonList<LinkModel> GetArtistLinks(Int32 artistId, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetArtistLinks(artistId, limit ?? 9999), timeout);
        }

        #endregion


        #region country methods

        public CountryModel GetCountry(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetCountry(), timeout);
        }

        #endregion


        #region search methods

        public JsonList<AlbumModel> SearchAlbums(String query, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.SearchAlbums(query, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<ArtistModel> SearchArtists(String query, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.SearchArtists(query, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<PlaylistModel> SearchPlaylists(String query, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.SearchPlaylists(query, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<TrackModel> SearchTracks(String query, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.SearchTracks(query, offset ?? 0, limit ?? 9999), timeout);
        }

        public JsonList<VideoModel> SearchVideos(String query, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.SearchVideos(query, offset ?? 0, limit ?? 9999), timeout);
        }

        public SearchResultModel Search(String query, SearchType types, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.Search(query, types, offset ?? 0, limit ?? 9999), timeout);
        }

        #endregion


        #region track methods

        public TrackModel GetTrack(Int32 trackId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetTrack(trackId), timeout);
        }

        public JsonList<ContributorModel> GetTrackContributors(Int32 trackId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetTrackContributors(trackId), timeout);
        }

        public JsonList<TrackModel> GetRadioFromTrack(Int32 trackId, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetRadioFromTrack(trackId, limit ?? 9999), timeout);
        }

        #endregion
    }
}
