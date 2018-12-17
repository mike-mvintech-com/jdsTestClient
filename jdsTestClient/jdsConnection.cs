using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace jdsTestClient
{

  public class UserCredentials
  {

    public UserCredentials()
    {
      UserName = "";
      Password = "";
      SecurityToken = "";
    }

    public UserCredentials(string _UserName, string _Password, string _SecurityToken)
    {
      UserName = _UserName;
      Password = _Password;
      SecurityToken = _SecurityToken;
    }

    public static string UserName { get; set; }
    public static string Password { get; set; }
    public static string SecurityToken { get; set; }

  }

  class JetnetDataServiceConnection
  {

    HttpClient client = new HttpClient();

    protected string _UserName = "";
    protected string _Password = "";

    protected string url = "";
    //public string apiBase = "http://www.jetnet.data.service.com/JetnetDataService.svc/";
    public string apiBase = "http://www.dataService.jetnet.com/JetnetDataService.svc/";

    public dynamic Results { get; set; }
    public string Error { get; set; }

    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }

    /**
		 * Execute RESTful API Get Request
		 * 
		 * @params 
		 *   endpoint - the endpoint location for the request
		 *   parameters - the query parameters for the request
		 *   format - the return format for the request
		 *   accessToken - the pregenerated Bearer Token
		 * @return
		 *   results: JSON Object Converted into a C# Object
		 */
    private async Task<IEnumerable<dynamic>> RequestInformation(string method = "GET", string endpoint = "connection", dynamic parameters = null, string accessToken = null)
    {
      // Check if access token has expired
      if (accessToken == null)
      {
        accessToken = await GetAccessToken();
      }

      // Establish Connection Object
      bool content = false;
      string url = null;
      dynamic connectionType = null;

      Error = "";

      // Set Method Type
      switch (method.ToUpper())
      {
        case "GET":

          connectionType = HttpMethod.Get;
          url = apiBase + endpoint;
            if (!string.IsNullOrWhiteSpace(parameters))
              url += "?" + parameters;
          break;

        case "POST":

          content = true;
          connectionType = HttpMethod.Post;
          url = apiBase + endpoint;
          if (!string.IsNullOrWhiteSpace(parameters))
            url += "?" + parameters;
          break;
      }


      var connection = new HttpRequestMessage(
          connectionType,
          string.Format(url)
      );

      // Add Headers
      connection.Headers.Add("securityToken", accessToken);
      connection.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      try
      {
        // Set Body if POST
        if (content)
        {
          // Convert Object to JSON then attach as string to Content of POST Request
          StringContent jsonQuery = new StringContent(JsonConvert.SerializeObject(parameters));
          connection.Content = jsonQuery;
        }

        // Send Request
        HttpResponseMessage response = await client.SendAsync(connection);

        // Deserialize Response		Host	null	string

        dynamic json = await response.Content.ReadAsStringAsync();

        if ((int)response.StatusCode != 500)
        {
          Results = JsonConvert.DeserializeObject<dynamic>(json);
        }

        if (response.IsSuccessStatusCode)
        {
          Error = ((int)response.StatusCode).ToString();
          return Results;
        }
        else
        {
          if (Results != null)
          {
            Console.WriteLine("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, Results.message);
            Error = string.Format("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, Results.message);
            return Results;
          }
          else
          {
            Console.WriteLine("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            Error = string.Format("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Error = string.Format("Exception {0}", e.Message);
      }

      return null;
    }

    /**
		 * Gets Authorization Code
		 * 
		 * @return - Encoded Key Pair to be sent for verification
		 */

    private async Task<string> GetAccessToken()
    {

      if (UserCredentials.UserName == "")
      {
        UserCredentials.UserName = _UserName;
      }

      if (UserCredentials.Password == "")
      {
        UserCredentials.Password = _Password;
      }

      string url = apiBase + "getSecurityToken?username=" + UserCredentials.UserName + "&password=" + UserCredentials.Password;
      dynamic connectionType = HttpMethod.Get;
      var basicAuth = "";

      var connection = new HttpRequestMessage(
        connectionType,
        string.Format(url)
      );

      HttpResponseMessage response = await client.SendAsync(connection);

      // Deserialize Response		Host	null	string

      dynamic json = await response.Content.ReadAsStringAsync();

      if ((int)response.StatusCode != 500)
      {
        basicAuth = JsonConvert.DeserializeObject<dynamic>(json);
        UserCredentials.SecurityToken = basicAuth.Trim();

      }

      return basicAuth;
    }


    public IEnumerable<dynamic> getProductCodes()
    {
      dynamic results = RequestInformation("GET", "getProductCodes").Result;

      return results;
    }

    public IEnumerable<dynamic> getAirframeTypes()
    {
      dynamic results = RequestInformation("GET", "getAirframeTypes").Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftTypes(string airframetype = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftTypes", "airframetype=" + airframetype).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftMakeList(string airframetype = null, string maketype = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftMakeList", "airframetype=" + airframetype + "&maketype=" + maketype).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftModelList(string airframetype = null, string maketype = null, string makename = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftModelList", "airframetype=" + airframetype + "&maketype=" + maketype + "&makename=" + makename).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraft(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/" + aircraftID).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftList(string airframetype = null, string maketype = null, string makename = null, string modelname = null, string forsale = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftList", "airframetype=" + airframetype + "&maketype=" + maketype + "&makename=" + makename + "&modelname=" + modelname + "&forsale=" + forsale).Result;

      return results;
    }

  }

}
