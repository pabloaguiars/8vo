using System;
using System.Collections.Generic;
using System.Linq;

namespace flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayList playList1;
            PlayList playList2;
            PlayList playList3;
            Song[] test_songs = GetTestSongs(20);

            playList1 = RandomFillPlaylist(test_songs);
            playList2 = RandomFillPlaylist(test_songs);
            playList3 = RandomFillPlaylist(test_songs);

            Console.WriteLine("\nPRINTING PLAYLIST 1\n");
            playList1.GetSongs();
            Console.WriteLine("\nPRINTING PLAYLIST 2\n");
            playList2.GetSongs();
            Console.WriteLine("\nPRINTING PLAYLIST 3\n");
            playList3.GetSongs();

            Console.ReadKey();
        }

        /// <summary>
        /// Generates songs for testing.
        /// </summary>
        /// <param name="quantity">How many songs you want for testing.</param>
        /// <returns>Array with songs.</returns>
        static public Song[] GetTestSongs(int quantity)
        {
            Song[] test_song = new Song[quantity];
            for (int i = test_song.Length - 1; i >= 0; i--)
            {
                Song song = new Song(i, "Song " + i.ToString(), "Singer " + i.ToString(), (float)i);
                test_song[i] = song;
            }
            return test_song;
        }

        /// <summary>
        /// Get a playlist with random songs selected from an array of songs.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        static public PlayList RandomFillPlaylist(Song[] songs)
        {
            PlayList playList = new PlayList();

            foreach (Song song in songs)
            {
                Random r = new Random();
                bool b = r.NextDouble() >= 0.5 ? true : false;

                if (b)
                {
                    playList.AddSong(song);
                }
            }

            return playList;
        }
    }

    /// <summary>
    /// Abstract class song.
    /// </summary>
    public class Song
    {
        public int id { get; set; }
        public string singer { get; set; }
        public string name { get; set; }
        public float duration { get; set; }

        public Song(int id, string name, string singer, float duration)
        {
            this.id = id;
            this.singer = singer;
            this.name = name;
            this.duration = duration;
        }

        /// <summary>
        /// Get text song.
        /// </summary>
        /// <returns>String with song's details.</returns>
        public string getSong()
        {
            return string.Format("\nSong id: {0}\nSong name: {1} \nSinger: {2} \nDuration: {3}\nObject: {4}", this.id, this.name, this.singer, this.duration, this.GetHashCode());
        }
    }

    /// <summary>
    /// Class FlyWeigth for class Song.
    /// </summary>
    public class FlyWeightSong
    {
        private Song _sharedState;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="song">Song to create FlyWeight</param>
        public FlyWeightSong(Song song)
        {
            this._sharedState = song;
        }

        /// <summary>
        /// Print song details in console.
        /// </summary>
        public void GetSong()
        {
            Console.WriteLine(this._sharedState.getSong());
        }
    }

    /// <summary>
    /// FlyWeightSong factory.
    /// </summary>
    public class SongFactory
    {
        private List<Tuple<FlyWeightSong, string>> songs = new List<Tuple<FlyWeightSong, string>>();

        private static SongFactory songFactory_Singleton;

        /// <summary>
        /// Get SongFactory instance. Singleton.
        /// </summary>
        /// <returns>SongFactory singleton.</returns>
        public static SongFactory GetSongFactory()
        {
            if (songFactory_Singleton == null)
            {
                songFactory_Singleton = new SongFactory();
                songFactory_Singleton.PreloadedSongs();
            }

            return songFactory_Singleton;
        }

        /// <summary>
        /// Private construct.
        /// </summary>
        private SongFactory() { }

        /// <summary>
        /// Preload songs for FactorySong.
        /// </summary>
        private void PreloadedSongs()
        {
            Song[] preloaded_songs = new Song[13];
            for (int i = preloaded_songs.Length - 1; i >= 0; i--)
            {
                Song song = new Song(i, "Song " + i.ToString(), "Singer " + i.ToString(), (float)i);
                preloaded_songs[i] = song;
            }

            AddSong(preloaded_songs);
        }

        /// <summary>
        /// Add songs to FactorySong.
        /// </summary>
        /// <param name="args">Songs to add.</param>
        private void AddSong(params Song[] args)
        {
            foreach (var elem in args)
            {
                songs.Add(new Tuple<FlyWeightSong, string>(new FlyWeightSong(elem), this.getKey(elem)));
            }
        }

        /// <summary>
        /// Get key for song.
        /// </summary>
        /// <param name="key">Song to get key.</param>
        /// <returns>A key with song's values.</returns>
        private string getKey(Song key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.id.ToString());
            elements.Add(key.singer);
            elements.Add(key.name);
            elements.Add(key.duration.ToString());
            elements.Sort();

            return string.Join("_", elements);
        }

        /// <summary>
        /// Set or Get a song from or to FactorySong. And print the action to do.
        /// </summary>
        /// <param name="sharedState">Song to get or set.</param>
        /// <returns>Created or existing song.</returns>
        public FlyWeightSong GetFlyweight(Song sharedState)
        {
            string key = this.getKey(sharedState);

            if (songs.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("SongFactory: Can't find a flyweight, creating new one.");
                this.songs.Add(new Tuple<FlyWeightSong, string>(new FlyWeightSong(sharedState), key));
            }
            else
            {
                Console.WriteLine("SongFactory: Reusing existing song.");
            }
            return this.songs.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }
    }

    /// <summary>
    /// Abstract Playlist.
    /// </summary>
    public class PlayList
    {
        List<FlyWeightSong> songs = new List<FlyWeightSong>();
        SongFactory SongFactory = SongFactory.GetSongFactory();

        /// <summary>
        /// Add song to playlist.
        /// </summary>
        /// <param name="song">Song to add.</param>
        public void AddSong(Song song)
        {
            this.songs.Add(SongFactory.GetFlyweight(song));
        }

        /// <summary>
        /// Get songs. Print in console songs'details.
        /// </summary>
        public void GetSongs()
        {
            foreach (FlyWeightSong song in songs)
            {
                song.GetSong();
            }
        }
    }
}
