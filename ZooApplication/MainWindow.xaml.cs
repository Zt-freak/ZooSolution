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

namespace ZooApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Animal> animalList = new List<Animal>();
        public MainWindow()
        {
            InitializeComponent();

            SpeciesBox.Items.Add("Elephant");
            SpeciesBox.Items.Add("Lion");
            SpeciesBox.Items.Add("Monkey");
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
    }
}
