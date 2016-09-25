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
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidl.Transport;

namespace OpenTidl.Methods
{
    public partial class OpenTidlSession
    {
        #region properties

        private OpenTidlClient OpenTidlClient { get; set; }
        //private RestClient RestClient { get { return OpenTidlClient.RestClient; } }
        private RestClient RestClient { get; set; }

        public LoginModel LoginResult { get; private set; }

        //FIXME: Throw error if empty
        public String SessionId { get { return LoginResult != null ? LoginResult.SessionId : null; } }
        public Int32 UserId { get { return LoginResult != null ? LoginResult.UserId : 0; } }
        public String CountryCode { get { return LoginResult != null ? LoginResult.CountryCode : null; } }

        #endregion


        #region opentidl methods
        

        #region logout methods

        public async Task<EmptyModel> Logout()
        {
            var result = await RestClient.Process<EmptyModel>("/logout", new
            {
                sessionId = SessionId,
                countryCode = CountryCode
            }, new { }, "POST");

            if (result == null || result.Exception == null)
                this.LoginResult = null; //Clear session
            return HandleResponse(result);
        }

        #endregion


        #region playlist methods

        public async Task<PlaylistModel> GetPlaylist(String playlistUuid)
        {
            return HandleResponse(await RestClient.Process<PlaylistModel>(
                RestUtility.FormatUrl("/playlists/{uuid}", new { uuid = playlistUuid }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<JsonList<TrackModel>> GetPlaylistTracks(String playlistUuid, Int32 offset = 0, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<TrackModel>>(
                RestUtility.FormatUrl("/playlists/{uuid}/tracks", new { uuid = playlistUuid }), new
                {
                    offset = offset,
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<EmptyModel> AddPlaylistTracks(String playlistUuid, String playlistETag, IEnumerable<Int32> trackIds, Int32 toIndex = 0)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/playlists/{uuid}/tracks", new { uuid = playlistUuid }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    trackIds = String.Join(",", trackIds),
                    toIndex = toIndex
                }, "POST",
                Header("If-None-Match", playlistETag)));
        }

        public async Task<EmptyModel> DeletePlaylistTracks(String playlistUuid, String playlistETag, IEnumerable<Int32> indices)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/playlists/{uuid}/tracks/{indices}", new
                {
                    uuid = playlistUuid,
                    indices = String.Join(",", indices)
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE",
                Header("If-None-Match", playlistETag)));
        }

        public async Task<EmptyModel> DeletePlaylist(String playlistUuid, String playlistETag)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/playlists/{uuid}", new
                {
                    uuid = playlistUuid
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE",
                Header("If-None-Match", playlistETag)));
        }

