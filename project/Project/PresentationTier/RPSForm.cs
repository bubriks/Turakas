using System;
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
        private int gameId, prevChoice, choice;
        private System.Timers.Timer timer;
        private volatile bool requestStop = false;

        public RPSForm(int chatId, int playerId)
        {
            #region Initialize
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            gameService = new GameServiceClient(instanceContext);
            //Formating player2 label
            player2_lbl.Text = "PLAYER2 NOT CONNECTED!";
            player2_lbl.ForeColor = Color.Red;
            //Making the button unclicable
            selectChoice_btn.Enabled = false;
            
            //diselecting any choice
            choice = -1;
            prevChoice = -1;
            rockChoice_rb.Checked = false;
            paperChoice_rb.Checked = false;
            scissorChoice_rb.Checked = false;

            //initialise timer
            timer = new System.Timers.Timer();
            timer.Interval = 1000; //make timer perform action after 1 second
            timer.AutoReset = false; //make sure timer wont reset
            timer.SynchronizingObject = (this); //syncronize timer thread with RPSForm thread, in order to allow timer thread to modify RPSForm elements
            #endregion

            gameId = chatId; //since chatId is unique, gameId will be unique
            this.playerId = playerId;

            gameService.JoinGame(gameId, playerId); //player joins game

            
        }


        /// <summary>
        /// Sends player's choice to service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectChoice_btn_Click(object sender, EventArgs e)
        {
            if (choice != -1) //if player made a choice
            {
                gameService.MakeChoice(gameId, playerId, choice); //send choice

                //diselect all choice to prevent missunderstandings
                rockChoice_rb.Checked = false;
                paperChoice_rb.Checked = false;
                scissorChoice_rb.Checked = false;
                prevChoice = choice;
            }
            choice = -1; //reset choice
        }

        /// <summary>
        /// Selects player's choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RockRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;//initialize which button is selected

            if (rb == rockChoice_rb) 
            {
                player1_pic.BackgroundImage = Properties.Resources.rock;
                choice = 0;
            }
            else if (rb == paperChoice_rb) 
            {
                player1_pic.BackgroundImage = Properties.Resources.paper;
                choice = 1;
            }
            else 
            {
                player1_pic.BackgroundImage = Properties.Resources.scissor;
                choice = 2;
            }

        }

        /// <summary>
        /// Creates new game with the inside player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame_btn_Click(object sender, EventArgs e)
        {
            RPSForm rPSForm = new RPSForm(gameId, playerId);
            Close();
        }

        /// <summary>
        /// Callback methode, makes form show or close
        /// </summary>
        /// <param name="result"></param>
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

        /// <summary>
        /// Callback methode, notifies RPSForm that a player has joined the game
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void PlayerJoins(int id, string name)
        {
            //in the UI level, the player that opens the Form is allways player1
            if(id == playerId) //so if the player that joined is the player that had opened the Form
            {
                player1_lbl.Text = name; //displaying his nickname as player1
            }
            else
            {
                //display his name as player2 and format the player2 label
                player2_lbl.Text = name;
                player2_lbl.ForeColor = Color.Black;
                selectChoice_btn.Enabled = true;
            }
        }

        /// <summary>
        /// Callback methode, notifies RPSForm that a player has left the game
        /// </summary>
        public void PlayerLeaves()
        {
            Stop();
            //format player2 label
            player2_lbl.ForeColor = Color.Red;
            player2_lbl.Text = "PLAYER 2 DISCONECTED!";
            selectChoice_btn.Enabled = false;
        }

        /// <summary>
        /// Callback methode, notifies RPSForm of the result of the player's choice
        /// </summary>
        /// <param name="result"></param>
        public void Result(int result)
        {
            //reseting player labels's format
            player1_lbl.ForeColor = Color.Black;
            player2_lbl.ForeColor = Color.Black;

            string historyChoice; //string for the history listbox
            switch (result) //depending on the response from service
            {
                case -2: //player2 did not make a choice
                    Stop(); //stop previouse timer
                    timer.Elapsed += new ElapsedEventHandler(Player2Timer); //add event to timer
                    Start(); //start timer

                    //format anouncer label so that the player will know what is happeneing
                    anouncer_lbl.ForeColor = Color.DeepPink;
                    anouncer_lbl.Text = "PALYER2 DID NOT CHOOSE YET!!!";
                    break;
                case -1: //player1 did not make a choice
                    Stop();
                    timer.Elapsed += new ElapsedEventHandler(Player1Timer);
                    Start();

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.DeepPink;
                    anouncer_lbl.Text = "MAKE A CHOICE, FAST!!!";
                    break;
                case 0: //tie
                    Stop();
                    player1_lbl.ForeColor = Color.Blue;
                    player2_lbl.ForeColor = Color.Blue;

                    //since its a tie, we know player2 chose the same thing as player1
                    player2_pic.BackgroundImage = player1_pic.BackgroundImage; //format player2 choice image

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Blue;
                    anouncer_lbl.Text = "TIE!!!";
                    switch (prevChoice) //format string depeding on what player1 chose, for the history box
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
                    history_listBox.Items.Add("TIE!!! - on " + historyChoice); //add string to list box
                    break;
                case 1: //player1 wins
                    //format player2 choice depeding on player1's choice
                    if (prevChoice == 0)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                        historyChoice = " YOU WIN WITH: ROCK on SCISSORS";
                    }
                    else
                        if (prevChoice == 1)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.rock;
                        historyChoice = " YOU WIN WITH: PAPER on ROCK";
                    }
                    else
                    {
                        player2_pic.BackgroundImage = Properties.Resources.paper;
                        historyChoice = " YOU WIN WITH: SCISSORS on PAPER";
                    }

                    Stop(); //make sure timer has stopped
                    //format labels to accomodate player1's win
                    player1_lbl.ForeColor = Color.Green;
                    palyer1Points_lbl.Text = (Int32.Parse(palyer1Points_lbl.Text) + 1).ToString(); //add points
                    player1_bar.Value = 0;
                    player2_bar.Value = 0;
                    
                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Green;
                    anouncer_lbl.Text = "YOU WIN!!!!";
                    history_listBox.Items.Add(historyChoice);
                    break;
                default: //payer2 wins
                    if (prevChoice == 0)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.paper;
                        historyChoice = " YOU LOSE WITH: ROCK on PAPER";
                    }
                    else
                        if (prevChoice == 1)
                    {
                        player2_pic.BackgroundImage = Properties.Resources.scissor;
                        historyChoice = " YOU LOSE WITH: PAPER on SCISSORS";
                    }
                    else
                    {
                        player2_pic.BackgroundImage = Properties.Resources.rock;
                        historyChoice = " YOU LOSE WITH: SCISSORS on ROCK";
                    }

                    Stop(); //make sure timer has stopped
                    //format labels to acomodate for player2's win
                    player2_lbl.ForeColor = Color.Green;
                    player2Points_lbl.Text = (Int32.Parse(player2Points_lbl.Text) + 1).ToString(); //add points to palyer2
                    player1_bar.Value = 0;
                    player2_bar.Value = 0;

                    anouncer_lbl.Visible = true;
                    anouncer_lbl.ForeColor = Color.Red;
                    anouncer_lbl.Text = "YOU LOSE!!!";
                    history_listBox.Items.Add(historyChoice);
                    break;
            }
        }
        
        /// <summary>
        /// Timer event for player1 timer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Player1Timer(object source, ElapsedEventArgs e)
        {
            player1_lbl.ForeColor = Color.DeepPink;
            if (player1_bar.Value >= 100) //if time ran out (10 seconds have passed)
            {
                Stop();
                player1_bar.Value = 0; //reset timer to 0
                gameService.MakeChoice(gameId, playerId, new Random().Next(0, 2)); //randomly choose for player
            }
            else
            {
                player1_bar.Increment(10); //add 1 sec to timer
            }
            if (!requestStop)
            {
               Start();//restart the timer
            }
        }

        /// <summary>
        /// Timer event for player2 timer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Player2Timer(object source, ElapsedEventArgs e) //player2 timer
        {
            player2_lbl.ForeColor = Color.DeepPink;
            if (player2_bar.Value >= 100) //if time ran out (10 seconds)
            {
                Stop();
                player2_bar.Value = 0; //reset timer to 0
            }
            else
            {
                player2_bar.Increment(10); //add 1 second to timer
            }
            if (!requestStop)
            {
                Start();//restart the timer
            }
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        private void Stop()
        { 
            //reset timer to 0
            player1_bar.Value = 0;
            player2_bar.Value = 0;
            //remove timer events
            timer.Elapsed -= new ElapsedEventHandler(Player1Timer);
            timer.Elapsed -= new ElapsedEventHandler(Player2Timer);
            requestStop = true; //make sure timer will stop
            timer.Stop(); //stop timer
        }

        /// <summary>
        /// Start timer
        /// </summary>
        private void Start()
        {
            requestStop = false;
            timer.Start();
        }

        /// <summary>
        /// On close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPSForm_Closing(object sender, CancelEventArgs e)
        {
            gameService.LeaveGame(gameId, playerId); //disconnect player from game
        }
    }
}
