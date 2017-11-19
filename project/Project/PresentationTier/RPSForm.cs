using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PresentationTier

{

    public partial class RPSForm : Form
    {
        private List<string> list = new List<string>();
        private int player1Id, player2Id;
        
        public RPSForm(int player1Id, int player2Id)
        {
            InitializeComponent();
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
    }
}
