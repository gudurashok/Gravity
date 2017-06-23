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


public class Index_Auto_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndNameAndStatusSortByName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndNameAndStatusSortByName()
	{
		this.ViewText = @"from doc in docs.TaskEntities
select new { AssignedById = doc.AssignedById, AssignedToId = doc.AssignedToId, CreatedById = doc.CreatedById, CcToIds = doc.CcToIds, Status = doc.Status, Name = doc.Name }";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				AssignedById = doc.AssignedById,
				AssignedToId = doc.AssignedToId,
				CreatedById = doc.CreatedById,
				CcToIds = doc.CcToIds,
				Status = doc.Status,
				Name = doc.Name,
				__document_id = doc.__document_id
			});
		this.AddField("AssignedById");
		this.AddField("AssignedToId");
		this.AddField("CreatedById");
		this.AddField("CcToIds");
		this.AddField("Status");
		this.AddField("Name");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("AssignedById");
		this.AddQueryParameterForMap("AssignedToId");
		this.AddQueryParameterForMap("CreatedById");
		this.AddQueryParameterForMap("CcToIds");
		this.AddQueryParameterForMap("Status");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("AssignedById");
		this.AddQueryParameterForReduce("AssignedToId");
		this.AddQueryParameterForReduce("CreatedById");
		this.AddQueryParameterForReduce("CcToIds");
		this.AddQueryParameterForReduce("Status");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("__document_id");
	}
}
