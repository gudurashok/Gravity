﻿using System;

namespace Foresight.Logic.Report
{
    public class NewLostPartyValue
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public decimal Amount { get; set; }
        public int TransCount { get; set; }
    }
}
