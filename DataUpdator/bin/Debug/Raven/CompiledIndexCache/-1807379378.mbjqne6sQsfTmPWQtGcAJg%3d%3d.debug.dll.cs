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


public class Index_Task_2fSearch : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Task_2fSearch()
	{
		this.ViewText = @"docs.TaskEntities
	.Select(task => new () {TaskId = task.__document_id, SearchQuery = new System.String []{task.Name, task.Tag, task.DescriptionText}})
docs.TaskCommentEntities
	.Select(comment => new () {TaskId = comment.TaskId, SearchQuery = new System.String []{comment.Comment}})
results
	.GroupBy(result => result.TaskId)
	.Select(g => new () {TaskId = g.Key, SearchQuery = Enumerable.ToArray(g
	.Where(t => t.TaskId == g.Key)
	.Select(c => c.SearchQuery))})";
		this.ForEntityNames.Add("TaskEntities");
		this.AddMapDefinition(docs => docs.Where(__document => string.Equals(__document["@metadata"]["Raven-Entity-Name"], "TaskEntities", System.StringComparison.InvariantCultureIgnoreCase)).Select((Func<dynamic, dynamic>)(task => new {
			TaskId = task.__document_id,
			SearchQuery = new System.String[] {
				task.Name,
				task.Tag,
				task.DescriptionText
			},
			__document_id = task.__document_id
		})));
		this.ForEntityNames.Add("TaskCommentEntities");
		this.AddMapDefinition(docs => docs.Where(__document => string.Equals(__document["@metadata"]["Raven-Entity-Name"], "TaskCommentEntities", System.StringComparison.InvariantCultureIgnoreCase)).Select((Func<dynamic, dynamic>)(comment => new {
			TaskId = comment.TaskId,
			SearchQuery = new System.String[] {
				comment.Comment
			},
			__document_id = comment.__document_id
		})));
		this.ReduceDefinition = results => results.GroupBy((Func<dynamic, dynamic>)(result => result.TaskId)).Select((Func<IGrouping<dynamic,dynamic>, dynamic>)(g => new {
			TaskId = g.Key,
			SearchQuery = Enumerable.ToArray(g.Where((Func<dynamic, bool>)(t => t.TaskId == g.Key)).Select((Func<dynamic, dynamic>)(c => c.SearchQuery)))
		}));
		this.GroupByExtraction = result => result.TaskId;
		this.AddField("TaskId");
		this.AddField("SearchQuery");
	}
}
