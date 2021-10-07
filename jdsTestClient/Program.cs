using System;

namespace jdsTestClient
{
  class Program
  {
    static void Main(string[] args)
    {



      jdsTestClient.UserCredentials.UserName = "demo@jetnet.com";
      jdsTestClient.UserCredentials.Password = "g846ii2v";

      var api = new JetnetDataServiceConnection();

      // Get Account Info
      dynamic getAccountInfo = api.getAccountInfo();

      if (getAccountInfo != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Account Info {0}", getAccountInfo);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Account Info {0}", api.error);
      }

      // Get Product Codes
      dynamic getProductCodes = api.getProductCodes();

      if (getProductCodes != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Product Codes {0}", getProductCodes);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Product Codes {0}", api.error);
      }

      dynamic getAirframeTypes = api.getAirframeTypes();

      if (getAirframeTypes != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Airframe Types {0}", getAirframeTypes);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Airframe Types {0}", api.error);
      }

      dynamic getAircraftTypes = api.getMakeTypeList(null);

      if (getAircraftTypes != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft Types {0}", getAircraftTypes);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft Types {0}", api.error);
      }

      //dynamic getAircraftMakeList = api.getAircraftMakeList(null, null);

      //if (getAircraftMakeList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Make List {0}", getAircraftMakeList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Make List {0}", api.error);
      //}

      //dynamic getAircraftModelList = api.getAircraftModelList(null, null, null);

      //if (getAircraftModelList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Model List {0}", getAircraftModelList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Model List {0}", api.error);
      //}

      //dynamic getWeightClassTypes = api.getWeightClassTypes();

      //if (getWeightClassTypes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Weight Class Types {0}", getWeightClassTypes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Weight Class Types {0}", api.error);
      //}

      //dynamic getAirframeJniqSizes = api.getAirframeJniqSizes();

      //if (getAirframeJniqSizes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airframe Jniq Sizes {0}", getAirframeJniqSizes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airframe Jniq Sizes {0}", api.error);
      //}

      //dynamic getCompanyBusinessTypes = api.getCompanyBusinessTypes();

      //if (getCompanyBusinessTypes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Business Types {0}", getCompanyBusinessTypes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Business Types {0}", api.error);
      //}

      //dynamic getAircraftCompanyRelationships = api.getAircraftCompanyRelationships();

      //if (getAircraftCompanyRelationships != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Company Relationships {0}", getAircraftCompanyRelationships);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Company Relationships {0}", api.error);
      //}

      //dynamic getEventCategories = api.getEventCategories();

      //if (getEventCategories != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Event Categories {0}", getEventCategories);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Event Categories {0}", api.error);
      //}

      //dynamic getEventTypes = api.getEventTypes("Market Status, Transaction");

      //if (getEventTypes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Event Types {0}", getEventTypes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Event Types {0}", api.error);
      //}

      //dynamic getStateList = api.getStateList("United States");

      //if (getStateList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get State List {0}", getStateList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get State List {0}", api.error);
      //}

      //dynamic getCountryList = api.getCountryList();

      //if (getCountryList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Country List {0}", getCountryList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Country List {0}", api.error);
      //}

      //dynamic getAircraftLifecycleStatus = api.getAircraftLifecycleStatus();

      //if (getAircraftLifecycleStatus != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Lifecycle Status {0}", getAircraftLifecycleStatus);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Lifecycle Status {0}", api.error);
      //}

      //dynamic getAircraftHistoryTransTypes = api.getAircraftHistoryTransTypes();

      //if (getAircraftHistoryTransTypes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft History TransTypes {0}", getAircraftHistoryTransTypes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft History TransTypes {0}", api.error);
      //}

      //SYR KSYR SAW
      // name, city, state, statename, country, iata, icao, faaid
      //dynamic getAirports = api.getAirportList(null, null, "NY, NJ", null, null, null, null, null);

      //if (getAirports != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airport List {0}", getAirports);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airport List {0}", api.error);
      //}

      //dynamic getAirports2 = api.getAirportList(null, null, null, "new york, new jersey", null, null, null, null);

      //if (getAirports2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airport List {0}", getAirports2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Airport List {0}", api.error);
      //}

      // Get Aircraft 136 31899 31106 156 14896 197500 31461 helo 43094 43382 166158 7218 123872 9558
      //dynamic getAircraft = api.getAircraft(9328);

      //if (getAircraft != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft {0}", getAircraft);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft {0}", api.error);
      //}

      //dynamic getAircraft2 = api.getAircraft(0);

      //if (getAircraft2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft {0}", getAircraft2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft {0}", api.error);
      //}

      dynamic getAircraftIdentification = api.getAircraftIdentification(9328);

      if (getAircraftIdentification != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft Identification {0}", getAircraftIdentification);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft Identification {0}", api.error);
      }

      //dynamic getAircraftStatus = api.getAircraftStatus(31461);

      //if (getAircraftStatus != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Status {0}", getAircraftStatus);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Status {0}", api.error);
      //}

      //dynamic getAircraftAirframe = api.getAircraftAirframe(31461);

      //if (getAircraftAirframe != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Airframe Times {0}", getAircraftAirframe);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Airframe Times {0}", api.error);
      //}

      //dynamic getAircraftEngine = api.getAircraftEngine(7218);

      //if (getAircraftEngine != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Engine {0}", getAircraftEngine);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Engine {0}", api.error);
      //}

      //dynamic getAircraftApu = api.getAircraftApu(7218);

      //if (getAircraftApu != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Apu {0}", getAircraftApu);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Apu {0}", api.error);
      //}

      //dynamic getAircraftCompanyrelationships = api.getAircraftCompanyrelationships(31461);

      //if (getAircraftCompanyrelationships != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Company Relationships {0}", getAircraftCompanyrelationships);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Company Relationships {0}", api.error);
      //}

      //dynamic getAircraftMaintenance = api.getAircraftMaintenance(31461);

      //if (getAircraftMaintenance != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Maintenance {0}", getAircraftMaintenance);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Maintenance {0}", api.error);
      //}

      //dynamic getAircraftAvionics = api.getAircraftAvionics(31461);

      //if (getAircraftAvionics != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Avionics {0}", getAircraftAvionics);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Avionics {0}", api.error);
      //}

      //dynamic getAircraftFeatures = api.getAircraftFeatures(31461);

      //if (getAircraftFeatures != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Features {0}", getAircraftFeatures);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Features {0}", api.error);
      //}

      //dynamic getAircraftAdditionalEquipment = api.getAircraftAdditionalEquipment(31461);

      //if (getAircraftAdditionalEquipment != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Additional Equipment {0}", getAircraftAdditionalEquipment);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Additional Equipment {0}", api.error);
      //}

      //dynamic getAircraftInterior = api.getAircraftInterior(9558);

      //if (getAircraftInterior != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Interior {0}", getAircraftInterior);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Interior {0}", api.error);
      //}

      //dynamic getAircraftExterior = api.getAircraftExterior(9558);

      //if (getAircraftExterior != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Exterior {0}", getAircraftExterior);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Exterior {0}", api.error);
      //}

      //dynamic getAircraftLeases = api.getAircraftLeases(166158);

      //if (getAircraftLeases != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Leases {0}", getAircraftLeases);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Leases {0}", api.error);
      //}

      //Get Aircraft Event List "25" "ASTRA" "01/01/2019" "Change in Aircraft Base, New Chief Pilot, Change in Airframe Total Time"
      //"Status to Sale Pending, Fractional Sale, On Exclusive, Off Market" "Company/Contact, Financial Documents, Market Status" "136,31899,31106,156,14896,197500,31461"
      //aircraftid, modelid, makename, evcategory, evtype, startdate, enddate, aircraft list
      //dynamic getAircraftEventList = api.getAircraftEventList("1234", //aircraftid
      //                                                        null, //modelid
      //                                                        null, //makename
      //                                                        null, //evcategory
      //                                                        null, //evtype
      //                                                        "01/01/2010", //startdate
      //                                                        "01/01/2016",//enddate
      //                                                        null,// aircraft list
      //                                                        null);// model list

      //if (getAircraftEventList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Event List {0}", getAircraftEventList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Event List {0}", api.error);
      //}

      // Get Aircraft List "TURBOPROP" "ASTRA" "03/01/2019" "2018" "2019" "In Operation"
      //airframetype, maketype, sernbr, regnbr, modelid, make, forsale, lifecycle, basestate, basestatename, basecountry, basecode, actiondate, companyid, contactid, yearmfr, yeardlv, changes, aircraft list, model list
      //dynamic getAircraftList = api.getAircraftList(null, //airframetype
      //                                              null, //maketype
      //                                              null, //sernbr
      //                                              null, //regnbr
      //                                              "278", //modelid
      //                                              null, //make
      //                                              null, //forsale
      //                                              "In Operation", //lifecycle
      //                                              null, //basestate
      //                                              null, //basestatename
      //                                              null, //basecountry
      //                                              null, //basecode
      //                                              null, //actiondate
      //                                              null, //companyid
      //                                              null, //contactid
      //                                              null, //yearmfr
      //                                              null, //yeardlv
      //                                              null, //changes
      //                                              null, //aircraft list 
      //                                              null); // "1290,1280,71,73,606,74,673,681,286,1148,1162,76,298,1275,1276,1161,277,645,262,274,75,666,192,275,294,276,288,1209,278,1210,663,1211,77,78,79,81,82,83,257,284,1247,643,107,109,110,607,628,642,200,283,636,138,293,142,635,1164,1165,1199,644,22,23,24,25,28,266,655,1270,1271,1272,1263,1264,1265,1261,29,1262,272,1188,30,31,32,33,630,1217,273,624,625,626,39,40,51,1200,287,652,651,1167,270,1191,641,1229,686,687,269,688,661,1274,660,1259,58,59,634,259,674,656,1190,1149,69,292,70,297,1213,245,659,1173"); //model list


      //if (getAircraftList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft List {0}", getAircraftList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft List {0}", api.error);
      //}

      //dynamic getAircraftRelationships = api.getAircraftRelationships(0, //aircraftid
      //                                               "1290,1280,71,73,606,74,673,681,286,1148,1162,76,298,1275,1276,1161,277,645,262,274,75,666,192,275,294,276,288,1209,278,1210,663,1211,77,78,79,81,82,83,257,284,1247,643,107,109,110,607,628,642,200,283,636,138,293,142,635,1164,1165,1199,644,22,23,24,25,28,266,655,1270,1271,1272,1263,1264,1265,1261,29,1262,272,1188,30,31,32,33,630,1217,273,624,625,626,39,40,51,1200,287,652,651,1167,270,1191,641,1229,686,687,269,688,661,1274,660,1259,58,59,634,259,674,656,1190,1149,69,292,70,297,1213,245,659,1173", //modelid
      //                                              "04/25/2021"); //actiondate
      //if (getAircraftRelationships != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Relationships {0}", getAircraftRelationships);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Aircraft Relationships {0}", api.error);
      //}

      // "251492" "166158" "25","ASTRA" "Fixed Wing" "GULFSTREAM" "Business Jet" "full sale, fractional sale, lease, withdrawn from use" "23,24"
      // acid, airframetype, maketype, amodid, make, company, allrel, transtype, start, end, aircraft list, model list
      dynamic getAircraftHistoryList = api.getAircraftHistoryList("9328", null, null, null, null, null, null, null, null, null, null, null);

      if (getAircraftHistoryList != null)
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft History List {0}", getAircraftHistoryList);
      }
      else
      {
        Console.WriteLine("");
        Console.WriteLine("Get Aircraft History List {0}", api.error);
      }

      //Get Company 9487 251492 398448 234288 12142 355383 7223 365492 224517
      //dynamic getCompany = api.getCompany(224517);

      //if (getCompany != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company {0}", getCompany);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company {0}", api.error);
      //}

      //dynamic getCompany2 = api.getCompany(0);

      //if (getCompany2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company {0}", getCompany2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company {0}", api.error);
      //}

      //dynamic getCompanyIdentification = api.getCompanyIdentification(224517);

      //if (getCompanyIdentification != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Identification {0}", getCompanyIdentification);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Identification {0}", api.error);
      //}

      //dynamic getCompanyContacts = api.getCompanyContacts(12142);

      //if (getCompanyContacts != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Contacts {0}", getCompanyContacts);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Contacts {0}", api.error);
      //}

      //dynamic getCompanyPhonenumbers = api.getCompanyPhonenumbers(12142);

      //if (getCompanyPhonenumbers != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Phone numbers {0}", getCompanyPhonenumbers);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Phone numbers {0}", api.error);
      //}

      //dynamic getCompanyBusinesstypes = api.getCompanyBusinesstypes(7223);

      //if (getCompanyBusinesstypes != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Business types {0}", getCompanyBusinesstypes);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Business types {0}", api.error);
      //}

      //dynamic getCompanyAircraftrelationships = api.getCompanyAircraftrelationships(298438);

      //if (getCompanyAircraftrelationships != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Aircraft relationships {0}", getCompanyAircraftrelationships);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Aircraft relationships {0}", api.error);
      //}

      //dynamic getCompanyRelatedcompanies = api.getCompanyRelatedcompanies(12142);

      //if (getCompanyRelatedcompanies != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Related companies {0}", getCompanyRelatedcompanies);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company Related companies {0}", api.error);
      //}

      // bustypes
      // "Aviation Related Business, Dealer Broker, Fixed Base Operator"

      // contacttypes
      // "Owner","Aircraft Management Company","Operator","Chief Pilot","Exclusive Representative","Dealer Broker","Exclusive Broker",
      // "Owner, Operator, Chief Pilot"
      // "Exclusive Representative, Dealer Broker, Exclusive Broker"
      //  modelid "23, 24, 25" make "ASTRA, GULFSTREAM, LEARJET" "278" "Fixed Wing" "GULFSTREAM" "Business Jet""223360" "136,31899,31106,156,14896,197500,31461"

      //Get Company List NY, IN, KS               acid, name, country, city, state, statename, bustype, airframetype, maketype, modelid, make, relationship, isoperator, actiondate, website, changes, company list
      //dynamic getCompanyList = api.getCompanyList(null, //acid
      //                                            null, //name
      //                                            null, //country
      //                                            null, //city
      //                                            null, //state
      //                                            null, //statename
      //                                            null, //bustype
      //                                            null, //airframetype
      //                                            null, //maketype
      //                                            "1290,1280,71,73,606,74,673,681,286,1148,1162,76,298,1275,1276,1161,277,645,262,274,75,666,192,275,294,276,288,1209,278,1210,663,1211,77,78,79,81,82,83,257,284,1247,643,107,109,110,607,628,642,200,283,636,138,293,142,635,1164,1165,1199,644,22,23,24,25,28,266,655,1270,1271,1272,1263,1264,1265,1261,29,1262,272,1188,30,31,32,33,630,1217,273,624,625,626,39,40,51,1200,287,652,651,1167,270,1191,641,1229,686,687,269,688,661,1274,660,1259,58,59,634,259,674,656,1190,1149,69,292,70,297,1213,245,659,1173", //modelid
      //                                            null, //make
      //                                            null, //relationship
      //                                            null, //isoperator
      //                                            "04/07/2021", //actiondate
      //                                            null, //website
      //                                            null, //changes
      //                                            null);//company list

      //if (getCompanyList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company List {0}", getCompanyList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company List {0}", api.error);
      //}

      //dynamic getCompanyList2 = api.getCompanyList(null, null, null, null, null, "new york, new jersey", null, null, null, null, null, null, null, "03/01/2019", null, null);

      //if (getCompanyList2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company List {0}", getCompanyList2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Company List {0}", api.error);
      //}

      //Get Contact 486222 531820 542849 307016 375461 359685 41109 345384
      //dynamic getContact = api.getContact(345384);

      //if (getContact != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", getContact);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", api.error);
      //}

      //dynamic getContact1 = api.getContact(0);

      //if (getContact1 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", getContact1);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", api.error);
      //}


      //dynamic getContact2 = api.getContact("ABC");

      //if (getContact2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", getContact2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact {0}", api.error);
      //}

      //dynamic getContactIdentification = api.getContactIdentification(41109);

      //if (getContactIdentification != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Identification {0}", getContactIdentification);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Identification {0}", api.error);
      //}

      //dynamic getContactPhonenumbers = api.getContactPhonenumbers(41109);

      //if (getContactPhonenumbers != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Phonenumbers {0}", getContactPhonenumbers);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Phonenumbers {0}", api.error);
      //}

      //dynamic getContactAircraftrelationships = api.getContactAircraftrelationships(41109);

      //if (getContactAircraftrelationships != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Aircraft Relationships {0}", getContactAircraftrelationships);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Aircraft Relationships {0}", api.error);
      //}

      //dynamic getContactOtherlistings = api.getContactOtherlistings(41109);

      //if (getContactOtherlistings != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Other listings {0}", getContactOtherlistings);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact Other listings {0}", api.error);
      //}

      // "315437" "+1 (817)-988-0158" "+1(817)-988-0158" "+1817 - 988 - 0158" "+ 1 - 817 - 988 - 0158" "ali", "a"
      // "486222,531820,542849,307016,375461,359685,41109,345384"                                         
      //dynamic getContactList = api.getContactList(null, //acid
      //                                            null, //compid
      //                                            null, //companyname
      //                                            null, //firstname
      //                                            null, //lastname
      //                                            null, //title
      //                                            null, //email
      //                                            null, //actiondate
      //                                            null, //phonenumber
      //                                            null, //contactchanges
      //                                            null); //contact list

      //if (getContactList != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact List {0}", getContactList);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get  Contact List {0}", api.error);
      //}

      //dynamic getContactList2 = api.getContactList("ABCD", null, null, null, null, null, "true");

      //if (getContactList2 != null)
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get Contact List {0}", getContactList2);
      //}
      //else
      //{
      //  Console.WriteLine("");
      //  Console.WriteLine("Get  Contact List {0}", api.error);
      //}

      Console.WriteLine("\nHit Any Key to Continue");
      Console.ReadKey();

    }
  }

}
