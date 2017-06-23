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


public class Index_Temp_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndStartDateAndStatus : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Temp_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndStartDateAndStatus()
	{
		this.ViewText = @"from doc in docs.TaskEntities
select new { AssignedById = doc.AssignedById, AssignedToId = doc.AssignedToId, CreatedById = doc.CreatedById, StartDate = doc.StartDate, CcToIds = doc.CcToIds, Status = doc.Status }";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				AssignedById = doc.AssignedById,
				AssignedToId = doc.AssignedToId,
				CreatedById = doc.CreatedById,
				StartDate = doc.StartDate,
				CcToIds = doc.CcToIds,
				Status = doc.Status,
				__document_id = doc.__document_id
			});
		this.AddField("AssignedById");
		this.AddField("AssignedToId");
		this.AddField("CreatedById");
		this.AddField("StartDate");
		this.AddField("CcToIds");
		this.AddField("Status");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("AssignedById");
		this.AddQueryParameterForMap("AssignedToId");
		this.AddQueryParameterForMap("CreatedById");
		this.AddQueryParameterForMap("StartDate");
		this.AddQueryParameterForMap("CcToIds");
		this.AddQueryParameterForMap("Status");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("AssignedById");
		this.AddQueryParameterForReduce("AssignedToId");
		this.AddQueryParameterForReduce("CreatedById");
		this.AddQueryParameterForReduce("StartDate");
		this.AddQueryParameterForReduce("CcToIds");
		this.AddQueryParameterForReduce("Status");
		this.AddQueryParameterForReduce("__document_id");
	}
}
