﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnForms.Models
{
    public class NowPlayingMovies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public DateTime PlayingDate { get; set; }
        public DateTime ShowTime1 { get; set; }
        public DateTime ShowTime2 { get; set; }
        public DateTime ShowTime3 { get; set; }
        public string TicketPrice { get; set; }
        public double Rating { get; set; }
        public string RatedLevel { get; set; }
        public string Genre { get; set; }
        public string TrailorLink { get; set; }
        public string Logo { get; set; }
        public object LogoFile { get; set; }
       
        public string CoverImage
        {
            get
            {
                //return String.Format("http://colosseum.somee.com/{0}", Logo.Substring(1));
                return Logo;
            }
            
        }

    }
}
