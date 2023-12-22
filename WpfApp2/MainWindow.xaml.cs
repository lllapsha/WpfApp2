using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Catalog catalog;

        public MainWindow()
        {
            InitializeComponent();
            catalog = new Catalog();
            trackListView.ItemsSource = catalog.AllTracks;
        }

        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            // Add a new track to the catalog
            var track = ReadTrack();
            catalog.AddTrack(track);

            // Refresh the tracks in the list view
            RefreshTracks();
        }

        private void RefreshTracks()
        {
            trackListView.Items.Refresh();
        }

        private void ShowAllTracks_Click(object sender, RoutedEventArgs e)
        {
            trackListView.ItemsSource = catalog.AllTracks;
        }

        //private void AddTrack_Click(object sender, RoutedEventArgs e)
        //{
        //    var track = ReadTrack();
        //    catalog.AddTrack(track);
        //    trackListView.ItemsSource = catalog.AllTracks;
        //}

        private void RemoveTrack_Click(object sender, RoutedEventArgs e)
        {
            var track = trackListView.SelectedItem as Track;
            if (track != null)
            {
                catalog.RemoveTrack(track);
                trackListView.ItemsSource = catalog.AllTracks;
            }
        }

        private void SearchTrack_Click(object sender, RoutedEventArgs e)
        {
            var track = ReadTrack();
            catalog.SearchTrack(track);
            trackListView.ItemsSource = new List<Track> { track };
        }

        private void FilterTracks_Click(object sender, RoutedEventArgs e)
        {
            // Filter tracks based on the selected criteria and search string
            string filterCriteria = (filterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string searchString = filterTextBox.Text;

            List<Track> filteredTracks = catalog.FilterTracks(filterCriteria, searchString);
            // Update the list view with filtered tracks
            trackListView.ItemsSource = filteredTracks;
        }

        private Track ReadTrack()
        {
            // Read track information from user input
            string songName = Interaction.InputBox("Введите название трека:", "Название", "");
            string authorName = Interaction.InputBox("Введите автора трека:", "Автор", "");

            return new Track(songName, authorName);
        }
    }
}