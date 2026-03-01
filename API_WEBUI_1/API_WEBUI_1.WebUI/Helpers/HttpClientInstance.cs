namespace API_WEBUI_1.WebUI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7042/api/");
            
            return client;
        }
    }
}
