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


public class Index_Temp_2fUserEntities_2fByCredentials_LoginName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fUserEntities_2fByCredentials_LoginName()
	{
		this.ViewText = @"from doc in docs.UserEntities
select new { Credentials_LoginName = doc.Credentials.LoginName }";
		this.ForEntityNames.Add("UserEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "UserEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Credentials_LoginName = doc.Credentials.LoginName,
				__document_id = doc.__document_id
			});
		this.AddField("Credentials_LoginName");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Credentials.LoginName");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Credentials.LoginName");
		this.AddQueryParameterForReduce("__document_id");
	}
}
