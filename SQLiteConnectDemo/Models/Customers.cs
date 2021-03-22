﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLiteConnectDemo.Models
{
    public class Customers
    {
		public long CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public Int64 SupportRepId { get; set; }

	}
}