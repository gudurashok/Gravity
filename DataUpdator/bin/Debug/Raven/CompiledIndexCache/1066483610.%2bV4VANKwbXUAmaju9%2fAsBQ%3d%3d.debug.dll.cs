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


public class Index_Auto_2fUserEntities_2fByNameSortByName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fUserEntities_2fByNameSortByName()
	{
		this.ViewText = @"from doc in docs.UserEntities
select new { Name = doc.Name }";
		this.ForEntityNames.Add("UserEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "UserEntities", System.StringComparison.InvariantCultureIgnoreCase)
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
