using System;
using System.Text;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;
using System.Drawing;

namespace Synergy.Domain.Model
{
    public class TaskComment
    {
        public TaskCommentEntity Entity { get; private set; }
        public Task Task { get; set; }
        public UserEntity User { get; set; }

        public TaskComment(TaskCommentEntity entity)
        {
            Entity = entity;
        }

        public void Save(bool skipSendMessage = false)
        {
            Entity.CommentedOn = DateTime.Now;
            var repo = new TaskRepository();
            repo.SaveTaskComment(Entity);

            if (!skipSendMessage)
                TaskMessage.SendCommentAddedOnTaskMessage(this);
        }

        public override string ToString()
        {
            return string.Format("[{0}]-[{1}]: {2}\n", User.Name, Entity.CommentedOn, Entity.Comment);
        }

        //public string ToStringRtf()
        //{
        //    var header = string.Format("[{0}]: [{1}]: \n", User.Name, Entity.CommentedOn);
        //    var rtb = new RichTextBox();
        //    rtb.Rtf = Entity.Comment;
        //    rtb.SelectionStart = 0;
        //    rtb.ScrollToCaret();
        //    rtb.SelectedText = string.Format(header);
        //    rtb.SelectionColor = Color.Brown;
        //    return rtb.Rtf;
        //}
    }
}
