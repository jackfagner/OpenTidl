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
using OpenTidl.Enums;
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidl.Transport;

namespace OpenTidl.Methods
{
    public partial class OpenTidlSession
    {
        #region opentidl methods


        #region logout methods

        public EmptyModel Logout(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.Logout(), timeout);
        }

        #endregion


        #region playlist methods

        public PlaylistModel GetPlaylist(String playlistUuid, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetPlaylist(playlistUuid), timeout);
        }

        public JsonList<TrackModel> GetPlaylistTracks(String playlistUuid, Int32? offset, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetPlaylistTracks(playlistUuid, offset ?? 0, limit ?? 9999), timeout);
        }

        public EmptyModel AddPlaylistTracks(String playlistUuid, IEnumerable<Int32> trackIds, Int32? toIndex, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.AddPlaylistTracks(playlistUuid, trackIds, toIndex ?? 0), timeout);
        }

        public EmptyModel DeletePlaylistTracks(String playlistUuid, IEnumerable<Int32> indices, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.DeletePlaylistTracks(playlistUuid, indices), timeout);
        }

        public EmptyModel DeletePlaylist(String playlistUuid, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.DeletePlaylist(playlistUuid), timeout);
        }

        public EmptyModel MovePlaylistTracks(String playlistUuid, IEnumerable<Int32> indices, Int32 toIndex, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.MovePlaylistTracks(playlistUuid, indices, toIndex), timeout);
        }

        public EmptyModel UpdatePlaylist(String playlistUuid, String title, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.UpdatePlaylist(playlistUuid, title), timeout);
        }

        #endregion


        #region session methods

        public ClientModel GetClient(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetClient(), timeout);
        }

        public SessionModel GetSession(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetSession(), timeout);
        }

        #endregion


        #region track methods

        public StreamUrlModel GetTrackStreamUrl(Int32 trackId, SoundQuality soundQuality, String playlistUuid, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetTrackStreamUrl(trackId, soundQuality, playlistUuid), timeout);
        }

        public StreamUrlModel GetTrackOfflineUrl(Int32 trackId, SoundQuality soundQuality, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetTrackOfflineUrl(trackId, soundQuality), timeout);
        }

        #endregion


        #region user methods

        public JsonList<ClientModel> GetUserClients(ClientFilter filter, Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetUserClients(filter, limit ?? 9999), timeout);
        }

        public JsonList<PlaylistModel> GetUserPlaylists(Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetUserPlaylists(limit ?? 9999), timeout);
        }

        public PlaylistModel CreateUserPlaylist(String title, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.CreateUserPlaylist(title), timeout);
        }

        public UserSubscriptionModel GetUserSubscription(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetUserSubscription(), timeout);
        }

        public UserModel GetUser(Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetUser(), timeout);
        }

        #endregion


        #region user favorites methods

        public JsonList<JsonListItem<AlbumModel>> GetFavoriteAlbums(Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetFavoriteAlbums(limit ?? 9999), timeout);
        }

        public JsonList<JsonListItem<ArtistModel>> GetFavoriteArtists(Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetFavoriteArtists(limit ?? 9999), timeout);
        }

        public JsonList<JsonListItem<PlaylistModel>> GetFavoritePlaylists(Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetFavoritePlaylists(limit ?? 9999), timeout);
        }

        public JsonList<JsonListItem<TrackModel>> GetFavoriteTracks(Int32? limit, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetFavoriteTracks(limit ?? 9999), timeout);
        }

        public EmptyModel AddFavoriteAlbum(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.AddFavoriteAlbum(albumId), timeout);
        }

        public EmptyModel AddFavoriteArtist(Int32 artistId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.AddFavoriteArtist(artistId), timeout);
        }

        public EmptyModel AddFavoritePlaylist(String playlistUuid, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.AddFavoritePlaylist(playlistUuid), timeout);
        }

        public EmptyModel AddFavoriteTrack(Int32 trackId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.AddFavoriteTrack(trackId), timeout);
        }

        public EmptyModel RemoveFavoriteAlbum(Int32 albumId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RemoveFavoriteAlbum(albumId), timeout);
        }

        public EmptyModel RemoveFavoriteArtist(Int32 artistId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RemoveFavoriteArtist(artistId), timeout);
        }

        public EmptyModel RemoveFavoritePlaylist(String playlistUuid, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RemoveFavoritePlaylist(playlistUuid), timeout);
        }

        public EmptyModel RemoveFavoriteTrack(Int32 trackId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.RemoveFavoriteTrack(trackId), timeout);
        }

        #endregion


        #region video methods

        public VideoModel GetVideo(Int32 videoId, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetVideo(videoId), timeout);
        }

        public VideoStreamUrlModel GetVideoStreamUrl(Int32 videoId, VideoQuality videoQuality, Int32? timeout)
        {
            return HelperExtensions.Sync(() => this.GetVideoStreamUrl(videoId, videoQuality), timeout);
        }

        #endregion


        #endregion
    }
}
