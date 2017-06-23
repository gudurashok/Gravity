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


public class Index_Auto_2fTaskTypeEntities_2fByIsActiveAndIsPreferred : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskTypeEntities_2fByIsActiveAndIsPreferred()
	{
		this.ViewText = @"from doc in docs.TaskTypeEntities
select new { IsPreferred = doc.IsPreferred, IsActive = doc.IsActive }";
		this.ForEntityNames.Add("TaskTypeEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskTypeEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				IsPreferred = doc.IsPreferred,
				IsActive = doc.IsActive,
				__document_id = doc.__document_id
			});
		this.AddField("IsPreferred");
		this.AddField("IsActive");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("IsPreferred");
		this.AddQueryParameterForMap("IsActive");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("IsPreferred");
		this.AddQueryParameterForReduce("IsActive");
		this.AddQueryParameterForReduce("__document_id");
	}
}
