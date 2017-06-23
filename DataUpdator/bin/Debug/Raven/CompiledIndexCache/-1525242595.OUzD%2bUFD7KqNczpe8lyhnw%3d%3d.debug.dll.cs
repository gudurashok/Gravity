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


public class Index_Auto_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndRecurrenceAndRecurrence_DuplicateAndRecurrence_Type : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fTaskEntities_2fByAssignedByIdAndAssignedToIdAndCcToIdsAndCreatedByIdAndRecurrenceAndRecurrence_DuplicateAndRecurrence_Type()
	{
		this.ViewText = @"from doc in docs.TaskEntities
select new { Recurrence_Duplicate = doc.Recurrence.Duplicate, Recurrence_Type = doc.Recurrence.Type, AssignedById = doc.AssignedById, AssignedToId = doc.AssignedToId, CreatedById = doc.CreatedById, Recurrence = doc.Recurrence, CcToIds = doc.CcToIds }";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Recurrence_Duplicate = doc.Recurrence.Duplicate,
				Recurrence_Type = doc.Recurrence.Type,
				AssignedById = doc.AssignedById,
				AssignedToId = doc.AssignedToId,
				CreatedById = doc.CreatedById,
				Recurrence = doc.Recurrence,
				CcToIds = doc.CcToIds,
				__document_id = doc.__document_id
			});
		this.AddField("Recurrence_Duplicate");
		this.AddField("Recurrence_Type");
		this.AddField("AssignedById");
		this.AddField("AssignedToId");
		this.AddField("CreatedById");
		this.AddField("Recurrence");
		this.AddField("CcToIds");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Recurrence.Duplicate");
		this.AddQueryParameterForMap("Recurrence.Type");
		this.AddQueryParameterForMap("AssignedById");
		this.AddQueryParameterForMap("AssignedToId");
		this.AddQueryParameterForMap("CreatedById");
		this.AddQueryParameterForMap("Recurrence");
		this.AddQueryParameterForMap("CcToIds");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Recurrence.Duplicate");
		this.AddQueryParameterForReduce("Recurrence.Type");
		this.AddQueryParameterForReduce("AssignedById");
		this.AddQueryParameterForReduce("AssignedToId");
		this.AddQueryParameterForReduce("CreatedById");
		this.AddQueryParameterForReduce("Recurrence");
		this.AddQueryParameterForReduce("CcToIds");
		this.AddQueryParameterForReduce("__document_id");
	}
}
