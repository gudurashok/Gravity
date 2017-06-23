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


public class Index_Auto_2fPartyEntities_2fByAddresses_Address_AreaAndAddresses_Address_CityAndAddresses_Address_Landmark : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fPartyEntities_2fByAddresses_Address_AreaAndAddresses_Address_CityAndAddresses_Address_Landmark()
	{
		this.ViewText = @"from doc in docs.PartyEntities
from docAddressesItem in ((IEnumerable<dynamic>)doc.Addresses).DefaultIfEmpty()
select new { Addresses_Address_Landmark = docAddressesItem.Address.Landmark, Addresses_Address_City = docAddressesItem.Address.City, Addresses_Address_Area = docAddressesItem.Address.Area }";
		this.ForEntityNames.Add("PartyEntities");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "PartyEntities", System.StringComparison.InvariantCultureIgnoreCase)
			from docAddressesItem in ((IEnumerable<dynamic>)doc.Addresses).DefaultIfEmpty()
			select new {
				Addresses_Address_Landmark = docAddressesItem.Address.Landmark,
				Addresses_Address_City = docAddressesItem.Address.City,
				Addresses_Address_Area = docAddressesItem.Address.Area,
				__document_id = doc.__document_id
			});
		this.AddField("Addresses_Address_Landmark");
		this.AddField("Addresses_Address_City");
		this.AddField("Addresses_Address_Area");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Address.Landmark");
		this.AddQueryParameterForMap("Address.City");
		this.AddQueryParameterForMap("Address.Area");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Address.Landmark");
		this.AddQueryParameterForReduce("Address.City");
		this.AddQueryParameterForReduce("Address.Area");
		this.AddQueryParameterForReduce("__document_id");
	}
}
