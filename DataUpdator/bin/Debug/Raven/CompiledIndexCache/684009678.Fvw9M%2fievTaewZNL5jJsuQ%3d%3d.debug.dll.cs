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


public class Index_Tasks_2fCount : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Tasks_2fCount()
	{
		this.ViewText = @"docs.TaskEntities
	.Select(task => new {UserId = task.CreatedById, Count = 1})
results
	.GroupBy(taskCount => taskCount.UserId)
	.Select(g => new () {UserId = g.Key, Count = g.Sum(x => ((System.Int32)(x.Count)))})";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => docs.Where(__document => string.Equals(__document["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)).Select((Func<dynamic, dynamic>)(task => new {
			UserId = task.CreatedById,
			Count = 1,
			__document_id = task.__document_id
		})));
		this.ReduceDefinition = results => results.GroupBy((Func<dynamic, dynamic>)(taskCount => taskCount.UserId)).Select((Func<IGrouping<dynamic,dynamic>, dynamic>)(g => new {
			UserId = g.Key,
			Count = g.Sum((Func<dynamic, System.Int32>)(x => ((System.Int32)(x.Count))))
		}));
		this.GroupByExtraction = taskCount => taskCount.UserId;
		this.AddField("UserId");
		this.AddField("Count");
	}
}
