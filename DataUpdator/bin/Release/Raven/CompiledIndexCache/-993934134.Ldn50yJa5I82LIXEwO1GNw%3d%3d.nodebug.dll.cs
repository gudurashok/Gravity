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


public class Index_Auto_2fTaskEntities_2fByNumber : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskEntities_2fByNumber()
	{
		this.ViewText = @"from doc in docs.TaskEntities
select new { Number = doc.Number }";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Number = doc.Number,
				__document_id = doc.__document_id
			});
		this.AddField("Number");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Number");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Number");
		this.AddQueryParameterForReduce("__document_id");
	}
}
