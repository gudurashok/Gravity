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


public class Index_Temp_2fTaskReminderEntities_2fByIsDefaultAndTaskIdAndUserIds : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fTaskReminderEntities_2fByIsDefaultAndTaskIdAndUserIds()
	{
		this.ViewText = @"from doc in docs.TaskReminderEntities
select new { IsDefault = doc.IsDefault, UserIds = doc.UserIds, TaskId = doc.TaskId }";
		this.ForEntityNames.Add("TaskReminderEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskReminderEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				IsDefault = doc.IsDefault,
				UserIds = doc.UserIds,
				TaskId = doc.TaskId,
				__document_id = doc.__document_id
			});
		this.AddField("IsDefault");
		this.AddField("UserIds");
		this.AddField("TaskId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("IsDefault");
		this.AddQueryParameterForMap("UserIds");
		this.AddQueryParameterForMap("TaskId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("IsDefault");
		this.AddQueryParameterForReduce("UserIds");
		this.AddQueryParameterForReduce("TaskId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
