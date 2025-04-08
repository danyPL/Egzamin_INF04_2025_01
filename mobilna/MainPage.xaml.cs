namespace INF_04_2025_01_Mobile
{
    public class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
        public string Time { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        List<Song> Songs = new List<Song>();
        Song CurrentSong;
        int currentIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            LoadMauiAsset();
        }

        public void Next(object sender, EventArgs e)
        {
            if (Songs.Count == 0) return;

            currentIndex++;
            if(currentIndex >= Songs.Count)
            {
                currentIndex = 0;
            }
            CurrentSong = Songs[currentIndex];
            UpdateUI();
        }

        public void Back(object sender, EventArgs e)
        {
            if (Songs.Count == 0) return;

            currentIndex--;
            if(currentIndex < 0)
            {
                currentIndex=Songs.Count -1;
            }
            CurrentSong = Songs[currentIndex];
            UpdateUI();
        }

        void UpdateUI()
        {
            Author.Text = CurrentSong.Author;
            Title.Text = CurrentSong.Title;
            Image.Source = CurrentSong.Path;
            EndTime.Text = CurrentSong.Time;
        }

        async Task LoadMauiAsset()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("music.txt");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                var lines = contents.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 4)
                    {
                        Songs.Add(new Song
                        {
                            Author = parts[0],
                            Title = parts[1],
                            Time = parts[2],
                            Path = parts[3]
                        });
                    }
                }

                if (Songs.Count > 0)
                {
                    CurrentSong = Songs[0];
                    UpdateUI();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Błąd nie załadowano piosenek: {ex.Message}", "OK");
            }
        }
    }
}
