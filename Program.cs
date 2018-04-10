using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace FXCMRestAPIExample
{
    public class Program
    {
        const string BASE_URL = "https://api-demo.fxcm.com:443";
        const string TOKEN = "YOUR_FXCM_TOKEN";

        private static readonly IFXCMCandleParser _candleParser = new FXCMCandleParser();
        private static readonly IFXCMResponseParser _responseParser = new FXCMResponseParser();

        public static void Main(string[] args)
        {    
            string bearer_token = string.Empty;

            var options = new IO.Options
            {
                ForceNew = true,
                Query = new Dictionary<string, string> { { "access_token", TOKEN } }
            };

            var socket = IO.Socket(BASE_URL, options);
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                bearer_token = "Bearer " + socket.Io().EngineSocket.Id + TOKEN;
                OnConnect(bearer_token);
            });

            socket.On(Socket.EVENT_CONNECT_ERROR, (error) =>
            {
                OnConnectError(error);
            });

            Console.ReadKey();
        }

        private static void OnConnectError(object error)
        {
            Console.WriteLine($"Error {error.ToString()} ");
        }

        private static void OnConnect(string bearer_token)
        {
            var instruments = _responseParser.Parse<FXCMOfferResponse>(GetRawResponse("/trading/get_model/?models=Offer", bearer_token)).Offers;
            var queryString = ConstructHistoryRequestString(instruments.Single(o => o.Currency == "USD/JPY").OfferId, "m5", 2200);
            var fxcmResponse = _responseParser.Parse<FXCMCandlesResponse>(GetRawResponse(queryString, bearer_token));

            if (fxcmResponse.Metadata.Executed)
            {
                var candles = _candleParser.ParseCandles(fxcmResponse);
                candles.ForEach(candle => Console.WriteLine(candle.ToString()));
            }
            else
            {
                Console.WriteLine($"Failed to fetch data from FXCM. Error: {fxcmResponse.Metadata.Error}");
            }
        }

        private static string GetRawResponse(string queryString, string bearer_token)
        {
            string stringResponse;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", bearer_token);
                httpClient.BaseAddress = new Uri(BASE_URL);

                stringResponse = httpClient.GetStringAsync(queryString).Result;
            }

            return stringResponse;
        }

        private static string ConstructHistoryRequestString(int instrument, string period, int numberOfCandles, int? fromTime = null, int? toTime = null)
        {
            var queryString = $"/candles/{instrument}/{period}?num={numberOfCandles}";

            if (fromTime != null) queryString = queryString + $"&from={fromTime}";
            if (toTime != null) queryString = queryString + $"&to={toTime}";

            return queryString;
        }
    }
}
