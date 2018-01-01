using System;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace mvvmframework
{
    public class WebAPI
    {
        public static async Task<Rss> GetNewsfeed(bool isFake = false)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient(isFake ? Constants.FakeRSSFeed : Constants.RSSFeed);
            var request = new RestRequest(Method.GET);

            Rss pod = null;
            try
            {
                var objText = XmlReader.Create(isFake ? Constants.FakeRSSFeed : Constants.RSSFeed);
                var serializer = new XmlSerializer(typeof(Rss));
                var items = (Rss)serializer.Deserialize(objText);
                if (items.Channel.Item.Count != 0)
                {
                    foreach (var item in items.Channel.Item)
                        item.ImageSrc = item.Description.GetImage();
                }
                pod = items;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting Podcasts - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }

            return pod;
        }

        public async static Task<Ingredients> GetIngredients()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient(string.Format("{0}{1}", Constants.APIBase, "ingredients"));
            var request = new RestRequest(Method.GET);

            Ingredients pod = null;

            try
            {
                var resp = await client.Execute(request, token);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    pod = JsonConvert.DeserializeObject<Ingredients>(resp.Content);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting Ingredients - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }

            return pod;
        }

        public async static Task<string> LoginUser(string username, string password, string tok = "666")
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var client = new RestClient(string.Format("{0}/login", Constants.DevApiBase));
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded",
                                 string.Format("username={0}&password={1}&token={2}", username.ToLowerInvariant(), password.ToLowerInvariant(), tok),
                                 ParameterType.RequestBody);

            var res = string.Empty;

            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    var data = JsonConvert.DeserializeObject<General<Login>>(response.Content);
                    if (data.data != null)
                        res = data.data.token;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting LoginUser - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }

            return res;
        }

        public async static Task<string> SignupUser(string first, string last, string email, string user, string pass)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var client = new RestClient(string.Format("{0}/signup", Constants.DevApiBase));
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/x-www-form-urlencoded",
                                 string.Format("firstname={0}&lastname={1}&email={2}&username={3}&password={4}",
                                               first, last, email, user, pass),
                                 ParameterType.RequestBody);

            var res = string.Empty;
            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    var data = JsonConvert.DeserializeObject<General<Login>>(response.Content);
                    if (data.data != null)
                        res = data.data.token;
                    else
                        res = data.error_code;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting Signup - {0}--{1}", ex.Message, ex.InnerException);
                res = "error";
#endif
            }

            return res;
        }

        public static async Task<RadioPlayList> GetPlayListItems()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient("http://primordialradio.com/plays/");
            var request = new RestRequest(Method.GET);
            var res = new RadioPlayList();
            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    var dta = JsonConvert.DeserializeObject<List<RadioPlayListItems>>(response.Content);
                    res.PlayList = dta;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting the playlist - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }
            return res;
        }

        public static async Task<string> GetExternalIP()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient("http://myexternalip.com/json");
            var request = new RestRequest(Method.GET);
            var res = new IPAddress();
            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    res = JsonConvert.DeserializeObject<IPAddress>(response.Content);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting the GetExternalIP - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }
            return res.ip;
        }

        public static async Task<string> GetCountryName(string ipAddress)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient(string.Format("{0}{1}", Constants.IPLocationUrl, ipAddress.Trim()));
            var request = new RestRequest(Method.GET);
            var res = new IPLocation();
            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    res = JsonConvert.DeserializeObject<IPLocation>(response.Content);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception getting the GetCountryName - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }
            return res.geobytescountry;
        }


        public static async Task<Venues> GetVenueUpcomingCalendar(int venueId)
        {
            var url = string.Format("{0}/venues/{1}.json?apikey={2}", Constants.SoundKickBaseUrl, venueId, Constants.SoundKickAPI);
            return await GetData<Venues>(url);
        }

        public static async Task<UpcomingEvent> GetEventsById(int eventId)
        {
            var url = string.Format("{0}/events/{1}.json?apikey={2}", Constants.SoundKickBaseUrl, eventId, Constants.SoundKickAPI);
            return await GetData<UpcomingEvent>(url);
        }

        public static async Task<Location> GetLocationSearch(double lat, double lng)
        {
            var url = string.Format("{0}/search/locations.json?location=geo:{1},{2}&apikey={3}", Constants.SoundKickBaseUrl, lat, lng, Constants.SoundKickAPI);
            return await GetData<Location>(url);
        }

        public static async Task<Location> GetLocationSearch(string location)
        {
            var url = string.Format("{0}/search/locations.json?query={1}&apikey={2}", Constants.SoundKickBaseUrl, location, Constants.SoundKickAPI);
            return await GetData<Location>(url);
        }

        public static async Task<ArtistSearch> GetArtistSearch(string name)
        {
            var url = string.Format("{0}/search/artists.json?query={1}&apikey={2}", Constants.SoundKickBaseUrl, name.Replace(' ', '+'), Constants.SoundKickAPI);
            return await GetData<ArtistSearch>(url);
        }

        public static async Task<UpcomingArtistEvent> GetArtistUpcomingEventsCalendar(int artistId)
        {
            var url = string.Format("{0}/artists/{1}/calendar.json?apikey={2}", Constants.SoundKickBaseUrl, artistId, Constants.SoundKickAPI);
            return await GetData<UpcomingArtistEvent>(url);
        }

        public static async Task<UpcomingVenueEvents> GetVenueUpcomingEventsCalendar(int venueId)
        {
            var url = string.Format("{0}/venues/{1}/calendar.json?apikey={2}", Constants.SoundKickBaseUrl, venueId, Constants.SoundKickAPI);
            return await GetData<UpcomingVenueEvents>(url);
        }

        public static async Task<Venues> GetVenueSearch(string name)
        {
            var url = string.Format("{0}/search/venues.json?query={1}&apikey={2}", Constants.SoundKickBaseUrl, name.Replace(' ', '+'), Constants.SoundKickAPI);
            return await GetData<Venues>(url);
        }

        public static async Task<MetroAreaEvents> GetMetroAreaEvents(int metroId)
        {
            var url = string.Format("{0}/metro_areas/{1}/calendar.json?query={1}&apikey={2}", Constants.SoundKickBaseUrl, metroId, Constants.SoundKickAPI);
            return await GetData<MetroAreaEvents>(url);
        }

        static async Task<T> GetData<T>(string url) where T : class, new()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var res = new T();
            try
            {
                var response = await client.Execute(request, token);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    res = JsonConvert.DeserializeObject<T>(response.Content);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("Exception in getdata - {0}--{1}", ex.Message, ex.InnerException);
#endif
            }
            return res;
        }
    }
}

