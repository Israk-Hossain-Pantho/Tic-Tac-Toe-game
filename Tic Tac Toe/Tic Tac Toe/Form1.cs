using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int AIWinCount = 0;
        List<Button> buttons;


        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void PlayerClickBotton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.LawnGreen;
            buttons.Remove(button);
            CheckGame();
            GameTimer.Start();

        }

        private void AIMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                Button selectedButton = null;

                // Check if AI can win in the next move
                foreach (Button button in buttons)
                {
                    button.Text = "O";
                    if (CheckWin("O"))
                    {
                        selectedButton = button;
                        break;
                    }
                    button.Text = "?";
                }
                // If AI can't win, check if it needs to block player's winning move
                if (selectedButton == null)
                {
                    foreach (Button button in buttons)
                    {
                        button.Text = "X";
                        if (CheckWin("X"))
                        {
                            selectedButton = button;
                            button.Text = "O"; // revert the change to the button's text property
                            break;
                        }
                        button.Text = "?";
                    }
                }
                // If AI can't win or block player's winning move, select a random button
                if (selectedButton == null)
                {
                    int index = random.Next(buttons.Count);
                    selectedButton = buttons[index];
                }

                // Update the selected button's properties and remove it from the available buttons list
                selectedButton.Enabled = false;
                selectedButton.Text = "O";
                selectedButton.BackColor = Color.OrangeRed;
                buttons.Remove(selectedButton);

                CheckGame();
                GameTimer.Stop();
            }
        }

        private bool CheckWin(string player)
        {
            // Check all possible winning combinations
            if ((button1.Text == player && button2.Text == player && button3.Text == player)
                || (button4.Text == player && button5.Text == player && button6.Text == player)
                || (button7.Text == player && button8.Text == player && button9.Text == player)
                || (button1.Text == player && button4.Text == player && button7.Text == player)
                || (button2.Text == player && button5.Text == player && button8.Text == player)
                || (button3.Text == player && button6.Text == player && button9.Text == player)
                || (button1.Text == player && button5.Text == player && button9.Text == player)
                || (button3.Text == player && button5.Text == player && button7.Text == player))
            {
                return true;
            }

            return false;
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
               )
            {
                GameTimer.Stop();
                MessageBox.Show("Excilent!!"  +"\n\n"+"You Win the Match ....");
                playerWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                label2.Text = "AI Wins: " + AIWinCount;
                RestartGame();

            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                  || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                  || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                  || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                  || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                  || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                  || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                  || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                GameTimer.Stop();
                MessageBox.Show("Sorry!!" + "\n" + "You lose the Match " + "\n\n" + "Better Luck Next Time....");
                AIWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                label2.Text = "AI Wins: " + AIWinCount;
                RestartGame();
            }
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "X/O";
                x.BackColor = DefaultBackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
