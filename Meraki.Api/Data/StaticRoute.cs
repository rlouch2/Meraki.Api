﻿using Meraki.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace Meraki.Api.Data
{
	public class StaticRoute : StaticRouteUpdateRequest
{
		/// <summary>
		/// Id
		/// </summary>
		[ApiKey]
		[ApiAccess(ApiAccess.Read)]
		[DataMember(Name = "id")]
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// Network id
		/// </summary>
		[ApiForeignKey(typeof(Network))]
		[ApiAccess(ApiAccess.Read)]
		[DataMember(Name = "networkId")]
		public string NetworkId { get; set; } = string.Empty;
	}
}
