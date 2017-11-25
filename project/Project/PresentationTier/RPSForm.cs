using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PresentationTier.GameServiceReference;
using System.ServiceModel;
using System.Timers;
using System.ComponentModel;

namespace PresentationTier

{
    public partial class RPSForm : Form, IGameServiceCallback
    {
        private InstanceContext instanceContext;
        private IGameService gameService;
        private int playerId;
        private int gameId, choice;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private volatile bool requestStop = false;

        public RPSForm(int chatId, int playerId)
        {
            #region Initialize
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            gameService = new GameServiceClient(instanceContext);
            player2_lbl.Text = "PLAYER2 NOT CONNECTED!";
            player2_lbl.ForeColor = Color.Red;
            selectChoice_btn.Enabled = false;
            #endregion

            gameId = chatId;
            this.playerId = playerId;

            gameService.JoinGame(gameId, playerId); //player joins game

            #region Choice
            choice = -1;
            rockChoice_rb.Checked = false;
            paperChoice_rb.Checked = false;
            scissorChoice_rb.Checked = false;
            #endregion
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

        public void PlayerJoins(int id, string name)
        {
            if(id == playerId)
            {
                player1_lbl.Text = name;
            }
            else
            {
                player2_lbl.Text = name;
                player2_lbl.ForeColor = Color.Black;
                selectChoice_btn.Enabled = true;
            }
        }

        public void PlayerLeaves()
        {
            player2_lbl.ForeColor = Color.Red;
            player2_lbl.Text = "PLAYER 2 DISCONECTED!";
            selectChoice_btn.Enabled = false;
        }

        public void Result(int result)
        {
            player1_lbl.ForeColor = Color.Black;
            player2_lbl.ForeColor = Color.Black;

            string historyChoice;
            switch (result)
            {
                case -2: //player2 did not make a choice
                    Stop();
                    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
                    timer.Interval = 1000;
                    timer.AutoReset = false;
                    timer.SynchronizingObject = (this);
                    Start();

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.DeepPink;
                    anouncer_lbl.Text = "PALYER2 DID NOT CHOOSE YET!!!";
                    break;
                case -1: //player1 did not make a choice
                    Stop();
                    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    timer.Interval = 1000;
                    timer.AutoReset = false;
                    timer.SynchronizingObject = (this);
                    Start();

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.DeepPink;
                    anouncer_lbl.Text = "MAKE A CHOICE, FAST!!!";
                    break;
                case 0: //tie
                    Stop();
                    player1_lbl.ForeColor = Color.Yellow;
                    player2_lbl.ForeColor = Color.Yellow;

                    player2_pic.BackgroundImage = player1_pic.BackgroundImage;

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Yellow;
                    anouncer_lbl.Text = "TIE!!!";
                    switch (choice)
                    {
                        case 0:
                            historyChoice = "ROCK";
                            break;
                        case 1:
                            historyChoice = "PAPER";
                            break;
                        default:
                            historyChoice = "SCISSORS";
                            break;
                    }
                    history_listBox.Items.Add("TIE!!! - on " + historyChoice);
                    break;
                case 1: //player1 wins
                    if (choice == 0)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                        historyChoice = " YOU WIN WITH: ROCK on SCISSORS";
                    }
                    else
                        if (choice == 1)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.rock;
                        historyChoice = " YOU WIN WITH: PAPER on ROCK";
                    }
                    else
                    {
                        player2_pic.BackgroundImage = Properties.Resources.paper;
                        historyChoice = " YOU WIN WITH: SCISSORS on PAPER";
                    }

                    Stop();
                    player1_lbl.ForeColor = Color.Green;
                    palyer1Points_lbl.Text = (Int32.Parse(palyer1Points_lbl.Text) + 1).ToString();
                    player1_bar.Value = 0;
                    player2_bar.Value = 0;
                    
                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Green;
                    anouncer_lbl.Text = "YOU WIN!!!!";
                    history_listBox.Items.Add("YOU WIN!!!!");
                    break;
                default: //payer2 wins
                    if (choice == 0)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.paper;
                        historyChoice = " YOU LOSE WITH: ROCK on PAPER";
                    }
                    else
                        if (choice == 1)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                        historyChoice = " YOU LOSE WITH: PAPER on SCISSORS";
                    }
                    else
                    {
                        player2_pic.BackgroundImage = Properties.Resources.rock;
                        historyChoice = " YOU LOSE WITH: SCISSORS on ROCK";
                    }

                    Stop();
                    player2_lbl.ForeColor = Color.Green;
                    player2Points_lbl.Text = (Int32.Parse(player2Points_lbl.Text) + 1).ToString();
                    player1_bar.Value = 0;
                    player2_bar.Value = 0;

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Red;
                    anouncer_lbl.Text = "YOU LOSE!!!";
                    history_listBox.Items.Add("YOU LOSE!!!!");
                    break;
            }
        }

        private void SelectChoice_btn_Click(object sender, EventArgs e)
        {
            if (choice != -1)
            {
                gameService.MakeChoice(gameId, playerId, choice);
                
                rockChoice_rb.Checked = false;
                paperChoice_rb.Checked = false;
                scissorChoice_rb.Checked = false;
            }
            choice = -1;
        }

        private void RockRB_CheckedChanged(object sender, EventArgs e)
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

        private void NewGame_btn_Click(object sender, EventArgs e)
        {
            RPSForm rPSForm = new RPSForm(gameId, playerId);
            Close();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e) //plaeer1 timer
        {
            player1_lbl.ForeColor = Color.DeepPink;
            if (player1_bar.Value >= 100) //if time ran out
            {
                player1_bar.Value = 0; //reset timer to 0
                gameService.MakeChoice(gameId, playerId, new Random().Next(0, 2)); //randomly choose for player
                Stop();
            }
            else
            {
                player1_bar.Increment(10);
            }
            if (!requestStop)
            {
               Start();//restart the timer
            }
        }

        private void OnTimedEvent1(object source, ElapsedEventArgs e) //player2 timer
        {
            player2_lbl.ForeColor = Color.DeepPink;
            if (player2_bar.Value >= 100) //if time ran out
            {
                player2_bar.Value = 0; //reset timer to 0
                gameService.MakeChoice(gameId, playerId, new Random().Next(0, 2)); //randomly choose for player
                Stop();
            }
            else
            {
                player2_bar.Increment(10);
            }
            if (!requestStop)
            {
                Start();//restart the timer
            }
        }

        private void Stop()
        {
            player1_bar.Value = 0; //reset timer to 0
            player2_bar.Value = 0; //reset timer to 0
            timer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
            timer.Elapsed -= new ElapsedEventHandler(OnTimedEvent1);
            requestStop = true;
            timer.Stop();
        }

        private void Start()
        {
            requestStop = false;
            timer.Start();
        }

        private void RPSForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            gameService.LeaveGame(gameId, playerId);
        }
    }
}
