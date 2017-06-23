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


public class Index_Temp_2fSysConfigEntities_2fByName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fSysConfigEntities_2fByName()
	{
		this.ViewText = @"from doc in docs.SysConfigEntities
select new { Name = doc.Name }";
		this.ForEntityNames.Add("SysConfigEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "SysConfigEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Name = doc.Name,
				__document_id = doc.__document_id
			});
		this.AddField("Name");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("__document_id");
	}
}
