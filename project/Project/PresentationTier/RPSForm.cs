using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PresentationTier.GameServiceReference;
using System.ServiceModel;
using PresentationTier.ProfileServiceReference;
using System.Timers;

namespace PresentationTier

{

    public partial class RPSForm : Form, IGameServiceCallback
    {
        private List<string> list = new List<string>();
        private InstanceContext instanceContext;
        private IGameService gameService;
        private IProfileService profileService = new ProfileServiceClient();
        private Profile player1, player2;
        private int gameId, choice = -1;

        public RPSForm(int chatId, int playerId)
        {
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            gameService = new GameServiceClient(instanceContext);
            
            player1 = profileService.ReadProfile(playerId.ToString(), 1);

            gameId = chatId;

            gameService.JoinGame(gameId, playerId); //player1 joins game

            player1_lbl.Text = player1.Nickname;
            player2_lbl.Text = "PLAYER 2 NOT YET CONNECTED!";

        }
        public void Show(bool result)
        {
            if (result)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        public void PlayerJoins(int playerId)
        {
            player2_lbl.ForeColor = Color.Black;
            player2 = profileService.ReadProfile(playerId.ToString(), 1);
            player2_lbl.Text = player2.Nickname;
        }

        public void PlayerLeaves(int profileId)
        {
            player2_lbl.ForeColor = Color.Red;
            player2_lbl.Text = "PLAYER 2 DISCONECTED!";
            player2 = null;
        }

        public void Result(int result)
        {
            switch (result)
            {
                case -2: //player2 did not make a choice
                    System.Timers.Timer aTimer1 = new System.Timers.Timer();
                    aTimer1.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
                    aTimer1.Interval = 1000;
                    aTimer1.Enabled = true;
                    break;
                case -1: //player1 did not make a choice
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 1;
                    aTimer.Enabled = true;
                    break;
                case 0: //tie
                    player1_lbl.ForeColor = Color.AliceBlue;
                    player2_lbl.ForeColor = Color.AliceBlue;

                    player1_pic.BackgroundImage = player2_pic.BackgroundImage;
                    break;
                case 1: //player1 wins
                    if (choice == 0)
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                    else
                        if(choice == 1)
                        player2_pic.BackgroundImage = Properties.Resources.rock;
                    else
                        player2_pic.BackgroundImage = Properties.Resources.paper;

                    player1_lbl.ForeColor = Color.Green;
                    palyer1Points_lbl.Text = (Int32.Parse(palyer1Points_lbl.Text) + 1).ToString();
                    break;
                default: //payer2 wins
                    if (choice == 0)
                        player2_pic.BackgroundImage = Properties.Resources.paper;
                    else
                        if (choice == 1)
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                    else
                        player2_pic.BackgroundImage = Properties.Resources.rock;

                    player2_lbl.ForeColor = Color.Green;
                    player2Points_lbl.Text = (Int32.Parse(player2Points_lbl.Text) + 1).ToString();
                    break;
            }
        }

        private void selectChoice_btn_Click(object sender, EventArgs e)
        {
            if(choice != -1)
                gameService.MakeChoice(gameId, player1.ProfileID, choice);

        }

        private void rockRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;//variabile

            if (rb == rockChoice_rb) //daca apas pe butonul repartizat pietrei
            {
                player1_pic.BackgroundImage = Properties.Resources.rock;//schimb imaginea reprezentativa din ce era in piatra
                choice = 0;
            }
            else if (rb == paperChoice_rb)  //daca apas pe butonul repartizat hartiei
            {
                player1_pic.BackgroundImage = Properties.Resources.paper;//schimb imaginea reprezentativa din ce era in hartie
                choice = 1;
            }
            else //altfel daca apas pe foarfece
            {
                player1_pic.BackgroundImage = Properties.Resources.scissor; //schimb imaginea reprezentativa din ce era in foarfece
                choice = 2;
            }

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e) //plaeer1 timer
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            player1_lbl.ForeColor = Color.Yellow;
            if (player1_bar.Value >= 100) //if time ran out
            {
                player1_bar.Value = 0; //reset timer to 0
                gameService.MakeChoice(gameId, player1.ProfileID, new Random().Next(0, 2)); //randomly choose for player
            }
            else
            {
                player1_bar.Increment(10);
            }
        }
        private void OnTimedEvent1(object source, ElapsedEventArgs e) //player2 timer
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            player2_lbl.ForeColor = Color.Yellow;
            if (player2_bar.Value >= 100) //if time ran out
            {
                player2_bar.Value = 0; //reset timer to 0
                gameService.MakeChoice(gameId, player2.ProfileID, new Random().Next(0, 2)); //randomly choose for player
            }
            else
            {
                player2_bar.Increment(10);
            }
        }
    }
}
