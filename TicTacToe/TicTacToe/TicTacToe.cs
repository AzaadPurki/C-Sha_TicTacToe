using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        /*
         * This Game Is Developed By Mohsin Ali Purki
         * GitHub --> github.com/AzaadPurki
         * LinkedIn --> www.linkedin.com/in/mohsin-ali-58a313163
         * 
         * For Any Other Queries And Help Contact : azaadpurki@gmail.com
         *  
         *    ___________       _____           _____     ___________       _____       _____    __________________
         *  ____        ___     _____           _____   ____        ___     _____       _____    __________________
         *  ____        ___     _____           _____   ____        ___     _____   _____               _____       
         *  ____       ___      _____           _____   ____       ___      _________                   _____      
         *  ____     ___        _____           _____   ____     ___        _________                   _____
         *  _____ ___           _____           ____    _____ ___           _____   _____               _____
         *  ____                  _____       _____     ____     ___        _____       ______   __________________
         *  ____                      ______            ____        ___     _____       ______   __________________
         *  
         *  
         */
        public bool IsPlayerOneTurn { get; private set; }
        public int ButtonClickCount { get; private set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

        public string PlayerOneMark { get; set; }
        public string PlayerTwoMark { get; set; }

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By Mohsin Ali Purki\nStudent Of Barani Institute of Management Sciences!", "About This game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            EnableButtons(false);
            restartGameToolStripMenuItem.Enabled = false;
            ButtonClickCount = 0;
        }

        private void EnableButtons(bool Value)
        {
            TLButton.Enabled = Value;
            TMButton.Enabled = Value;
            TRButton.Enabled = Value;
            MLButton.Enabled = Value;
            MMButton.Enabled = Value;
            MRButton.Enabled = Value;
            BLButton.Enabled = Value;
            BMButton.Enabled = Value;
            BRButton.Enabled = Value;
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableButtons(true);
            newGameToolStripMenuItem.Enabled = false;
            restartGameToolStripMenuItem.Enabled = true;
            EnablePlayerOptions(false);
            PlayerOptionPanel.Visible = false;
            GetPlayersName();
            SelectPlayerToStart();
            SelectMarkForPlayer();

        }

        private void GetPlayersName()
        {
            PlayerOneName = PlayerOneTextBox.Text;
            PlayerTwoName = PlayerTwoTextBox.Text;
        }

        private void SelectMarkForPlayer()
        {
            if (SelectXForPlayerOneRadioButton.Checked)
            {
                PlayerOneMark = "X";
                PlayerTwoMark = "O";
            }
            else
            {
                PlayerOneMark = "O";
                PlayerTwoMark = "X";
            }
        }

        private void SelectPlayerToStart()
        {
            if (SelectPlayerTwoRadioButton.Checked)
            {
                IsPlayerOneTurn = false;
            }
            else
            {
                IsPlayerOneTurn = true;
            }
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void RestartGame()
        {
            EnableButtons(false);
            newGameToolStripMenuItem.Enabled = true;
            restartGameToolStripMenuItem.Enabled = false;
            EnablePlayerOptions(true);
            PlayerOptionPanel.Visible = true ;
            ClearButtons();
            ButtonClickCount = 0;
        }

        private void ClearButtons()
        {
            TLButton.Text = "";
            TLButton.BackColor = System.Drawing.Color.White;

            TMButton.Text = "";
            TMButton.BackColor = System.Drawing.Color.White;

            TRButton.Text = "";
            TRButton.BackColor = System.Drawing.Color.White;

            MLButton.Text = "";
            MLButton.BackColor = System.Drawing.Color.White;

            MMButton.Text = "";
            MMButton.BackColor = System.Drawing.Color.White;

            MRButton.Text = "";
            MRButton.BackColor = System.Drawing.Color.White;

            BLButton.Text = "";
            BLButton.BackColor = System.Drawing.Color.White;

            BMButton.Text = "";
            BMButton.BackColor = System.Drawing.Color.White;

            BRButton.Text = "";
            BRButton.BackColor = System.Drawing.Color.White;
        }

        private void EnablePlayerOptions(bool Value)
        {
            PlayerNameGroupBox.Enabled = Value;
            StartingPlayerGroupBox.Enabled = Value;
            PlayerMarkerGroupBox.Enabled = Value;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (IsPlayerOneTurn)
            {
                //b.Text = "X";
                b.Text = PlayerOneMark;
                IsPlayerOneTurn = false;
                b.Enabled = false;
                b.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                //b.Text = "O";
                b.Text = PlayerTwoMark;
                IsPlayerOneTurn = true;
                b.Enabled = false;
                b.BackColor = System.Drawing.Color.Green;
            }
            ButtonClickCount++;

            CheckWinner();
        }

        private void CheckWinner()
        {
            bool winner = false;
           
           //ROW
           if((TLButton.Text == TMButton.Text) && (TMButton.Text == TRButton.Text) && (TLButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }
            if ((MLButton.Text == MMButton.Text) && (MMButton.Text == MRButton.Text) && (MLButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }
            if ((BLButton.Text == BMButton.Text) && (BMButton.Text == BRButton.Text) && (BLButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }

            //COL 
            if ((TLButton.Text == MLButton.Text) && (MLButton.Text == BLButton.Text) && (TLButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }
            if ((TMButton.Text == MMButton.Text) && (MMButton.Text == BMButton.Text) && (TMButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }
            if ((TRButton.Text == MRButton.Text) && (MRButton.Text == BRButton.Text) && (TRButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }

            //DIAGNOL
            if ((TRButton.Text == MMButton.Text) && (MMButton.Text == BLButton.Text) && (TRButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }
            if ((TLButton.Text == MMButton.Text) && (MMButton.Text == BRButton.Text) && (TLButton.Text != ""))
            {
                winner = true;
               // MessageBox.Show("Winner");
            }

            if(winner == true)
            {
                if (IsPlayerOneTurn)
                {
                    MessageBox.Show(""+ PlayerTwoName+" WINS", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(""+ PlayerOneName+" WINS", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }                
                RestartGame();
            }
            else if (ButtonClickCount == 9)
            {
                MessageBox.Show("Game Draw.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RestartGame();
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            newGameToolStripMenuItem_Click(sender, e);
        }

        private void RestartGameButton_Click(object sender, EventArgs e)
        {
            restartGameToolStripMenuItem_Click(sender,e);
        }
    }
}
