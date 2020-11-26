using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorldOfWords
{
    /// <summary>
    /// Interaction logic for Topics.xaml
    /// </summary>
    public partial class Topics : Window
    {
        public Topics()
        {
            InitializeComponent();
            TopicService topicService = new TopicService();
            TopicsListBox.ItemsSource = topicService.GetAllTopics();
            TopicsListBox.SelectionChanged += selectionHandler;
        }

        void selectionHandler(object sender, SelectionChangedEventArgs args)
        {
            Topic topic = args.AddedItems[0] as Topic;
            this.Close();
            CardWindow cardWindow = new CardWindow(topic);           
            cardWindow.Show();
        }
    }
}
