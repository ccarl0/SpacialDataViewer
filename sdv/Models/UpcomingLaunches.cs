using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sdv.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    public class Core
    {
        [JsonPropertyName("core")]
        public string CoreAPI { get; set; }

        [JsonPropertyName("flight")]
        public int? Flight { get; set; }

        [JsonPropertyName("gridfins")]
        public bool? Gridfins { get; set; }

        [JsonPropertyName("legs")]
        public bool? Legs { get; set; }

        [JsonPropertyName("reused")]
        public bool? Reused { get; set; }

        [JsonPropertyName("landing_attempt")]
        public object LandingAttempt { get; set; }

        [JsonPropertyName("landing_success")]
        public object LandingSuccess { get; set; }

        [JsonPropertyName("landing_type")]
        public object LandingType { get; set; }

        [JsonPropertyName("landpad")]
        public object Landpad { get; set; }
    }

    public class Fairings
    {
        [JsonPropertyName("reused")]
        public object Reused { get; set; }

        [JsonPropertyName("recovery_attempt")]
        public object RecoveryAttempt { get; set; }

        [JsonPropertyName("recovered")]
        public object Recovered { get; set; }

        [JsonPropertyName("ships")]
        public List<object> Ships { get; set; }
    }

    public class Flickr
    {
        [JsonPropertyName("small")]
        public List<object> Small { get; set; }

        [JsonPropertyName("original")]
        public List<object> Original { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("patch")]
        public Patch Patch { get; set; }

        [JsonPropertyName("reddit")]
        public Reddit Reddit { get; set; }

        [JsonPropertyName("flickr")]
        public Flickr Flickr { get; set; }

        [JsonPropertyName("presskit")]
        public object Presskit { get; set; }

        [JsonPropertyName("webcast")]
        public string Webcast { get; set; }

        [JsonPropertyName("youtube_id")]
        public string YoutubeId { get; set; }

        [JsonPropertyName("article")]
        public object Article { get; set; }

        [JsonPropertyName("wikipedia")]
        public object Wikipedia { get; set; }
    }

    public class Patch
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }
    }

    public class Reddit
    {
        [JsonPropertyName("campaign")]
        public string Campaign { get; set; }

        [JsonPropertyName("launch")]
        public object Launch { get; set; }

        [JsonPropertyName("media")]
        public object Media { get; set; }

        [JsonPropertyName("recovery")]
        public string Recovery { get; set; }
    }

    public class UpcomingLaunchesRoot
    {
        [JsonPropertyName("fairings")]
        public Fairings Fairings { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("static_fire_date_utc")]
        public object StaticFireDateUtc { get; set; }

        [JsonPropertyName("static_fire_date_unix")]
        public object StaticFireDateUnix { get; set; }

        [JsonPropertyName("net")]
        public bool? Net { get; set; }

        [JsonPropertyName("window")]
        public object Window { get; set; }

        [JsonPropertyName("rocket")]
        public string Rocket { get; set; }

        [JsonPropertyName("success")]
        public object Success { get; set; }

        [JsonPropertyName("failures")]
        public List<object> Failures { get; set; }

        [JsonPropertyName("details")]
        public object Details { get; set; }

        [JsonPropertyName("crew")]
        public List<object> Crew { get; set; }

        [JsonPropertyName("ships")]
        public List<object> Ships { get; set; }

        [JsonPropertyName("capsules")]
        public List<object> Capsules { get; set; }

        [JsonPropertyName("payloads")]
        public List<string> Payloads { get; set; }

        [JsonPropertyName("launchpad")]
        public string Launchpad { get; set; }

        [JsonPropertyName("flight_number")]
        public int? FlightNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date_utc")]
        public DateTime? DateUtc { get; set; }

        [JsonPropertyName("date_unix")]
        public int? DateUnix { get; set; }

        [JsonPropertyName("date_local")]
        public DateTime? DateLocal { get; set; }

        [JsonPropertyName("date_precision")]
        public string DatePrecision { get; set; }

        [JsonPropertyName("upcoming")]
        public bool? Upcoming { get; set; }

        [JsonPropertyName("cores")]
        public List<Core> Cores { get; set; }

        [JsonPropertyName("auto_update")]
        public bool? AutoUpdate { get; set; }

        [JsonPropertyName("tbd")]
        public bool? Tbd { get; set; }

        [JsonPropertyName("launch_library_id")]
        public string LaunchLibraryId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }



}