        public async Task<EmptyModel> MovePlaylistTracks(String playlistUuid, String playlistETag, IEnumerable<Int32> indices, Int32 toIndex = 0)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/playlists/{uuid}/tracks/{indices}", new
                {
                    uuid = playlistUuid,
                    indices = String.Join(",", indices)
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    toIndex = toIndex
                }, "POST",
                Header("If-None-Match", playlistETag)));
        }

        public async Task<EmptyModel> UpdatePlaylist(String playlistUuid, String playlistETag, String title)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/playlists/{uuid}", new
                {
                    uuid = playlistUuid
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    title = title
                }, "POST",
                Header("If-None-Match", playlistETag)));
        }

        #endregion


        #region session methods

        public async Task<ClientModel> GetClient()
        {
            return HandleResponse(await RestClient.Process<ClientModel>(
                RestUtility.FormatUrl("/sessions/{sessionId}/client", new { sessionId = SessionId }),
                null, null, "GET"));
        }

        public async Task<SessionModel> GetSession()
        {
            return HandleResponse(await RestClient.Process<SessionModel>(
                RestUtility.FormatUrl("/sessions/{sessionId}", new { sessionId = SessionId }),
                null, null, "GET"));
        }

        #endregion


        #region track methods

        public async Task<StreamUrlModel> GetTrackStreamUrl(Int32 trackId, SoundQuality soundQuality, String playlistUuid)
        {
            return HandleResponse(await RestClient.Process<StreamUrlModel>(
                RestUtility.FormatUrl("/tracks/{id}/streamUrl", new { id = trackId }), new
                {
                    soundQuality = soundQuality,
                    playlistUuid = playlistUuid,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<StreamUrlModel> GetTrackOfflineUrl(Int32 trackId, SoundQuality soundQuality)
        {
            return HandleResponse(await RestClient.Process<StreamUrlModel>(
                RestUtility.FormatUrl("/tracks/{id}/offlineUrl", new { id = trackId }), new
                {
                    soundQuality = soundQuality,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        #endregion


        #region user methods

        public async Task<JsonList<ClientModel>> GetUserClients(ClientFilter filter, Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<ClientModel>>(
                RestUtility.FormatUrl("/users/{userId}/clients", new { userId = UserId }), new
                {
                    filter = filter.ToString(),
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<JsonList<PlaylistModel>> GetUserPlaylists(Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<PlaylistModel>>(
                RestUtility.FormatUrl("/users/{userId}/playlists", new { userId = UserId }), new
                {
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<PlaylistModel> CreateUserPlaylist(String title)
        {
            return HandleResponse(await RestClient.Process<PlaylistModel>(
                RestUtility.FormatUrl("/users/{userId}/playlists", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    title = title
                }, "POST"));
        }

        public async Task<UserSubscriptionModel> GetUserSubscription()
        {
            return HandleResponse(await RestClient.Process<UserSubscriptionModel>(
                RestUtility.FormatUrl("/users/{userId}/subscription", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<UserModel> GetUser()
        {
            return HandleResponse(await RestClient.Process<UserModel>(
                RestUtility.FormatUrl("/users/{userId}", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        #endregion


        #region user favorites methods

        public async Task<JsonList<JsonListItem<AlbumModel>>> GetFavoriteAlbums(Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<JsonListItem<AlbumModel>>>(
                RestUtility.FormatUrl("/users/{userId}/favorites/albums", new { userId = UserId }), new
                {
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<JsonList<JsonListItem<ArtistModel>>> GetFavoriteArtists(Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<JsonListItem<ArtistModel>>>(
                RestUtility.FormatUrl("/users/{userId}/favorites/artists", new { userId = UserId }), new
                {
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<JsonList<JsonListItem<PlaylistModel>>> GetFavoritePlaylists(Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<JsonListItem<PlaylistModel>>>(
                RestUtility.FormatUrl("/users/{userId}/favorites/playlists", new { userId = UserId }), new
                {
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<JsonList<JsonListItem<TrackModel>>> GetFavoriteTracks(Int32 limit = 9999)
        {
            return HandleResponse(await RestClient.Process<JsonList<JsonListItem<TrackModel>>>(
                RestUtility.FormatUrl("/users/{userId}/favorites/tracks", new { userId = UserId }), new
                {
                    limit = limit,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<EmptyModel> AddFavoriteAlbum(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/albums", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new {
                    albumId = albumId
                }, "POST"));
        }

        public async Task<EmptyModel> AddFavoriteArtist(Int32 artistId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/artists", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    artistId = artistId
                }, "POST"));
        }

        public async Task<EmptyModel> AddFavoritePlaylist(String playlistUuid)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/playlists", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    uuid = playlistUuid
                }, "POST"));
        }

        public async Task<EmptyModel> AddFavoriteTrack(Int32 trackId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/tracks", new { userId = UserId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, new
                {
                    trackId = trackId
                }, "POST"));
        }

        public async Task<EmptyModel> RemoveFavoriteAlbum(Int32 albumId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/albums/{albumId}", new 
                { 
                    userId = UserId,
                    albumId = albumId
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE"));
        }

        public async Task<EmptyModel> RemoveFavoriteArtist(Int32 artistId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/artists/{artistId}", new
                {
                    userId = UserId,
                    artistId = artistId
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE"));
        }

        public async Task<EmptyModel> RemoveFavoritePlaylist(String playlistUuid)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/playlists/{uuid}", new
                {
                    userId = UserId,
                    uuid = playlistUuid
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE"));
        }

        public async Task<EmptyModel> RemoveFavoriteTrack(Int32 trackId)
        {
            return HandleResponse(await RestClient.Process<EmptyModel>(
                RestUtility.FormatUrl("/users/{userId}/favorites/tracks/{trackId}", new
                {
                    userId = UserId,
                    trackId = trackId
                }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "DELETE"));
        }

        #endregion


        #region video methods

        public async Task<VideoModel> GetVideo(Int32 videoId)
        {
            return HandleResponse(await RestClient.Process<VideoModel>(
                RestUtility.FormatUrl("/videos/{id}", new { id = videoId }), new
                {
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        public async Task<VideoStreamUrlModel> GetVideoStreamUrl(Int32 videoId, VideoQuality videoQuality)
        {
            return HandleResponse(await RestClient.Process<VideoStreamUrlModel>(
                RestUtility.FormatUrl("/videos/{id}/streamurl", new { id = videoId }), new
                {
                    videoQuality = videoQuality,
                    sessionId = SessionId,
                    countryCode = CountryCode
                }, null, "GET"));
        }

        #endregion


        #endregion


        #region methods

        private T HandleResponse<T>(RestResponse<T> response) where T : ModelBase
        {
            return this.OpenTidlClient.HandleResponse(response);
        }

        private KeyValuePair<String, String> Header(String header, String value)
        {
            return this.OpenTidlClient.Header(header, value);
        }

        #endregion


        #region construction

        internal OpenTidlSession(OpenTidlClient client, LoginModel loginModel)
        {
            this.OpenTidlClient = client;
            this.LoginResult = loginModel;
            this.RestClient = new RestClient(client.Configuration.ApiEndpoint, client.Configuration.UserAgent, Header("X-Tidal-SessionId", loginModel?.SessionId ?? ""));
        }

        #endregion
    }
}
