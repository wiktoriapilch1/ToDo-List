using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ToDo_List {
    public partial class MainWindow : Window {

        private ObservableCollection<string> tasks = new ObservableCollection<string>();
        private ObservableCollection<string> completedTasks = new ObservableCollection<string>();

        public MainWindow() {
            InitializeComponent();
            KeyDown += MainWindow_KeyDown;
            listOfTasks.ItemsSource = tasks;
            listOfCompletedTasks.ItemsSource = completedTasks;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            if(e.Key == Key.Escape) {
                Close();
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e) {
            string nTask = newTask.Text;
            tasks.Add(nTask);
            newTask.Clear();
            completedTask.IsEnabled = true;
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e) {
            int selectedIndex = listOfTasks.SelectedIndex;
            if (selectedIndex != -1) {
                tasks.RemoveAt(selectedIndex);
            }
        }

        private void Completed_Click(object sender, RoutedEventArgs e) {
            int selectedIndex = listOfTasks.SelectedIndex;
            if (selectedIndex != -1) {
                string completed = tasks[selectedIndex];
                completedTasks.Add(completed);
                tasks.RemoveAt(selectedIndex);
            }
        }

        private void TaskSelected(object sender, RoutedEventArgs e) {
            int selectedIndex = listOfTasks.SelectedIndex;
            if (selectedIndex != -1) {
                completedTask.IsEnabled = true;
            }
        }
    }
}
