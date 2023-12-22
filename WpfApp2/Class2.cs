using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Catalog
    {
        private List<Track> allTracks;

        public List<Track> AllTracks
        {
            get { return allTracks; }
        }

        public Catalog()
        {
            allTracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            allTracks.Add(track);
        }

        public void RemoveTrack(Track track)
        {
            allTracks.Remove(track);
        }

        public void SearchTrack(Track track)
        {
            // Implement your search logic here
            // For simplicity, let's just print the track information
            Console.WriteLine($"Searching for track: {track.Title} - {track.Author}");
        }

        public List<Track> FilterTracks(string criteria, string searchString)
        {
            // Приводим к нижнему регистру для регистронезависимого поиска
            searchString = searchString.ToLower();

            switch (criteria)
            {
                case "Title":
                    return allTracks.Where(t => t.Title.ToLower().Contains(searchString)).ToList();
                case "Author":
                    return allTracks.Where(t => t.Author.ToLower().Contains(searchString)).ToList();
                default:
                    return new List<Track>();
            }
        }
    }
}
