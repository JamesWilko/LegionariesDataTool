using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegionDefenceTool.Utils
{
	public class SpreadsheetDownloader : WebClient
	{
		private readonly CookieContainer container = new CookieContainer();

		public SpreadsheetDownloader()
		{
			this.container = new CookieContainer();
			AddDefaultHeaders();
		}

		public SpreadsheetDownloader(CookieContainer container)
		{
			this.container = container;
			AddDefaultHeaders();
        }

		protected void AddDefaultHeaders()
		{
			Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0");
			Headers.Add("DNT", "1");
			Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
			Headers.Add("Accept-Encoding", "deflate");
			Headers.Add("Accept-Language", "en-US,en;q=0.5");
		}

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest r = base.GetWebRequest(address);
			var request = r as HttpWebRequest;
			if (request != null)
			{
				request.CookieContainer = container;
			}
			return r;
		}

		protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
		{
			WebResponse response = base.GetWebResponse(request, result);
			ReadCookies(response);
			return response;
		}

		protected override WebResponse GetWebResponse(WebRequest request)
		{
			WebResponse response = base.GetWebResponse(request);
			ReadCookies(response);
			return response;
		}

		private void ReadCookies(WebResponse r)
		{
			var response = r as HttpWebResponse;
			if (response != null)
			{
				CookieCollection cookies = response.Cookies;
				container.Add(cookies);
			}
		}

		public string GetPageTitle(string Url)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest.Create(Url) as HttpWebRequest);
				HttpWebResponse response = (request.GetResponse() as HttpWebResponse);

				using (Stream stream = response.GetResponseStream())
				{
					Regex titleCheck = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
					int bytesToRead = 8092;
					byte[] buffer = new byte[bytesToRead];
					string contents = "";
					int length = 0;
					while ((length = stream.Read(buffer, 0, bytesToRead)) > 0)
					{
						contents += Encoding.UTF8.GetString(buffer, 0, length);

						Match m = titleCheck.Match(contents);
						if (m.Success)
						{
							return m.Groups[1].Value.ToString();
						}
						else if (contents.Contains("</head>"))
						{
							return string.Empty;
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return string.Empty;
		}
	}
}
