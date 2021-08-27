﻿using System;

namespace C21_Ex02_01.Com.Team.Database.Players.Player
{
    public abstract class Player
    {
        protected Player(eID i_ID, char i_Char)
        {
            Char = i_Char;
            ID = i_ID;
        }

        public eID ID { get; } // Unique

        public char Char { get; }

        public byte ChosenColumnIndex { get; set; } = 0;

        public byte Score { get; set; } = 0;

        public event EventHandler ScoreModify;

        public abstract void PlayTurn();

        public override string ToString()
        {
            return
                $"{nameof(ID)}: {ID}, {nameof(Char)}: {Char}, {nameof(Score)}: {Score}";
        }

        protected virtual void OnScoreModify()
        {
            ScoreModify?.Invoke(this, EventArgs.Empty);
        }

        public void ScoreModified()
        {
            OnScoreModify();
        }
    }
}
