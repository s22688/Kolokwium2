﻿namespace Kol2.Models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }

        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
