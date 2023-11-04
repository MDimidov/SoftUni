namespace MusicHub;

using System;
using System.Globalization;
using System.Text;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        //2.	All Albums Produced by Given Producer
        //string albumsInfo = ExportAlbumsInfo(context, 9);
        //Console.WriteLine(albumsInfo);

        //3.	Songs Above Given Duration
        string songsInfo = ExportSongsAboveDuration(context, 4);
        Console.WriteLine(songsInfo);
    }
    //2.	All Albums Produced by Given Producer
    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        StringBuilder sb = new StringBuilder();

        var albums = context.Albums
            .Where(a => a.ProducerId.HasValue &&
                        a.ProducerId == producerId)
            //.AsNoTracking()
            .ToArray()
            .OrderByDescending(a => a.Price)
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                Songs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            Price = $"{s.Price:f2}",
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                AlbumPrice = $"{a.Price:f2}"
            });

        foreach (var a in albums)
        {
            sb
                .AppendLine($"-AlbumName: {a.Name}")
                .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                .AppendLine($"-ProducerName: {a.ProducerName}")
                .AppendLine("-Songs:");

            int songNumber = 1;
            foreach (var s in a.Songs)
            {
                sb
                    .AppendLine($"---#{songNumber++}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Price: {s.Price}")
                    .AppendLine($"---Writer: {s.WriterName}");
            }

            sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
        }

        return sb.ToString().TrimEnd();
    }

    //3.	Songs Above Given Duration
    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        StringBuilder sb = new StringBuilder();

        var songs = context.Songs
            .ToArray()
            .Where(s => s.Duration.TotalSeconds > duration)
            .Select(s => new
            {
                s.Name,
                Performer = s.SongPerformers
                    .Select(sp => new
                    {
                        FullName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                    })
                    .OrderBy(p => p.FullName)
                    .ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album.Producer.Name,
                Duration = s.Duration.ToString("c")
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName);
            //.ToArray();

        int songNumber = 1;
        foreach (var s in songs)
        {
            sb
                .AppendLine($"-Song #{songNumber++}")
                .AppendLine($"---SongName: {s.Name}")
                .AppendLine($"---Writer: {s.WriterName}");

            foreach(var p in s.Performer)
            {
                sb.AppendLine($"---Performer: {p.FullName}");
            }

            sb
                .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                .AppendLine($"---Duration: {s.Duration}");
        }

        return sb.ToString().TrimEnd();
    }
}
