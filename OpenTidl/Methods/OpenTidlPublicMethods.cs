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
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidl.Transport;
using OpenTidl.Enums;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region album methods

        public async Task<AlbumModel> GetAlbum(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<AlbumModel>(
                RestUtility.FormatUrl("/albums/{id}", new { id = albumId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<ModelArray<AlbumModel>> GetAlbums(IEnumerable<Int32> albumIds)
        {
            return HandleResponse(await RestClient.Process<ModelArray<AlbumModel>>(
                "/albums", new
                {
                    ids = String.Join(",", albumIds),
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<AlbumModel>> GetSimilarAlbums(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<JsonList<AlbumModel>>(
                RestUtility.FormatUrl("/albums/{id}/similar", new { id = albumId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> GetAlbumTracks(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                RestUtility.FormatUrl("/albums/{id}/tracks", new { id = albumId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<AlbumReviewModel> GetAlbumReview(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<AlbumReviewModel>(
                RestUtility.FormatUrl("/albums/{id}/review", new { id = albumId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        #endregion


        #region artist methods

        public async Task<ArtistModel> GetArtist(Int32 artistId)
        {
            return HandleResponse(await RestClient.Process<ArtistModel>(
                RestUtility.FormatUrl("/artists/{id}", new { id = artistId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<AlbumModel>> GetArtistAlbums(Int32 artistId, AlbumFilter filter, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<AlbumModel>>(
                RestUtility.FormatUrl("/artists/{id}/albums", new { id = artistId }), new
                {
                    filter = filter.ToString(),
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> GetRadioFromArtist(Int32 artistId, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                RestUtility.FormatUrl("/artists/{id}/radio", new { id = artistId }), new
                {
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<ArtistModel>> GetSimilarArtists(Int32 artistId, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<ArtistModel>>(
                RestUtility.FormatUrl("/artists/{id}/similar", new { id = artistId }), new
                {
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> GetArtistTopTracks(Int32 artistId, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                RestUtility.FormatUrl("/artists/{id}/toptracks", new { id = artistId }), new
                {
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<VideoModel>> GetArtistVideos(Int32 artistId, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<VideoModel>>(
                RestUtility.FormatUrl("/artists/{id}/videos", new { id = artistId }), new
                {
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<ArtistBiographyModel> GetArtistBiography(Int32 artistId)
        {
            return HandleResponse(await RestClient.Process<ArtistBiographyModel>(
                RestUtility.FormatUrl("/artists/{id}/bio", new { id = artistId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<LinkModel>> GetArtistLinks(Int32 artistId, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<LinkModel>>(
                RestUtility.FormatUrl("/artists/{id}/links", new { id = artistId }), new
                {
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        #endregion


        #region country methods

        public async Task<CountryModel> GetCountry()
        {
            return HandleResponse(await RestClient.Process<CountryModel>("/country", null, null, "GET"));
        }

        #endregion

        
        #region search methods

        public async Task<JsonList<AlbumModel>> SearchAlbums(String query, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<AlbumModel>>(
                "/search/albums", new
                {
                    query = query,
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<ArtistModel>> SearchArtists(String query, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<ArtistModel>>(
                "/search/artists", new
                {
                    query = query,
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<PlaylistModel>> SearchPlaylists(String query, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<PlaylistModel>>(
                "/search/playlists", new
                {
                    query = query,
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> SearchTracks(String query, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                "/search/tracks", new
                {
                    query = query,
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<VideoModel>> SearchVideos(String query, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<VideoModel>>(
                "/search/videos", new
                {
                    query = query,
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<SearchResultModel> Search(String query, SearchType types, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<SearchResultModel>(
                "/search", new
                {
                    query = query,
                    types = types.ToString(),
                    offset = offset,
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        #endregion


        #region track methods

        public async Task<TrackModel> GetTrack(Int32 trackId)
        {
            return HandleResponse(await RestClient.Process<TrackModel>(
                RestUtility.FormatUrl("/tracks/{id}", new { id = trackId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<ContributorModel>> GetTrackContributors(Int32 trackId)
        {
            return HandleResponse(await RestClient.Process<JsonList<ContributorModel>>(
                RestUtility.FormatUrl("/tracks/{id}/contributors", new { id = trackId }), new
                {
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> GetRadioFromTrack(Int32 trackId, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                RestUtility.FormatUrl("/tracks/{id}/radio", new { id = trackId }), new
                {
                    limit = limit,
                    token = Configuration.Token,
                    countryCode = GetCountryCode()
                }, null, "GET"));
        }

        #endregion
    }
}
