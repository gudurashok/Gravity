using System.Collections.Generic;
using System.Data.SqlClient;
using Scalable.Shared.Common;
using Gravity.Root.Common;

namespace Synergy.UC.Common
{
    public class SmsServer
    {
        private const string commandText = "INSERT INTO OutgoingSMs " +
                                            "(MsgTarget, MsgText, MsgStatus, MsgPort, MsgSentBy) " +
                                            " VALUES (@msgTarget, @msgText, 0, 'ANY', @msgSentBy)";

        public void Send(IEnumerable<string> recipients, string message)
        {
            var cnn = new SqlConnection(AppConfig.SmsRcSql);
            cnn.Open();
            var cmd = cnn.CreateCommand();
            cmd.CommandText = commandText;
            cmd.Parameters.Add(new SqlParameter("@msgTarget", ""));
            cmd.Parameters.Add(new SqlParameter("@msgText", string.Format("{0} - {1}", message, GravitySession.User.Entity.Name)));
            cmd.Parameters.Add(new SqlParameter("@msgSentBy", GravitySession.User.Entity.Credentials.LoginName));

            foreach (var recipient in recipients)
            {
                cmd.Parameters["@msgTarget"].Value = recipient;
                cmd.ExecuteNonQuery();
            }

            cnn.Close();
        }
    }
}
