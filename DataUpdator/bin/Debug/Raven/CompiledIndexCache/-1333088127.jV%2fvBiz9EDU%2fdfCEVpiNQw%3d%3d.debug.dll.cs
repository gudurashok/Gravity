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


public class Index_Auto_2fTaskMessageEntities_2fByToUserId : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskMessageEntities_2fByToUserId()
	{
		this.ViewText = @"from doc in docs.TaskMessageEntities
select new { ToUserId = doc.ToUserId }";
		this.ForEntityNames.Add("TaskMessageEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskMessageEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				ToUserId = doc.ToUserId,
				__document_id = doc.__document_id
			});
		this.AddField("ToUserId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("ToUserId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("ToUserId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
