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
        public Topic topic;

        bool isFliped = false;
        public CardWindow()
        {            
            InitializeComponent();
        }

        public CardWindow(Topic _topic)
        {
            InitializeComponent();
            this.topic = _topic;
            TopicLabel.Content = topic.Name;
            CardService cservice = new CardService();
            cards = cservice.GetCardsByTopic(topic.Id);

            var rnd = new Random();

            cardDefinition.Text = cards[0].Description;
        }

        

        void flip_isClicked(object sender, RoutedEventArgs e)
        {
            //if (isFliped)
            //{ 
            //    cardDefinition.Text = topic.Des
            //}
        }
    }
}
