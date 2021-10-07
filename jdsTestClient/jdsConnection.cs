using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

    public string apiBase = "https://www.jetnetconnect.com/JetnetDataService.svc/"; // live service url
    //public string apiBase = "https://www.test.jetnetconnect.com/JetnetDataService.svc/";  // test service url

    public dynamic Results { get; set; }
    public string error { get; set; }

    public string securityToken = null;

    public JetnetDataServiceConnection()
    {
      client.Timeout = TimeSpan.FromMinutes(10);
    }

    #region helper_functions

    private async Task<IEnumerable<dynamic>> RequestInformation(string method = "GET", string endpoint = "", dynamic parameters = null, string accessToken = null)
    {

      // Check if access token has expired
      if (accessToken == null)
      {
        accessToken = await GetAccessToken();
        securityToken = accessToken;
      }

      if (accessToken == null)
      {
        if (!string.IsNullOrEmpty(error))
        {
          return null;
        }
      }

      bool content = false;
      string url = null;
      dynamic connectionType = null;

      error = "";
      Results = null;

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

        dynamic json = await response.Content.ReadAsStringAsync();

        if ((int)response.StatusCode == 200)
        {
          Results = JsonConvert.DeserializeObject<dynamic>(json);
        }

        if (response.IsSuccessStatusCode)
        {
          error = ((int)response.StatusCode).ToString();
          return Results;
        }
        else
        {
          if (Results != null)
          {
            Console.WriteLine("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, Results.message);
            error = string.Format("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, Results.message);
            return Results;
          }
          else
          {
            Console.WriteLine("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            error = string.Format("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
          }
        }
      }
      catch (Exception e)
      {
        error = string.Format("Exception Msg : {0} Exc : {1}", e.Message, e.InnerException);
        Console.WriteLine(error);
      }

      return null;
    }

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

      string url = apiBase + "getSecurityToken";//?username=" + UserCredentials.UserName + "&password=" + UserCredentials.Password;
      dynamic connectionType = HttpMethod.Get;

      dynamic results = null;

      var connection = new HttpRequestMessage(
        connectionType,
        string.Format(url)
      );

      connection.Headers.Add("username", UserCredentials.UserName);
      connection.Headers.Add("password", UserCredentials.Password);
      connection.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      try
      {
        HttpResponseMessage response = await client.SendAsync(connection);

        dynamic json = await response.Content.ReadAsStringAsync();

        if ((int)response.StatusCode == 200)
        {
          results = JsonConvert.DeserializeObject<dynamic>(json);
        }

        if (response.IsSuccessStatusCode)
        {
          error = ((int)response.StatusCode).ToString();
          UserCredentials.SecurityToken = results;
        }
        else
        {
          if (results != null)
          {
            Console.WriteLine("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, results.message);
            error = string.Format("Response Error {0} ({1}): {2}", (int)response.StatusCode, response.ReasonPhrase, results.message);
            return results;
          }
          else
          {
            Console.WriteLine("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            error = string.Format("Response Error {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
          }
        }

      }
      catch (Exception e)
      {

        error = string.Format("Exception Msg : {0} Exc : {1}", e.Message, e.InnerException);
        Console.WriteLine(error);

      }

      return results;

    }

    #endregion

    #region admin_functions

    public IEnumerable<dynamic> getProductCodes()
    {
      dynamic results = RequestInformation("GET", "getProductCodes", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAccountInfo()
    {
      dynamic results = RequestInformation("GET", "getAccountInfo", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAirframeTypes()
    {
      dynamic results = RequestInformation("GET", "getAirframeTypes", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getMakeTypeList(string airframetype = null)
    {
      dynamic results = RequestInformation("GET", "getMakeTypeList", "airframetype=" + airframetype, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftMakeList(string airframetype = null, string maketype = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftMakeList", "airframetype=" + airframetype + "&maketype=" + maketype, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftModelList(string airframetype = null, string maketype = null, string make = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftModelList", "airframetype=" + airframetype + "&maketype=" + maketype + "&make=" + make, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getWeightClassTypes()
    {
      dynamic results = RequestInformation("GET", "getWeightClassTypes", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAirframeJniqSizes()
    {
      dynamic results = RequestInformation("GET", "getAirframeJniqSizes", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyBusinessTypes()
    {
      dynamic results = RequestInformation("GET", "getCompanyBusinessTypes", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftCompanyRelationships()
    {
      dynamic results = RequestInformation("GET", "getAircraftCompanyRelationships", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getEventCategories()
    {
      dynamic results = RequestInformation("GET", "getEventCategories", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getEventTypes(string category = null)
    {
      dynamic results = RequestInformation("GET", "getEventTypes", "eventcategory=" + category, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAirportList(string name = null, string city = null, string state = null, string statename = null, string country = null, string iata = null, string icao = null, string faaid = null)
    {
      dynamic results = RequestInformation("GET", "getAirportList", "name=" + name + "&city=" + city + "&state=" + state + "&statename=" + statename + "&country=" + country + "&iata=" + iata + "&icao=" + icao + "&faaid=" + faaid, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getStateList(string country = null)
    {
      dynamic results = RequestInformation("GET", "getStateList", "country=" + country, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCountryList()
    {
      dynamic results = RequestInformation("GET", "getCountryList", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftLifecycleStatus()
    {
      dynamic results = RequestInformation("GET", "getAircraftLifecycleStatus", null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftHistoryTransTypes()
    {
      dynamic results = RequestInformation("GET", "getAircraftHistoryTransTypes", null, securityToken).Result;

      return results;
    }

    #endregion

    #region aircraft_functions

    public IEnumerable<dynamic> getAircraft(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftIdentification(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/identification/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftStatus(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/status/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftAirframe(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/airframe/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftEngine(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/engine/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftApu(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/apu/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftCompanyrelationships(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/companyrelationships/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftMaintenance(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/maintenance/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftAvionics(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/avionics/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftFeatures(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/features/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftAdditionalEquipment(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/additionalequipment/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftInterior(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/interior/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftExterior(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/exterior/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftLeases(int aircraftID)
    {
      dynamic results = RequestInformation("GET", "getAircraft/leases/" + aircraftID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftList(string airframetype = null, string maketype = null, string sernbr = null, string regnbr = null, string modelid = null,
                                                string make = null, string forsale = null, string lifecycle = null,
                                                string basestate = null, string basestatename = null, string basecountry = null,
                                                string basecode = null, string actiondate = null,
                                                string companyid = null, string contactid = null,
                                                string yearmfr = null, string yeardlv = null, string aircraftchanges = null, string aclist = null, string modlist = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftList", "airframetype=" + airframetype + "&maketype=" + maketype + "&sernbr=" + sernbr + "&regnbr=" + regnbr + "&modelid=" + modelid + "&make=" + make +
                                                                     "&forsale=" + forsale + "&lifecycle=" + lifecycle + "&basestate=" + basestate + "&basestatename=" + basestatename + "&basecountry=" + basecountry + "&basecode=" + basecode +
                                                                     "&actiondate=" + actiondate + "&companyid=" + companyid + "&contactid=" + contactid + "&yearmfr=" + yearmfr + "&yeardlv=" + yeardlv + "&aircraftchanges=" + aircraftchanges + "&aircraftidlist=" + aclist + "&modelidlist=" + modlist, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftEventList(string aircraftid = null, string modelid = null,
                                                 string make = null, string category = null, string evtype = null,
                                                 string startdate = null, string enddate = null, string aclist = null, string modlist = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftEventList", "aircraftid=" + aircraftid + "&modelid=" + modelid + "&make=" + make + "&eventcategory=" + category + "&eventtype=" + evtype + "&startdate=" + startdate + "&enddate=" + enddate + "&aircraftidlist=" + aclist + "&modelidlist=" + modlist, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftRelationships(int aircraftid, string modlist = null, string actiondate = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftRelationships", "aircraftid=" + aircraftid.ToString() + "&modelidlist=" + modlist + "&actiondate=" + actiondate, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getAircraftHistoryList(string aircraftid = null, string airframetype = null, string maketype = null, string modelid = null, string make = null,
                                                       string companyid = null, string allrelationships = null, string transtype = null, string startdate = null, string enddate = null, string aclist = null, string modlist = null)
    {
      dynamic results = RequestInformation("GET", "getAircraftHistoryList", "aircraftid=" + aircraftid + "&airframetype=" + airframetype + "&maketype=" + maketype + "&modelid=" + modelid + "&make=" + make +
                                                                            "&companyid=" + companyid + "&allrelationships=" + allrelationships + "&transtype=" + transtype + "&startdate=" + startdate + "&enddate=" + enddate + "&aircraftidlist=" + aclist + "&modelidlist=" + modlist, securityToken).Result;

      return results;
    }

    #endregion

    #region company_functions

    public IEnumerable<dynamic> getCompany(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyIdentification(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/identification/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyContacts(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/contacts/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyPhonenumbers(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/phonenumbers/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyBusinesstypes(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/businesstypes/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyAircraftrelationships(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/aircraftrelationships/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyRelatedcompanies(int companyID)
    {
      dynamic results = RequestInformation("GET", "getCompany/relatedcompanies/" + companyID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getCompanyList(string acid = null, string name = null, string country = null, string city = null,
                                               string state = null, string statename = null, string bustype = null,
                                               string airframetype = null, string maketype = null, string modelid = null, string make = null,
                                               string relationship = null, string isoperator = null, string actiondate = null, string companychanges = null, string website = null, string complist = null)
    {
      dynamic results = RequestInformation("GET", "getCompanyList", "aircraftid=" + acid + "&name=" + name + "&country=" + country + "&city=" + city + "&state=" + state + "&statename=" + statename + "&businesstype=" + bustype + "&airframetype=" + airframetype + "&maketype=" + maketype + "&modelid=" + modelid + "&make=" + make + "&companyrelationship=" + relationship + "&isoperator=" + isoperator + "&actiondate=" + actiondate + "&companychanges=" + companychanges + "&website=" + website + "&companyidlist=" + complist, securityToken).Result;

      return results;
    }

    #endregion

    #region contact_functions

    public IEnumerable<dynamic> getContact(dynamic contactID)
    {
      dynamic results = RequestInformation("GET", "getContact/" + contactID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getContactIdentification(int contactID)
    {
      dynamic results = RequestInformation("GET", "getContact/identification/" + contactID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getContactPhonenumbers(int contactID)
    {
      dynamic results = RequestInformation("GET", "getContact/phonenumbers/" + contactID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getContactAircraftrelationships(int contactID)
    {
      dynamic results = RequestInformation("GET", "getContact/aircraftrelationships/" + contactID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getContactOtherlistings(int contactID)
    {
      dynamic results = RequestInformation("GET", "getContact/otherlistings/" + contactID, null, securityToken).Result;

      return results;
    }

    public IEnumerable<dynamic> getContactList(string acid = null, string compid = null, string companyname = null, string firstname = null, string lastname = null,
                                        string title = null, string email = null, string actiondate = null, string phonenumber = null, string contactchanges = null, string contlist = null)
    {
      dynamic results = RequestInformation("GET", "getContactList", "aircraftid=" + acid + "&companyid=" + compid + "&companyname=" + companyname + "&firstname=" + firstname + "&lastname=" + lastname + "&title=" + title + "&email=" + email + "&actiondate=" + actiondate + "&phonenumber=" + phonenumber + "&contactchanges=" + contactchanges + "&contactidlist=" + contlist, securityToken).Result;

      return results;
    }
    #endregion
  }

}
