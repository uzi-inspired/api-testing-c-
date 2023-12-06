using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Replace "your_api_url" with the actual URL of the API endpoint you want to test
        string apiUrl = "your_api_url";

        // Create an instance of HttpClient
        using (HttpClient httpClient = new HttpClient())
        {
            // Create some sample data to send in the POST request (replace as needed)
            string requestData = "{ \"key\": \"value\" }";

            // Create a StringContent with the data
            StringContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            try
            {
                // Make the POST request
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful (status code in the 2xx range)
                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Output the response data
                    Console.WriteLine("Response from the API:");
                    Console.WriteLine(responseData);
                }
                else
                {
                    // Output the error status code and reason phrase
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}