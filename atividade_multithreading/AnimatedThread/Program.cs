using AnimatedThread.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimatedThread
{
    class Program
    {
        static Dictionary<string, string> frameSprites = new Dictionary<string, string>();
        static IDatabase _database;
        static public Database data = new Database();
        static IDatabase Database
        {
            get
            {
                if (_database == null)
                    _database = new Database();

                return _database;
            }
        }
        static async Task Main(string[] args)
        {
            Database data = new Database();
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            int counter;
            var peopleOutpout = new List<Output>();
            bool TaskSendoExecutada = false;

            while (peopleOutpout.Count < 88)
            {
                counter = 0;

                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(0, 0);

                    DrawLoopMainThread(i, counter);

                    await Task.Delay(200);

                    counter++;
                }

                Console.WriteLine("-- INICIANDO PROCESSAMENTO --");

                if (!TaskSendoExecutada)
                {
                    Task task = new Task(() => peopleOutpout = processPerson(peopleOutpout).Result);
                    task.Start();
                    TaskSendoExecutada = true;
                }
            }

            TransformarJson(peopleOutpout);

            Console.WriteLine("---- FINALIZADO ---");
            Console.ReadLine();
        }

        static async Task<List<Output>> processPerson(List<Output> peopleOutpout)
        {
            // variáveis necessárias para a criação do objeto putput
            string personName;
            int personAge;
            int idPessoa;
            string favoriteSong = "";
            string favoriteSongArtist = "";
            int favoriteSongYear = 0;
            List<ArtistSongs> artistSongs = new List<ArtistSongs>();
            // variáveis auxiliares 
            int favoriteSongArtistId = 0;
            int[] otherSongsID;
            List<string> otherSongs = new List<string>();
            List<Song> musicasDosArtistas = new List<Song>();
            List<Song> OutrasMusicas = new List<Song>();

            // Recebe os dados do DataBase
            List<Person> List_Pessoas = data.GetPeople().ToList();
            List<Artist> List_Artistas = data.GetArtists().ToList();
            List<Song> List_Musicas = data.GetSongs().ToList();

            foreach (Person pessoa in List_Pessoas)
            {
                // define o nome, idade e id
                personName = pessoa.Name;
                personAge = pessoa.Age;
                idPessoa = pessoa.Id;

                // recebe os dados PersonSong
                PersonSong PessoaMusica = data.GetPersonSongsAsync(idPessoa).Result;

                int favoriteSongid = PessoaMusica.FavoriteSongId;
                otherSongsID = PessoaMusica.SongsIds;

                // Define a lista de othersongs
                for (int i = 0; i < otherSongsID.Length; i++)
                {
                    otherSongs.Add(List_Musicas.Find(n => n.Id == otherSongsID[i]).Name);
                    OutrasMusicas.Add(List_Musicas.Find(n => n.Id == otherSongsID[i]));
                }

                // Define a musica favorita e o seu ano
                Song music = List_Musicas.Find((musica) => musica.Id == favoriteSongid);
                favoriteSong = music.Name;
                favoriteSongYear = music.Year;
                favoriteSongArtistId = music.ArtistId;

                // Define o nome do cantor da musica favorita
                favoriteSongArtist = List_Artistas.Find((artista) => artista.Id == favoriteSongArtistId).Name;

                // Define os dados necessários para a lista das músicas dos artistas relacionados a pessoa
                // Musicas dos artistas = todas as músicas dos artistas de other songs e da música favorita
                Artist artist = new Artist(favoriteSongArtistId, favoriteSongArtist);
                musicasDosArtistas = List_Musicas.FindAll(n => n.ArtistId == favoriteSongArtistId);
                artistSongs.Add(new ArtistSongs(artist, musicasDosArtistas));
                musicasDosArtistas = new List<Song>(); // Reseta a lista

                for (int i = 0; i < OutrasMusicas.Count; i++)
                {
                    Song musica = OutrasMusicas[i];
                    artist = List_Artistas.Find(n => n.Id == musica.ArtistId);
                    musicasDosArtistas = List_Musicas.FindAll(n => n.ArtistId == musica.ArtistId);
                    artistSongs.Add(new ArtistSongs(artist, musicasDosArtistas));
                    musicasDosArtistas = new List<Song>(); // Reseta a lista
                }

                // Cria uma nova lista com os artitas relacionados a pessoa sem repetição
                List<ArtistSongs> listaArtistasong = artistSongs.Distinct(new ItemEqualityComparer()).ToList();

                // Cria objeto output e adiciona na lista
                Output saida = new Output(personName, personAge, favoriteSong, favoriteSongArtist, favoriteSongYear, otherSongs, listaArtistasong);
                peopleOutpout.Add(saida);
                // Reseta as listas
                OutrasMusicas = new List<Song>();
                otherSongs = new List<string>();
                artistSongs = new List<ArtistSongs>();
                listaArtistasong = new List<ArtistSongs>();
            }
            return peopleOutpout;
        }

        static void TransformarJson(List<Output> peopleOutpout)
        {
            var json = JsonConvert.SerializeObject(peopleOutpout, Formatting.Indented);
            Console.WriteLine(json);

            using (var streamWriter = new StreamWriter("Output.json"))
            {
                streamWriter.Write(json);
            }
        }


        static void DrawLoopMainThread(int i, int counter)
        {
            switch (counter % (i + 1))
            {
                case 0:
                    {
                        const string frameName = nameof(Animations.frame8);

                        Console.Write(GetFrameLines(frameName, Animations.frame8));

                        break;
                    };
                case 1:
                    {
                        const string frameName = nameof(Animations.frame7);

                        Console.Write(GetFrameLines(frameName, Animations.frame7));
                        break;
                    };
                case 2:
                    {
                        const string frameName = nameof(Animations.frame6);

                        Console.Write(GetFrameLines(frameName, Animations.frame6));
                        break;
                    };
                case 3:
                    {
                        const string frameName = nameof(Animations.frame5);

                        Console.Write(GetFrameLines(frameName, Animations.frame5));
                        break;
                    };
                case 4:
                    {
                        const string frameName = nameof(Animations.frame4);

                        Console.Write(GetFrameLines(frameName, Animations.frame4));
                        break;
                    };
                case 5:
                    {
                        const string frameName = nameof(Animations.frame3);

                        Console.Write(GetFrameLines(frameName, Animations.frame3));
                        break;
                    };
                case 6:
                    {
                        const string frameName = nameof(Animations.frame2);

                        Console.Write(GetFrameLines(frameName, Animations.frame2));
                        break;
                    };
                case 7:
                    {
                        const string frameName = nameof(Animations.frame1);

                        Console.Write(GetFrameLines(frameName, Animations.frame1));
                        break;
                    }
                case 8:
                    {
                        const string frameName = nameof(Animations.frame0);

                        Console.Write(GetFrameLines(frameName, Animations.frame0));
                        break;
                    }
            }

        }

        static string GetFrameLines(string frameName, string frame)
        {
            if (!frameSprites.ContainsKey(frameName))
            {
                var frameLines = frame.Split("<br>");
                var sb = new StringBuilder();
                foreach (var item in frameLines)
                {
                    sb.AppendLine(item);
                }
                frameSprites.Add(frameName, sb.ToString());
            }

            return frameSprites[frameName];
        }

        class ItemEqualityComparer : IEqualityComparer<ArtistSongs>
        {
            public bool Equals(ArtistSongs x, ArtistSongs y)
            {
                return x.Artist.Id == y.Artist.Id;
            }

            public int GetHashCode(ArtistSongs obj)
            {
                return obj.Artist.Id.GetHashCode();
            }
        }

    }
}