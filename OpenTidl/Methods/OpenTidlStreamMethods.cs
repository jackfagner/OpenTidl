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
using System.IO;

namespace OpenTidl
{
    public partial class OpenTidlClient
    {
        #region image methods

        /// <summary>
        /// Helper method to retrieve a stream with an album cover image
        /// </summary>
        public Stream GetAlbumCover(AlbumModel model, AlbumCoverSize size)
        {
            return GetAlbumCover(model.Cover, model.Id, size);
        }

        /// <summary>
        /// Helper method to retrieve a stream with an album cover image
        /// </summary>
        public Stream GetAlbumCover(String cover, Int32 albumId, AlbumCoverSize size)
        {
            var w = 750;
            var h = 750;
            if (!RestUtility.ParseImageSize(size.ToString(), out w, out h))
                throw new ArgumentException("Invalid image size", "size");
            String url = null;
            if (!String.IsNullOrEmpty(cover))
                url = String.Format("http://resources.wimpmusic.com/images/{0}/{1}x{2}.jpg", cover.Replace('-', '/'), w, h);
            else
                url = String.Format("http://images.tidalhifi.com/im/im?w={1}&h={2}&albumid={0}&noph", albumId, w, h);
            return RestClient.GetStream(url);
        }

        /// <summary>
        /// Helper method to retrieve a stream with an artists picture
        /// </summary>
        public Stream GetArtistPicture(ArtistModel model, ArtistPictureSize size)
        {
            return GetArtistPicture(model.Picture, model.Id, size);
        }

        /// <summary>
        /// Helper method to retrieve a stream with an artists picture
        /// </summary>
        public Stream GetArtistPicture(String picture, Int32 artistId, ArtistPictureSize size)
        {
            var w = 750;
            var h = 500;
            if (!RestUtility.ParseImageSize(size.ToString(), out w, out h))
                throw new ArgumentException("Invalid image size", "size");
            String url = null;
            if (!String.IsNullOrEmpty(picture))
                url = String.Format("http://resources.wimpmusic.com/images/{0}/{1}x{2}.jpg", picture.Replace('-', '/'), w, h);
            else
                url = String.Format("http://images.tidalhifi.com/im/im?w={1}&h={2}&artistid={0}&noph", artistId, w, h);
            return RestClient.GetStream(url);
        }

        /// <summary>
        /// Helper method to retrieve a stream with a playlist image
        /// </summary>
        public Stream GetPlaylistImage(PlaylistModel model, PlaylistImageSize size)
        {
            return GetPlaylistImage(model.Image, model.Uuid, size);
        }

        /// <summary>
        /// Helper method to retrieve a stream with a playlist image
        /// </summary>
        public Stream GetPlaylistImage(String image, String playlistUuid, PlaylistImageSize size)
        {
            var w = 750;
            var h = 500;
            if (!RestUtility.ParseImageSize(size.ToString(), out w, out h))
                throw new ArgumentException("Invalid image size", "size");
            String url = null;
            if (!String.IsNullOrEmpty(image))
                url = String.Format("http://resources.wimpmusic.com/images/{0}/{1}x{2}.jpg", image.Replace('-', '/'), w, h);
            else
                url = String.Format("http://images.tidalhifi.com/im/im?w={1}&h={2}&uuid={0}&rows=2&cols=3&noph", playlistUuid, w, h);
            return RestClient.GetStream(url);
        }

        /// <summary>
        /// Helper method to retrieve a stream with a video conver image
        /// </summary>
        public Stream GetVideoImage(VideoModel model, VideoImageSize size)
        {
            return GetVideoImage(model.ImageId, model.ImagePath, size);
        }

        /// <summary>
        /// Helper method to retrieve a stream with a video conver image
        /// </summary>
        public Stream GetVideoImage(String imageId, String imagePath, VideoImageSize size)
        {
            var w = 750;
            var h = 500;
            if (!RestUtility.ParseImageSize(size.ToString(), out w, out h))
                throw new ArgumentException("Invalid image size", "size");
            String url = null;
            if (!String.IsNullOrEmpty(imageId))
                url = String.Format("http://resources.wimpmusic.com/images/{0}/{1}x{2}.jpg", imageId.Replace('-', '/'), w, h);
            else
                url = String.Format("http://images.tidalhifi.com/im/im?w={1}&h={2}&img={0}&noph", imagePath, w, h);
            return RestClient.GetStream(url);
        }

        #endregion


        #region track/video methods

        /// <summary>
        /// Helper method to retrieve the audio/video stream with correct user-agent, etc.
        /// </summary>
        public Stream GetStream(String streamUrl)
        {
            return RestClient.GetStream(streamUrl);
        }

        #endregion
    }
}
