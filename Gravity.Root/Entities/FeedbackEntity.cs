using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class FeedbackEntity
    {
        public string Id { get; set; }
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserNameCannotBeEmpty")]
        public string Subject { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
}
