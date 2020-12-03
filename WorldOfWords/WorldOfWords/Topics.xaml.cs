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
        int userId;
        public Topics(int id)
        {
            InitializeComponent();
            userId = id;
            TopicService topicService = new TopicService();
            TopicsListBox.ItemsSource = topicService.GetAllTopics();
            TopicsListBox.SelectionChanged += selectionHandler;
        }

        void selectionHandler(object sender, SelectionChangedEventArgs args)
        {
            Topic topic = args.AddedItems[0] as Topic;
            UserCardService userCardService = new UserCardService();
            CardService cardService = new CardService();
            var cards = cardService.GetCardsByTopic(topic.Id);
            int cnt = userCardService.getCountRightAnswers(cards, userId);
            if (cnt == cards.Count)
            {
                MessageBox.Show("Нема шо вчити!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            CardWindow cardWindow = new CardWindow(topic, userId);
            cardWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cardWindow.ShowDialog();
        }
    }
}
