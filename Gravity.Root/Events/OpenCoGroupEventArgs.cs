using System;
using Gravity.Root.Model;

namespace Gravity.Root.Events
{
    public class CoGroupSelectedEventArgs : EventArgs
    {
        public CompanyGroup CompanyGroup { get; private set; }
    
        public CoGroupSelectedEventArgs(CompanyGroup companyGroup)
        {
            CompanyGroup = companyGroup;
        }
    }
}
