using System.Collections.Generic;
using mvvmframework.ViewModel;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;

namespace mvvmframework
{
    public class GigsViewModel : BaseViewModel
    {
        IConnection connectionService;

        public GigsViewModel(IConnection connect)
        {
            connectionService = connect;
            SearchEnable = false;
        }

        public string NotOnTour { get; set; }

        string searchAreaParam;
        public string SearchAreaParam
        {
            get { return searchAreaParam; }
            set
            {
                Set(() => SearchAreaParam, ref searchAreaParam, value, true);
                if (!string.IsNullOrEmpty(SearchArtistParam))
                    SearchArtistParam = string.Empty;
                SearchEnable = !string.IsNullOrEmpty(value);
            }
        }

        string searchArtistParam;
        public string SearchArtistParam
        {
            get { return searchArtistParam; }
            set
            {
                Set(() => SearchArtistParam, ref searchArtistParam, value, true);
                if (!string.IsNullOrEmpty(SearchAreaParam))
                    SearchAreaParam = string.Empty;
                SearchEnable = !string.IsNullOrEmpty(value);
            }
        }

        double latitude;
        public double Latitude
        {
            get { return latitude; }
            set { Set(() => Latitude, ref latitude, value); }
        }

        double longitude;
        public double Longitude
        {
            get { return longitude; }
            set { Set(() => Longitude, ref longitude, value); }
        }

        bool useGeoLocation;
        public bool UserGeoLocation
        {
            get { return useGeoLocation; }
            set
            {
                Set(() => UserGeoLocation, ref useGeoLocation, value);
                SearchEnable = true;
            }
        }

        bool searchEnable;
        public bool SearchEnable
        {
            get { return searchEnable; }
            set { Set(() => SearchEnable, ref searchEnable, value, true); }
        }

        List<Location_Location> locations;
        public List<Location_Location> Locations
        {
            get { return locations; }
            set
            {
                Set(() => Locations, ref locations, value, true);
                if (value != null)
                    getEssentialLocations(value);
            }
        }

        List<SongKickLocationsEssential> essentialLocations;
        public List<SongKickLocationsEssential> EssentialLocations
        {
            get { return essentialLocations; }
            set { Set(() => EssentialLocations, ref essentialLocations, value, true); }
        }

