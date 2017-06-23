using System;
using Gravity.Root.Model;

namespace Gravity.Root.Events
{
    public class CoGroupSavedEventArgs : EventArgs
    {
        public CompanyGroup CompanyGroup { get; private set; }

        public CoGroupSavedEventArgs(CompanyGroup companyGroup)
        {
            CompanyGroup = companyGroup;
        }
    }
}
