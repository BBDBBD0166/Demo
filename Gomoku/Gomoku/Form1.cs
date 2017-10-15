﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Gomoku : Form
    {
        private Board board = new Board();

        private bool isBlack = true;

        public Gomoku()
        {
            InitializeComponent();
        }

        private void Gomoku_MouseDown(object sender, MouseEventArgs e)
        {
            if(isBlack)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                isBlack = false;
            }else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                isBlack = true;
            }

        }

        private void Gomoku_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
