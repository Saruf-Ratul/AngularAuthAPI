﻿using System;
namespace AngularAuthAPI.Models
{
	public class EmailModel
	{
		public string From { get; set; } = string.Empty;
		public string To { get; set; } = string.Empty;
		public string Subject { get; set; } = string.Empty;
		public string Body { get; set; } = string.Empty;
	}
}

