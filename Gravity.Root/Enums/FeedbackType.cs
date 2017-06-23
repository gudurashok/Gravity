using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Gravity.Root.Enums
{
    public enum FeedbackType
    {
        [Description("(Bug)")]
        Bug,
        [Description("Feature Rquest")]
        FeatureRquest,
        [Description("Impediment")]
        Impediment
    }
}
