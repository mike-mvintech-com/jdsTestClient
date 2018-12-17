using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdsTestClient
{
  class Program
  {
    static void Main(string[] args)
    {

      jdsTestClient.UserCredentials.UserName = "mike@mvintech.com";
      jdsTestClient.UserCredentials.Password = "mmaggi7262";

      var api = new JetnetDataServiceConnection();

      // Get Product Codes
      dynamic productCodes = api.getProductCodes();

      if (productCodes != null)
      {
        Console.WriteLine("Get Product Codes {0}", productCodes);
      }
      else
      {
        Console.WriteLine("Get Product Codes {0}", api.Error);
      }

      // Get Airframe Types
      dynamic getAirframeTypes = api.getAirframeTypes();

      if (getAirframeTypes != null)
      {
        Console.WriteLine("Get Airframe Types {0}", getAirframeTypes);
      }
      else
      {
        Console.WriteLine("Get Airframe Types {0}", api.Error);
      }

      // Get Aircraft Types
      dynamic getAircraftTypes = api.getAircraftTypes();

      if (getAircraftTypes != null)
      {
        Console.WriteLine("Get Aircraft Types {0}", getAircraftTypes);
      }
      else
      {
        Console.WriteLine("Get Aircraft Types {0}", api.Error);
      }

      // Get Aircraft Model List
      dynamic getAircraftModelList = api.getAircraftModelList(null, null, "ASTRA");

      if (getAircraftModelList != null)
      {
        Console.WriteLine("Get Aircraft Model List {0}", getAircraftModelList);
      }
      else
      {
        Console.WriteLine("Get Aircraft Model List {0}", api.Error);
      }

      // Get Aircraft Make List
      dynamic getAircraftMakeList = api.getAircraftMakeList("F","J");

      if (getAircraftMakeList != null)
      {
        Console.WriteLine("Get Aircraft Make List {0}", getAircraftMakeList);
      }
      else
      {
        Console.WriteLine("Get Aircraft Make List {0}", api.Error);
      }

      // Get Aircraft List
      dynamic getAircraftList = api.getAircraftList(null, null, "ASTRA");

      if (getAircraftList != null)
      {
        Console.WriteLine("Get Aircraft List {0}", getAircraftList);
      }
      else
      {
        Console.WriteLine("Get Aircraft List {0}", api.Error);
      }

      // Get Aircraft 
      dynamic getAircraft = api.getAircraft(136);

      if (getAircraft != null)
      {
        Console.WriteLine("Get Aircraft {0}", getAircraft);
      }
      else
      {
        Console.WriteLine("Get Aircraft {0}", api.Error);
      }

      Console.WriteLine("\nHit Any Key to Continue");
      Console.ReadKey();

    }
  }

}
