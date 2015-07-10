# OpenTidl
**Free and open source API for TIDAL music streaming service**

This API is wirtten in C# 5.0 (.NET 4.5) and has no external dependencies.

Most (relevant) functions used by TIDAL's web player or Android app are implemented, including:
* Searching (albums, artists, tracks, videos)
* Fetching metadata for albums, artists, tracks (including cover art, artist pictures, etc)
* Logging in using username/password, Facebook, SPID, etc. Only username/password is fully tested.
* Playlist management
* Favorite album/artist/track/playlist management
* Streaming tracks, including lossless, and videos - up to 1080p

Searching and fetching metadata for albums/artists/tracks does not require an active TIDAL subscription.

**Disclaimer:**
This product uses TIDAL but is not endorsed, certified or otherwise approved in any way by TIDAL. TIDAL is the registered trade mark of Aspiro.
