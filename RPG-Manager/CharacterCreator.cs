﻿using RPG_Manager.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Manager
{
    public partial class CharacterCreator : Form
    {
        public delegate void CompletionEventHandler(object sender, CompletionEventArgs e);

        public event CompletionEventHandler CompletionEvent;

        protected void OnCompletionEvent()
        {
            CompletionEvent?.Invoke(this, new CompletionEventArgs(new Character(
                characterNameText.Text,
                characterRaceText.Text,
                (int)hpNumeric.Value,
                (int)acNumeric.Value)));
        }


        public CharacterCreator()
        {
            InitializeComponent();
        }

        public CharacterCreator(Character player)
        {
            InitializeComponent();

            // initializes the entry boxes to the previous values
            characterNameText.Text = player.Name;
            characterRaceText.Text = player.Race;
            hpNumeric.Value = player.Hp;
            acNumeric.Value = player.AC;

            // invalidates all of the controls
            characterNameText.Invalidate();
            characterRaceText.Invalidate();
            hpNumeric.Invalidate();
            acNumeric.Invalidate();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            OnCompletionEvent();
            Dispose();
        }

        private void hpNumeric_ValueChanged(object sender, EventArgs e)
        {
            hpNumeric.Value = Math.Round(hpNumeric.Value);
        }

        private void acNumeric_ValueChanged(object sender, EventArgs e)
        {
            acNumeric.Value = Math.Round(acNumeric.Value);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
