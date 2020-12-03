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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        List<Card> cards = new List<Card>();
        CardService cservice = new CardService();
        UserCardService cardService = new UserCardService();
        public Topic topic;

        bool isFlipped = false;
        int current = 0;
        int userId;
        int cnt = 0;
        public CardWindow()
        {            
            InitializeComponent();

        }

        public CardWindow(Topic _topic, int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.topic = _topic;
            TopicLabel.Content = topic.Name;
            cards = cservice.GetCardsByTopic(topic.Id);

            cnt = cardService.getCountRightAnswers(cards, userId);
            current = cardService.getNext(cards, userId, current);
            progressBarLabel.Content = cnt.ToString() + "/" + cards.Count.ToString();
            cardCardNameLabel.Content = cards[current].Name;
            
            cardDefinition.Text = "?????????????";
            cardRightButton.Visibility = Visibility.Hidden;
            cardWrongButton.Visibility = Visibility.Hidden;
        }
        
        void flip_isClicked(object sender, RoutedEventArgs e)
        {
            cardFlipButton.Visibility = Visibility.Hidden;
            cardRightButton.Visibility = Visibility.Visible;
            cardWrongButton.Visibility = Visibility.Visible;
            if (!isFlipped)
            {
                cardDefinition.Text = cards[current].Description;
                isFlipped = true;
            }
        }

        private void cardRightButton_Click(object sender, RoutedEventArgs e)
        {
            cardService.addAnswer(userId, cards[current].Id, true);
            ++cnt;
            progressBarLabel.Content = cnt.ToString() + "/" + cards.Count.ToString();
            if (cnt == cards.Count)
            {
                MessageBox.Show("Good job!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                return;
            }
            current = cardService.getNext(cards, userId, current);
            isFlipped = false;
            cardFlipButton.Visibility = Visibility.Visible;
            cardRightButton.Visibility = Visibility.Hidden;
            cardWrongButton.Visibility = Visibility.Hidden;
            cardDefinition.Text = "?????????????";
            cardCardNameLabel.Content = cards[current].Name;
        }

        private void cardWrongButton_Click(object sender, RoutedEventArgs e)
        {
            cardService.addAnswer(userId, cards[current].Id, false);
            current = cardService.getNext(cards, userId, current);

            isFlipped = false;
            cardFlipButton.Visibility = Visibility.Visible;
            cardRightButton.Visibility = Visibility.Hidden;
            cardWrongButton.Visibility = Visibility.Hidden;
            cardDefinition.Text = "?????????????";
            cardCardNameLabel.Content = cards[current].Name;
        }

        private void cardExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
