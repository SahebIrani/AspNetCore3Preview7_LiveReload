using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using System;

namespace Simple.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public string DateShow { get; set; }

		public string OnGet()
		{
			DateShow = DateTimeOffset.UtcNow.ToString();

			return DateShow;
		}
	}
}
