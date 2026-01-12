namespace SmartTask
{
    public partial class MainPage : ContentPage
    {
        public class TaskItem
        {
            public string Title { get; set; } = "";
            public string Description { get; set; } = "";
            public string Deadline { get; set; } = "";
            public int State { get; set; } = 0; 
        }
        private List<TaskItem> feladatok = new List<TaskItem>
        {
            new TaskItem { Title="Bevásárlás", Description="Tej, kenyér, tojás, zöldség, gyümölcs", Deadline="2026-01-11 18:00" },
            new TaskItem { Title="C# MAUI gyakorlás", Description="Töltsd fel a feladatlistát és próbáld ki a gombokat", Deadline="2026-01-12 12:00" },
            new TaskItem { Title="Futás", Description="5 km reggel, pulzusmérés", Deadline="2026-01-11 07:00" },
            new TaskItem { Title="Reggeli készítése", Description="Omlett és friss gyümölcslé", Deadline="2026-01-11 08:00" },
            new TaskItem { Title="Email-ek átnézése", Description="Fontos levelek és válaszok", Deadline="2026-01-11 09:30" },
            new TaskItem { Title="Projekt megbeszélés", Description="Teams hívás, jegyzetelés", Deadline="2026-01-11 10:30" },
            new TaskItem { Title="Házimunka", Description="Porszívózás, mosás, rendrakás", Deadline="2026-01-11 17:00" },
            new TaskItem { Title="Olvasás", Description="Könyv: „Clean Code” fejezet 3", Deadline="2026-01-11 20:00" },
            new TaskItem { Title="Meditáció", Description="10 perc légzőgyakorlat", Deadline="2026-01-11 21:00" },
            new TaskItem { Title="Alvás előkészítése", Description="Telefon kikapcsol, hálószoba sötétítés", Deadline="2026-01-11 22:30" }

        };

        public MainPage()
        {
            InitializeComponent(); 
            BuildTaskList();
        }

        private void BuildTaskList()
        {
            TaskStack.Children.Clear();

            TaskStack.Children.Add(new Label { Text = "SmartTasks", FontSize = 24, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center });

            foreach (var task in feladatok)
            {
                var frame = new Frame { Style = (Style)Resources["TaskCardStyle"] };
                var itemek = new VerticalStackLayout { Spacing = 8 };

                itemek.Children.Add(new Label { Text = task.Title, Style = (Style)Resources["TaskTitleStyle"] });
                itemek.Children.Add(new Label { Text = task.Description, Style = (Style)Resources["TaskDescStyle"] });
                itemek.Children.Add(new Label { Text = "Határidő: " +task.Deadline, Style = (Style)Resources["TaskDeadlStyle"] });

                var btn = new Button { Text = GetStateText(task.State), BackgroundColor = GetStateColor(task.State), Style = (Style)Resources["TaskButtonStyle"] };

                
                btn.Clicked += (s, e) =>
                {
                    task.State = (task.State + 1) % 3;
                    btn.Text = GetStateText(task.State);
                    btn.BackgroundColor = GetStateColor(task.State);
                };

                itemek.Children.Add(btn);
                frame.Content = itemek;
                TaskStack.Children.Add(frame);
            }
        }

        private string GetStateText(int state) => state switch
        {
            0 => "Kezdetben",
            1 => "Folyamatban",
            2 => "Kész",
            _ => ""
        };

        private Color GetStateColor(int state) => state switch
        {
            0 => Color.FromArgb("#9CA3AF"),
            1 => Color.FromArgb("#2563EB"),
            2 => Color.FromArgb("#16A34A"),
            _ => Colors.Gray
        };
    }
}
