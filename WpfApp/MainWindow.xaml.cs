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
            imageDeadPlayerCount.Visibility = Visibility.Hidden;
            imagePlayer1.Visibility = Visibility.Hidden;
            imagePlayer2.Visibility = Visibility.Hidden;
            imagePlayer3.Visibility = Visibility.Hidden;
            imagePlayer4.Visibility = Visibility.Hidden;
            imagePlayer5.Visibility = Visibility.Hidden;
            imagePlayer6.Visibility = Visibility.Hidden;
            imageTable.Visibility = Visibility.Hidden;
            imageWhiteBackground.Visibility = Visibility.Hidden;

            labelChoseCard.Visibility = Visibility.Hidden;
            LabelChoseCardWhichPlayer.Visibility = Visibility.Hidden;
            lablePlayer1.Visibility = Visibility.Hidden;
            lablePlayer2.Visibility = Visibility.Hidden;
            lablePlayer3.Visibility = Visibility.Hidden;
            lablePlayer4.Visibility = Visibility.Hidden;
            lablePlayer5.Visibility = Visibility.Hidden;
            lablePlayer6.Visibility = Visibility.Hidden;

            textboxDeadPlayerCount.Visibility = Visibility.Hidden;
            textboxPlayerChoseCard.Visibility = Visibility.Hidden;
            #endregion

            buttonUsrChose.Visibility = Visibility.Hidden;
            ButtonP1.Visibility = Visibility.Hidden;
            ButtonP2.Visibility = Visibility.Hidden;

            game.Lostgame += Game_Lostgame;


        }

        private void Game_Lostgame(object sender, EventArgs e)
        {
            Debug.WriteLine("er i game lostGame");
            MessageBox.Show("lost the game");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.Visibility = Visibility.Hidden;

            #region Initialize img, lable, txtbox to Visible
            //imageDeadPlayerCount.Visibility = Visibility.Visible;
            imagePlayer1.Visibility = Visibility.Visible;
            //imagePlayer2.Visibility = Visibility.Visible;
            //imagePlayer3.Visibility = Visibility.Visible;
            //imagePlayer4.Visibility = Visibility.Visible;
            imagePlayer5.Visibility = Visibility.Visible;
            //imagePlayer6.Visibility = Visibility.Visible;
            imageTable.Visibility = Visibility.Visible;
            imageWhiteBackground.Visibility = Visibility.Visible;

            labelChoseCard.Visibility = Visibility.Visible;
            LabelChoseCardWhichPlayer.Visibility = Visibility.Visible;
            //lablePlayer1.Visibility = Visibility.Visible;
            //lablePlayer2.Visibility = Visibility.Visible;
            //lablePlayer3.Visibility = Visibility.Visible;
            //lablePlayer4.Visibility = Visibility.Visible;
            //lablePlayer5.Visibility = Visibility.Visible;
            //lablePlayer6.Visibility = Visibility.Visible;

            //textboxDeadPlayerCount.Visibility = Visibility.Visible;
            textboxPlayerChoseCard.Visibility = Visibility.Visible;
            #endregion

            ButtonP1.Visibility = Visibility.Visible;
            ButtonP2.Visibility = Visibility.Visible;

            // her shuffler og uddeler jeg kortene
            game.Start();

            listP1.ItemsSource = game.players[0].hand;
            listP2.ItemsSource = game.players[1].hand;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game.UpdatePlayerList += Game_UpdatePlayerList;
            game.DrawCardP1(Convert.ToInt32(textboxPlayerChoseCard.Text));
            game.CheckForePair(0);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            game.UpdatePlayerList += Game_UpdatePlayerList;
            game.DrawCardP2(Convert.ToInt32(textboxPlayerChoseCard.Text));
            game.CheckForePair(1);

        }

        private void Game_UpdatePlayerList(object sender, EventArgs e)
        {
            Debug.WriteLine("er i game list update");
            listP1.ItemsSource = game.players[0].hand;
            listP2.ItemsSource = game.players[1].hand;
            listP1.Items.Refresh();
            listP2.Items.Refresh();
        }


        private void TextboxPlayerChoseCard_GotFocus(object sender, RoutedEventArgs e)
        {
            textboxPlayerChoseCard.Text = "";
        }
    }
}
