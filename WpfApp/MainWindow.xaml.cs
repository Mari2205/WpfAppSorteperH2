using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager game = new GameManager();
        public MainWindow()
        {
            InitializeComponent();

            #region Initialize img, lable, txtbox to hidden
            imageHumanPlayer.Visibility = Visibility.Hidden;
            imageBotPlayer.Visibility = Visibility.Hidden;
            imageTable.Visibility = Visibility.Hidden;
            imageWhiteBackground.Visibility = Visibility.Hidden;

            textboxPlayerChoseCard.Visibility = Visibility.Hidden;

            ButtonHumanPlayer.Visibility = Visibility.Hidden;
            ButtonBotPlayer.Visibility = Visibility.Hidden;

            listBotPlayer.Visibility = Visibility.Hidden;
            listHumanPlayer.Visibility = Visibility.Hidden;
            #endregion

            game.Lostgame += Game_Lostgame; // her laver jeg en subscription til Game_Lostgame
        }

        /// <summary>
        /// her er der metoden til et event som subsscried til main
        /// metoden laver en messagebox og udskriver lost the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Lostgame(object sender, EventArgs e)
        {
            Debug.WriteLine("Game.lostGame");
            MessageBox.Show("lost the game");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.Visibility = Visibility.Hidden;

            #region Initialize img, lable, txtbox to Visible
            imageHumanPlayer.Visibility = Visibility.Visible;
            imageBotPlayer.Visibility = Visibility.Visible;
            imageTable.Visibility = Visibility.Visible;
            imageWhiteBackground.Visibility = Visibility.Visible;

            textboxPlayerChoseCard.Visibility = Visibility.Visible;

            ButtonHumanPlayer.Visibility = Visibility.Visible;
            ButtonBotPlayer.Visibility = Visibility.Visible;

            listBotPlayer.Visibility = Visibility.Visible;
            listHumanPlayer.Visibility = Visibility.Visible;
            #endregion

            // her shuffler og uddeler jeg kortene
            game.Start();

            // sætter mine listwiew til mine to hænder
            listHumanPlayer.ItemsSource = game.players[0].hand;
            listBotPlayer.ItemsSource = game.players[1].hand;
            //

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game.UpdatePlayerList += Game_UpdatePlayerList; // her laver jeg en subscription til Game_UpdatePlayerList
            game.DrawCardFromPlayer(Convert.ToInt32(textboxPlayerChoseCard.Text), 0, 1);
            game.CheckForePair(0);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            game.UpdatePlayerList += Game_UpdatePlayerList; // her laver jeg en subscription til Game_UpdatePlayerList
            game.DrawCardFromPlayer(Convert.ToInt32(textboxPlayerChoseCard.Text), 1, 0);
            game.CheckForePair(1);

        }

        /// <summary>
        /// her er der metoden til et event som subsscried til to knapper 
        /// metoden gør at de listwiew hendet igen og refechet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_UpdatePlayerList(object sender, EventArgs e)
        {
            Debug.WriteLine("Game.listUpdate");
            listHumanPlayer.ItemsSource = game.players[0].hand;
            listBotPlayer.ItemsSource = game.players[1].hand;
            listHumanPlayer.Items.Refresh();
            listBotPlayer.Items.Refresh();
        }


        private void TextboxPlayerChoseCard_GotFocus(object sender, RoutedEventArgs e)
        {
            textboxPlayerChoseCard.Text = "";
        }
    }
}
