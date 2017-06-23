using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;


public class Index_Auto_2fTaskReminderEntities_2fByRemindOnAndUserIdsSortByRemindOn : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskReminderEntities_2fByRemindOnAndUserIdsSortByRemindOn()
	{
		this.ViewText = @"from doc in docs.TaskReminderEntities
select new { RemindOn = doc.RemindOn, UserIds = doc.UserIds }";
		this.ForEntityNames.Add("TaskReminderEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskReminderEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				RemindOn = doc.RemindOn,
				UserIds = doc.UserIds,
				__document_id = doc.__document_id
			});
		this.AddField("RemindOn");
		this.AddField("UserIds");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("RemindOn");
		this.AddQueryParameterForMap("UserIds");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("RemindOn");
		this.AddQueryParameterForReduce("UserIds");
		this.AddQueryParameterForReduce("__document_id");
	}
}
