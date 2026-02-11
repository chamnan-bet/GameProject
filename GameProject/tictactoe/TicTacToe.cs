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
    public partial class TicTacToe : Form
    {
        private Button[,] gridButtons;
        private const int gridSize = 6; 
        private bool isXTurn = true;
        private IPlayer botPlayer;
        private Timer aiTimer;

        public TicTacToe()
        {
            InitializeComponent();
            SetComboBoxOptions();
            GenerateGrid(); 
            botPlayer = new BotPlayer();
        }

        // ================= GRID =================
        private void GenerateGrid()
        {
            panelGrid.Controls.Clear();
            gridButtons = new Button[gridSize, gridSize];

            int spacing = 5;
            int buttonWidth = (panelGrid.Width - (gridSize + 1) * spacing) / gridSize;
            int buttonHeight = (panelGrid.Height - (gridSize + 1) * spacing) / gridSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(
                            spacing + col * (buttonWidth + spacing),
                            spacing + row * (buttonHeight + spacing)
                        ),
                        Font = new Font("Arial", buttonHeight / 2, FontStyle.Bold),
                        Name = $"btn_{row}_{col}",
                        BackColor = SystemColors.Control
                    };

                    btn.Click += Cell_Click;
                    panelGrid.Controls.Add(btn);
                    gridButtons[row, col] = btn;
                }
            }
        }

        // ================= BUTTON CLICK =================
        private void Cell_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!string.IsNullOrEmpty(btn.Text)) return; // Already clicked

            btn.Text = isXTurn ? "X" : "O";
            btn.BackColor = isXTurn ? Color.LightBlue : Color.IndianRed;

            isXTurn = !isXTurn;
            lblStatus.Text = "Turn: " + (isXTurn ? "X" : "O");

            CheckWinner();

            // AI turn if mode is "Play Bots"
            if (comboBoxOptions.SelectedIndex == 0 && !isXTurn)
            {
                if (aiTimer == null)
                {
                    aiTimer = new Timer();
                    aiTimer.Interval = 300;
                    aiTimer.Tick += AiTimer_Tick;
                }
                aiTimer.Start();
            }
        }

        // ================= AI TIMER =================
        private void AiTimer_Tick(object sender, EventArgs e)
        {
            aiTimer.Stop();
            botPlayer.MakeMove(gridButtons, gridSize);
            isXTurn = true;
            lblStatus.Text = "Turn: X";
            CheckWinner();
        }

        // ================= GAME LOGIC =================
        private void CheckWinner()
        {
            if (GameRules.CheckWinner(gridButtons, gridSize, out string winner))
            {
                MessageBox.Show($"The winner is: {winner}");
                ResetGame();
                return;
            }

            if (GameRules.IsDraw(gridButtons, gridSize))
            {
                MessageBox.Show("Draw! Play Again!");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            foreach (Button btn in gridButtons)
            {
                btn.Text = "";
                btn.BackColor = SystemColors.Control;
            }

            isXTurn = true;
            lblStatus.Text = "Turn: X";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        // ================= COMBO BOX =================
        private void SetComboBoxOptions()
        {
            comboBoxOptions.Items.Add("Play Bots");
            comboBoxOptions.Items.Add("Play a Friend");
            comboBoxOptions.SelectedIndex = 0;
        }

        private void labelOption_Click(object sender, EventArgs e) { }
        private void panelGrid_Paint(object sender, PaintEventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
        private void labelGrid_Click(object sender, EventArgs e) { }
    }

    // ================= INTERFACE =================
    interface IPlayer
    {
        void MakeMove(Button[,] grid, int size);
    }

    // ================= ABSTRACT PLAYER =================
    abstract class PlayerBase : IPlayer
    {
        public abstract void MakeMove(Button[,] grid, int size);
    }

    // ================= AI BOT =================
    class BotPlayer : PlayerBase
    {
        private Random rand = new Random();

        public override void MakeMove(Button[,] grid, int size)
        {
            List<Button> emptyButtons = new List<Button>();

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (string.IsNullOrEmpty(grid[r, c].Text))
                        emptyButtons.Add(grid[r, c]);
                }
            }

            if (emptyButtons.Count == 0) return;

            Button btn = emptyButtons[rand.Next(emptyButtons.Count)];
            btn.Text = "O";
            btn.BackColor = Color.MediumPurple;
        }
    }

    // ================= GAME RULES =================
    static class GameRules
    {
        private const int WinCount = 5; // NEW: number in a row to win

        public static bool CheckWinner(Button[,] grid, int size, out string winner)
        {
            winner = null;

            // Check rows
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c <= size - WinCount; c++)
                {
                    string first = grid[r, c].Text;
                    if (string.IsNullOrEmpty(first)) continue;

                    bool win = true;
                    for (int k = 1; k < WinCount; k++)
                    {
                        if (grid[r, c + k].Text != first)
                        {
                            win = false;
                            break;
                        }
                    }

                    if (win)
                    {
                        winner = first;
                        return true;
                    }
                }
            }

            // Check columns
            for (int c = 0; c < size; c++)
            {
                for (int r = 0; r <= size - WinCount; r++)
                {
                    string first = grid[r, c].Text;
                    if (string.IsNullOrEmpty(first)) continue;

                    bool win = true;
                    for (int k = 1; k < WinCount; k++)
                    {
                        if (grid[r + k, c].Text != first)
                        {
                            win = false;
                            break;
                        }
                    }

                    if (win)
                    {
                        winner = first;
                        return true;
                    }
                }
            }

            // Check diagonals (top-left to bottom-right)
            for (int r = 0; r <= size - WinCount; r++)
            {
                for (int c = 0; c <= size - WinCount; c++)
                {
                    string first = grid[r, c].Text;
                    if (string.IsNullOrEmpty(first)) continue;

                    bool win = true;
                    for (int k = 1; k < WinCount; k++)
                    {
                        if (grid[r + k, c + k].Text != first)
                        {
                            win = false;
                            break;
                        }
                    }

                    if (win)
                    {
                        winner = first;
                        return true;
                    }
                }
            }

            // Check diagonals (top-right to bottom-left)
            for (int r = 0; r <= size - WinCount; r++)
            {
                for (int c = WinCount - 1; c < size; c++)
                {
                    string first = grid[r, c].Text;
                    if (string.IsNullOrEmpty(first)) continue;

                    bool win = true;
                    for (int k = 1; k < WinCount; k++)
                    {
                        if (grid[r + k, c - k].Text != first)
                        {
                            win = false;
                            break;
                        }
                    }

                    if (win)
                    {
                        winner = first;
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsDraw(Button[,] grid, int size)
        {
            foreach (Button b in grid)
                if (string.IsNullOrEmpty(b.Text))
                    return false;
            return true;
        }
    }

}
