using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scalable.Win.DataBinding
{
    public class ControlTag
    {
        //TODO: interpreting Tag property
        // TAG: 
        // 1. single word w/o spaces = datamemeber name e.g. FirstName
        //    in this case the control's "Text" property would be used for binding
        // 2. two words separated by colon: 
        //      datamemeber name:control property name to binded to e.g. BrithDate:Value
        // 3. ?...display member and value member for dropdowns and listboxes etc. all ListControl

        private string _tag;

        public ControlTag(string tag)
        {
            _tag = tag;
            processTagInfo();
        }

        public string DataMember { get; set; }
        public string ControlMember { get; set; }

        public override string ToString()
        {
            return string.Format("DataMember:{0}, ControlMember:{1}", DataMember, ControlMember);
        }

        private void processTagInfo()
        {
            var info = _tag.ToString().Split(':');

            DataMember = info[0];
            ControlMember = "Text";

            if (info.Length > 1)
                ControlMember = info[1];
        }
    }
}
