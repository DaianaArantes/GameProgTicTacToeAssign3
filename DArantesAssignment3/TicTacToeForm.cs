using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DArantesAssignment3
{
    /// <summary>
    /// Class that designs the TicTacToeForm
    /// </summary>
    public partial class TicTacToeForm : Form
    {
        /// <summary>
        /// The defaut constructor of the class.
        /// </summary>
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        // Declaration
        private const String EMPTY = "EMPTY";
        PictureBox[,] gridArray = new PictureBox[3, 3];
        bool xTurn = true;

        // Declaration for position of the grid on the form
        private const int LEFT = 80;
        private const int WIDTH = 100;
        private const int HEIGHT = 100;
        private const int TOP = 120;
        private const int VGAP = 1;

        int x = LEFT;
        int y = TOP;

        /// <summary>
        /// Click event hander of the pictureBox_Click button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            // X turn 
            if (xTurn)
            {
                // Place image only if pictureBox is null
                if (pictureBox.Image == null)
                {
                    pictureBox.Image = DArantesAssignment3.Properties.Resources.X;
                    pictureBox.Name = "X";

                    // Check if game is ended
                    if (CheckMatch())
                    {
                        MessageBox.Show("X win", "Result");
                        // Clear and Print grid again so a new game can be played
                        ClearPrintGrid();

                    }
                    // Check if there is a Draw
                    else if (CheckDraw())
                    {
                        MessageBox.Show("Draw", "Result");
                        // Clear and Print grid again so a new game can be played
                        ClearPrintGrid();
                    }
                    // Game is not ended, revert turn 
                    else
                    {
                        
                        xTurn = false;
                    }
                }
            }
            // O turn
            else
            {
                // Place image only if pictureBox is null
                if (pictureBox.Image == null)
                {
                    pictureBox.Image = DArantesAssignment3.Properties.Resources.O;
                    pictureBox.Name = "O";
                    // Check if game is ended
                    if (CheckMatch())
                    {
                        MessageBox.Show("O win", "Result");
                        // Clear and Print grid again so a new game can be played
                        ClearPrintGrid();  
                    }
                    // Check if there is a Draw
                    else if (CheckDraw())
                    {
                        MessageBox.Show("Draw", "Result");
                        // Clear and Print grid again so a new game can be played
                        ClearPrintGrid();
                    }
                    // Game is not ended, revert turn 
                    else
                    {
                        
                        xTurn = true;
                    }   
                }
            }
        }
        /// <summary>
        /// Load event hander of the TicTacToeForm_Load 
        /// When form loads, prints grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            ClearPrintGrid();
        }

        /// <summary>
        /// Clar grid first, then print grid on form
        /// </summary>
        public void ClearPrintGrid()
        {
            // call clear grid first
            ClearGrid();

            x = LEFT;
            y = TOP;
            // Print picture boxes on form with declared positions
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Left = x;
                    pictureBox.Width = WIDTH;
                    pictureBox.Height = HEIGHT;
                    pictureBox.Top = y;
                    pictureBox.BorderStyle = BorderStyle.Fixed3D;
                    pictureBox.Name = "EMPTY";
                    pictureBox.Click += pictureBox_Click;

                    // array receives picture box
                    gridArray[i, j] = pictureBox;

                    // add picture box to form
                    this.Controls.Add(pictureBox);

                    x += VGAP + WIDTH;
                }

                x = LEFT;
                y += VGAP + HEIGHT;
            }
        }
        /// <summary>
        /// Removes gridArray from the form 
        /// </summary>
        public void ClearGrid()
        {
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {
                    this.Controls.Remove(gridArray[i, j]);
                }
            }
            // Set X to true, so when starts again X will be placed first
            xTurn = true;
        }
        /// <summary>
        /// Check if there is a X or O in a row 3 times, so there is Match
        /// </summary>
        /// <returns></returns>
        public bool CheckMatch()
        {
            bool isMatch = false;

            if (gridArray[0, 0].Name == gridArray[0, 1].Name && gridArray[0, 1].Name == gridArray[0, 2].Name)
            {
                if (gridArray[0, 0].Name != "EMPTY" && gridArray[0, 1].Name != "EMPTY" && gridArray[0, 2].Name != "EMPTY")
                {
                    isMatch = true;

                }
            }

            else if (gridArray[1, 0].Name == gridArray[1, 1].Name && gridArray[1, 1].Name == gridArray[1, 2].Name)
            {
                if (gridArray[1, 0].Name != "EMPTY" && gridArray[1, 1].Name != "EMPTY" && gridArray[1, 2].Name != "EMPTY")
                {
                    isMatch = true;
                }   
            }

            else if (gridArray[2, 0].Name == gridArray[2, 1].Name && gridArray[2, 1].Name == gridArray[2, 2].Name)
            {
                if (gridArray[2, 0].Name != "EMPTY" && gridArray[2, 1].Name != "EMPTY" && gridArray[2, 2].Name != "EMPTY")
                {
                    isMatch = true;
                }
            }

            else if (gridArray[0, 0].Name == gridArray[1, 0].Name && gridArray[1, 0].Name == gridArray[2, 0].Name)
            {
                if (gridArray[0, 0].Name != "EMPTY" && gridArray[1, 0].Name != "EMPTY" && gridArray[2, 0].Name != "EMPTY")
                {
                    isMatch = true;
                }  
            }

            else if (gridArray[0, 1].Name == gridArray[1, 1].Name && gridArray[1, 1].Name == gridArray[2, 1].Name)
            {
                if (gridArray[0, 1].Name != "EMPTY" && gridArray[1, 1].Name != "EMPTY" && gridArray[2, 1].Name != "EMPTY")
                {
                    isMatch = true;
                }  
            }

            else if (gridArray[0, 2].Name == gridArray[1, 2].Name && gridArray[1, 2].Name == gridArray[2, 2].Name)
            {
                if (gridArray[0, 2].Name != "EMPTY" && gridArray[1, 2].Name != "EMPTY" && gridArray[2, 2].Name != "EMPTY")
                {
                    isMatch = true;
                }  
            }

            else if (gridArray[0, 0].Name == gridArray[1, 1].Name && gridArray[1, 1].Name == gridArray[2, 2].Name)
            {
                if (gridArray[0, 0].Name != "EMPTY" && gridArray[1, 1].Name != "EMPTY" && gridArray[2, 2].Name != "EMPTY")
                {
                    isMatch = true;
                }
            }

            else if (gridArray[0, 2].Name == gridArray[1, 1].Name && gridArray[1, 1].Name == gridArray[2, 0].Name)
            {
                if (gridArray[0, 2].Name != "EMPTY" && gridArray[1, 1].Name != "EMPTY" && gridArray[2, 0].Name != "EMPTY")
                {
                    isMatch = true;
                }
            }

            
            return isMatch;
        }

        /// <summary>
        /// Check if all picturebox are filled, and there is no winner
        /// </summary>
        /// <returns></returns>
        public bool CheckDraw()
        {
           
            for (int i = 0; i < gridArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridArray.GetLength(1); j++)
                {
                    if (gridArray[i,j].Image == null)
                    {
                        return false;

                    }
                }
            }
            return true;
        }
    }
}
