using System;
using System.Net;

namespace BusinessAnyplace.CommonServices
{
	/// <summary>
	/// Utility class for checking connection.
	/// </summary>
	public class CheckConnection
	{
		/// <summary>
		/// Check (HTTP) connection once.
		/// </summary>
		/// <param name="targetAddress">Target address (URL or IP) to check</param>
		/// <returns>Whether connection exist to target address</returns>
		public static bool Once(string targetAddress)
		{
			HttpWebRequest request;
			HttpWebResponse response;
			bool isConnected = false;

			try
			{
				request = (HttpWebRequest)WebRequest.Create(targetAddress);
				response = (HttpWebResponse)request.GetResponse();
				request.Abort();

				// success?
				if(response.StatusCode == HttpStatusCode.OK)
				{
					isConnected = true;
				}
			}
			catch(WebException we)
			{
				string errMsg = we.Message;
				isConnected = false;
			}
			catch(Exception ex)
			{
				string errMsg = ex.Message;
				isConnected = false;
			}
			finally
			{
				request = null;
				response = null;
			}
			return isConnected;
		}

		/// <summary>
		/// Check (HTTP) connection a specified number of times.
		/// </summary>
		/// <param name="targetAddress">Target address (URL or IP) to check</param>
		/// <param name="timesToCheck">Maximum number of times to check</param>
		/// <returns>Whether connection exist to target address</returns>
		public static bool Multiple(string targetAddress, int timesToCheck)
		{
			for (int i = 0; i < timesToCheck; i++)
				if (Once(targetAddress))
					return true;
			return false;
		}
	}
}