        int selectedLocation;
        public int SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                Set(() => SelectedLocation, ref selectedLocation, value);
                getEventsForLocation();
            }
        }

        List<MetroAreaEvents_Event> metroAreaEvents;
        public List<MetroAreaEvents_Event> MetroAreaEvents
        {
            get { return metroAreaEvents; }
            set
            {
                if (value != null)
                    createMetroSummary(value);
                Set(() => MetroAreaEvents, ref metroAreaEvents, value, true);
            }
        }

        List<SongKickMetroAreaEssentials> metroAreaSummary;
        public List<SongKickMetroAreaEssentials> MetroAreaSummary
        {
            get { return metroAreaSummary; }
            set { Set(() => MetroAreaSummary, ref metroAreaSummary, value, true); }
        }

        List<Venues_Venue> venues;
        public List<Venues_Venue> Venues
        {
            get { return venues; }
            set { Set(() => Venues, ref venues, value, true); }
        }

        int selectedVenue;
        public int SelectedVenue
        {
            get { return selectedVenue; }
            set
            {
                Set(() => SelectedVenue, ref selectedVenue, value, true);
                searchEventsForVenue();
            }
        }

        List<ArtistSearch_Artist> artists;
        public List<ArtistSearch_Artist> Artists
        {
            get { return artists; }
            set { if (value != null) getEssentialArtists(value); Set(() => Artists, ref artists, value, true); }
        }

        List<SongKickEssentialArtist> essentialArtists;
        public List<SongKickEssentialArtist> EssentialArtists
        {
            get { return essentialArtists; }
            set { Set(() => EssentialArtists, ref essentialArtists, value, true); }
        }

        int searchArtistId;
        public int SearchArtistId
        {
            get { return searchArtistId; }
            set
            {
                Set(() => SearchArtistId, ref searchArtistId, value);
                searchArtist();
            }
        }

        List<UpcomingVenueEvents_Event> eventResult;
        public List<UpcomingVenueEvents_Event> EventResult
        {
            get { return eventResult; }
            set { Set(() => EventResult, ref eventResult, value, true); }
        }

        List<UpcomingArtistEvent_Event> upcomingArtistEvents;
        public List<UpcomingArtistEvent_Event> UpcomingArtistEvents
        {
            get { return upcomingArtistEvents; }
            set { Set(() => UpcomingArtistEvents, ref upcomingArtistEvents, value); if (value != null) getEssentialArtistEvent(value); }
        }

        List<SongKickEssentialArtistEvent> essentialArtistEvent;
        public List<SongKickEssentialArtistEvent> EssentialArtistEvent
        {
            get { return essentialArtistEvent; }
            set { Set(() => EssentialArtistEvent, ref essentialArtistEvent, value, true); }
        }

        RelayCommand cmdLocations;
        public RelayCommand CmdLocations
        {
            get
            {
                return cmdLocations ??
                    (
                        cmdLocations = new RelayCommand(async () =>
                {
                    if (UserGeoLocation)
                    {
                        await WebAPI.GetLocationSearch(Latitude, Longitude).ContinueWith((t) =>
                        {
                            if (t.IsCompleted)
                            {
                                if (!t.IsFaulted && !t.IsCanceled)
                                {
                                    Locations = t.Result.resultsPage.results.location;
                                }
                            }
                        });
                    }
                    else
                    {
                        await WebAPI.GetLocationSearch(SearchAreaParam).ContinueWith((t) =>
                        {
                            if (t.IsCompleted)
                            {
                                if (!t.IsFaulted && !t.IsCanceled)
                                {
                                    Locations = t.Result.resultsPage.results.location;
                                }
                            }
                        });
                    }
                })
                );
            }
        }

        RelayCommand cmdArtist;
        public RelayCommand CmdArtist
        {
            get
            {
                return cmdArtist ??
                    (
                        cmdArtist = new RelayCommand(async () =>
                {
                    await WebAPI.GetArtistSearch(SearchArtistParam).ContinueWith((t) =>
                    {
                        if (t.IsCompleted)
                        {
                            if (!t.IsFaulted && !t.IsCanceled)
                            {
                                Artists = t.Result.resultsPage.results.artist;
                            }
                        }
                    });
                })
                );
            }
        }

        void getEssentialArtists(List<ArtistSearch_Artist> artists)
        {
            var ess = new List<SongKickEssentialArtist>();
            foreach (var a in artists)
                ess.Add(new SongKickEssentialArtist { ArtistName = a.displayName, ArtistId = a.id, OnTourUntil = !string.IsNullOrEmpty(a.onTourUntil) ? a.onTourUntil : NotOnTour });
            EssentialArtists = ess;
        }

        void getEssentialArtistEvent(List<UpcomingArtistEvent_Event> evs)
        {
            var ess = new List<SongKickEssentialArtistEvent>();
            foreach (var ev in evs)
            {
                var es = new SongKickEssentialArtistEvent { EventType = ev.type, Venue = ev.venue.displayName, VenueCountry = ev.venue.metroArea.country.displayName, Date = ev.start.date, Time = ev.start.time };
                foreach (var p in ev.performance.Where(t => t.billing == "headline").ToList())
                {
                    es.ArtistName = p.artist.displayName;
                }
                ess.Add(es);
            }
            EssentialArtistEvent = ess;
        }

        void getEssentialLocations(List<Location_Location> locs)
        {
            var loc = new List<SongKickLocationsEssential>();
            foreach (var l in locs)
                loc.Add(new SongKickLocationsEssential { Country = l.city.country.displayName, CityName = l.city.displayName, MetroId = l.metroArea.id });
            EssentialLocations = loc;
        }

        void createMetroSummary(List<MetroAreaEvents_Event> ev)
        {
            var essential = new List<SongKickMetroAreaEssentials>();
            var lastArtistAndVenue = string.Empty;
            foreach (var e in ev)
            {
                var ess = new SongKickMetroAreaEssentials { VenueName = e.venue.displayName, City = e.location.city, Country = e.venue.metroArea.country.displayName, ConcertType = e.venue.type, Date = e.start.date, Time = e.start.time };
                var headliners = (from p in e.performance
                                  where p.billing == "headline"
                                  select p).ToList();
                foreach (var p in headliners)
                {
                    ess.Artist = p.artist.displayName;
                    if (!lastArtistAndVenue.Equals(string.Format("{0}:{1}", p.artist.displayName, e.venue.id)))
                    {
                        essential.Add(ess);
                        lastArtistAndVenue = string.Format("{0}:{1}", p.artist.displayName, e.venue.id);
                    }
                }
            }
            MetroAreaSummary = essential;
        }

        void searchEventsForVenue()
        {
            Task.Run(async () =>
            {
                await WebAPI.GetVenueUpcomingEventsCalendar(SelectedVenue).ContinueWith((t) =>
                {
                    if (t.IsCompleted)
                    {
                        if (!t.IsFaulted && !t.IsCanceled)
                        {
                            EventResult = t.Result.resultsPage.results.UpcomingVenueEvents_Event;

                        }
                    }
                });
            });
        }

        void searchArtist()
        {
            Task.Run(async () =>
            {
                await WebAPI.GetArtistUpcomingEventsCalendar(SearchArtistId).ContinueWith((t) =>
                {
                    if (t.IsCompleted)
                    {
                        if (!t.IsFaulted && !t.IsCanceled)
                        {
                            UpcomingArtistEvents = t.Result.resultsPage.results.Event;
                        }
                    }
                });
            });
        }

        void getEventsForLocation()
        {
            Task.Run(async () =>
            {
                await WebAPI.GetMetroAreaEvents(SelectedLocation).ContinueWith((t) =>
                {
                    if (t.IsCompleted)
                    {
                        if (!t.IsFaulted && !t.IsCanceled)
                        {
                            MetroAreaEvents = t.Result.resultsPage.results.MetroAreaEvents_Event;
                        }
                    }
                });
            });
        }
    }
}
