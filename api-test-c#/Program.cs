using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://reqres.in/api/users";

        using (HttpClient httpClient = new HttpClient())
        {
            string requestData = "{ \"name\": \"Bob\" }";

            StringContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Response from the API:");
                    Console.WriteLine(responseData);

                    // Assert.AreEqual("ExpectedResponse", responseData);
                
                    
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}