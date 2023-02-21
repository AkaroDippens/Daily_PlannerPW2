using System;
using System.Windows;
using System.Windows.Controls;

namespace DailyPlanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static List list;
        public static DateTime selectedDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            list = new List(selectedDate);
            UpdateList();
            Data.SelectedDate = selectedDate;
        }
        public void UpdateList()
        {
            selectedDate = list.VibData;
            Listik.Items.Clear();
            list.UpNotes();
            foreach (Note note in list.Note)
            {
                Listik.Items.Add(note.Nazvaniye);
            }
            Nazvaniye.Text = "";
            Opisaniye.Text = "";
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            list.DeleteNote(ID_HEAD: list.VibID);
            UpdateList();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string nazvaniye = Nazvaniye.Text;
            string opisaniye = Opisaniye.Text;
            list.NewNote(nazvaniye, opisaniye, selectedDate);
            UpdateList();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string nazvniye_ = Nazvaniye.Text;
            string opisaniye_ = Opisaniye.Text;
            UpdateList();
        }
        private void Listik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listik.SelectedIndex != -1)
            {
                list.VibID = Listik.SelectedIndex;
                Note selectedNote = list.Note[list.VibID];
                Nazvaniye.Text = selectedNote.Nazvaniye;
                Opisaniye.Text = selectedNote.Opisaniye;
            }
        }
    }
}
