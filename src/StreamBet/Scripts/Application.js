/// <reference path="typings/tsd.d.ts" />
$(function () {
});
var Streamer;
(function (_Streamer) {
    //Local (Debug) Mode
    var apiUrl = "http://localhost:62892/api/";
    var Streamer = (function () {
        function Streamer() {
        }
        return Streamer;
    })();
    //Supply info for a specific streamer from our list of streamers
    function getStreamerInfo(id) {
        //Our list of streamers
        var streamers;
        //Selected streamer
        var streamer;
        //Get a list of our streamers from our api
        $.getJSON(apiUrl + "Streamer"), function (data) {
            streamers = data;
        };
        //Select the streamer represented by the Id
        streamer = $.map(this.streamers, function (v) {
            if (id == v.Id) {
                return v;
            }
        });
        //Request Twitch User API for streamer info
        $.getJSON("https://api.twitch.tv/kraken/channels/" + streamer.Name), function (data) {
            streamer.Status = data.status;
        };
        //Request Twitch Stream API for stream live info
        $.getJSON("https://api.twitch.tv/kraken/streams/" + streamer.Name), function (data) {
            if (data.stream) {
                streamer.IsLive = true;
            }
            else {
                streamer.IsLive = false;
            }
        };
        //Return streamer object
        return streamer;
    }
})(Streamer || (Streamer = {}));
