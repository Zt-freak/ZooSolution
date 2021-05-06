using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Zoo.Models;

namespace ZooApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Animal> animalList = new List<Animal>();
        public DispatcherTimer LifeTimer { get; set; }
        public MainWindow()
        {
            LifeTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            LifeTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            LifeTimer.Start();

            InitializeComponent();

            SpeciesBox.Items.Add("Elephant");
            SpeciesBox.Items.Add("Lion");
            SpeciesBox.Items.Add("Monkey");
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < animalList.Count; i++)
            {
                animalList[i].UseEnergy();
                if (!CheckIfAnimalLives(animalList[i]))
                {
                    animalList.RemoveAt(i);
                }
            }
            UpdateAnimalListBox();
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            switch (SpeciesBox.SelectedItem)
            {
                case "Elephant":
                    animalList.Add(new Elephant(AnimalNameBox.Text));
                    break;
                case "Lion":
                    animalList.Add(new Lion(AnimalNameBox.Text));
                    break;
                case "Monkey":
                    animalList.Add(new Monkey(AnimalNameBox.Text));
                    break;
                default:
                    throw new ArgumentException("Species cannot be empty owo");
            }
            Animal newAnimal = animalList[animalList.Count - 1];
            AnimalListBox.Items.Add($"{newAnimal.GetType().Name} {newAnimal.Name} {newAnimal.Energy}");
        }

        private void FeedAnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            IEnumerable<Animal> tempAnimalList;
            switch (senderButton.Content)
            {
                case "Elephants":
                    tempAnimalList = animalList.OfType<Elephant>();
                    break;
                case "Lions":
                    tempAnimalList = animalList.OfType<Lion>();
                    break;
                case "Monkeys":
                    tempAnimalList = animalList.OfType<Monkey>();
                    break;
                case "All":
                default:
                    tempAnimalList = animalList.OfType<Animal>();
                    break;
            }


            foreach (Animal animal in tempAnimalList)
            {
                animal.Eat();
            }

            UpdateAnimalListBox();
        }

        private void UpdateAnimalListBox ()
        {
            AnimalListBox.Items.Clear();
            foreach (Animal animal in animalList)
            {
                AnimalListBox.Items.Add(($"{animal.GetType().Name} {animal.Name} {animal.Energy}"));
            }
        }

        private bool CheckIfAnimalLives (Animal animal)
        {
            if (animal.Energy >= 0)
            {
                return true;
            }
            return false;
        }

        private void ChangeTimerButton_Click(object sender, RoutedEventArgs e)
        {
            Double result;
            if (!Double.TryParse(ChangeTimerBox.Text, out result))
            {
                result = 500;
            }
            LifeTimer.Interval = TimeSpan.FromMilliseconds(result);
        }

        private void StartStopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            switch (StartStopTimerButton.Content)
            {
                case "Start":
                    LifeTimer.Start();
                    StartStopTimerButton.Content = "Stop";
                    break;
                case "Stop":
                default:
                    LifeTimer.Stop();
                    StartStopTimerButton.Content = "Start";
                    break;
            }
        }
    }
}
