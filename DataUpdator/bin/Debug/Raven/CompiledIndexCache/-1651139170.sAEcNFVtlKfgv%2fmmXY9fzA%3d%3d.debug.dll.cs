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


public class Index_Temp_2fUserConfigEntities_2fBy__document_idAndNameAndUserIdSortBy__document_id : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fUserConfigEntities_2fBy__document_idAndNameAndUserIdSortBy__document_id()
	{
		this.ViewText = @"from doc in docs.UserConfigEntities
select new { __document_id = doc.__document_id, UserId = doc.UserId, Name = doc.Name }";
		this.ForEntityNames.Add("UserConfigEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "UserConfigEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				__document_id = doc.__document_id,
				UserId = doc.UserId,
				Name = doc.Name
			});
		this.AddField("__document_id");
		this.AddField("UserId");
		this.AddField("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("UserId");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("UserId");
		this.AddQueryParameterForReduce("Name");
	}
}
