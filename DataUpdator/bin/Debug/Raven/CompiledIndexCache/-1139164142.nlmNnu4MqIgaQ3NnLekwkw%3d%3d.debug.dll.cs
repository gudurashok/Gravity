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


public class Index_Auto_2fTaskCommentEntities_2fByTaskId : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskCommentEntities_2fByTaskId()
	{
		this.ViewText = @"from doc in docs.TaskCommentEntities
select new { TaskId = doc.TaskId }";
		this.ForEntityNames.Add("TaskCommentEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskCommentEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				TaskId = doc.TaskId,
				__document_id = doc.__document_id
			});
		this.AddField("TaskId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("TaskId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("TaskId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
