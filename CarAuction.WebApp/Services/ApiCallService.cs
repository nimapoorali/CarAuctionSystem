using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using CarAuction.WebApp.Models;

namespace CarAuction.WebApp.Services
{
    public class ApiCallService
    {
        //Used for calling the api services
        public HttpClient Client { get; }

        public ApiCallService(HttpClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Calls the api service based on the http method with returning content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpMethod"></param>
        /// <param name="url">The api service url</param>
        /// <param name="content">the content should be sent to server</param>
        /// <returns></returns>
        /// <exception cref="ApiCallException"></exception>
        /// <exception cref="Exception"></exception>
        private async Task<T?> CallAsync<T>(HttpMethod httpMethod, string url, object? content = null) where T : class
        {
            try
            {
                var request = new HttpRequestMessage(httpMethod, url);

                //Set json body content
                if (content is not null)
                {
                    var jsonContent = JsonSerializer.Serialize(content);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                var callResult = await Client.SendAsync(request);

                string responseBody = await callResult.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseBody))
                    throw new ApiCallException
                    {
                        ErrorMessages = new string[] {
                        $"{callResult.StatusCode.ToString()} [{int.Parse(callResult.StatusCode.ToString())}]" }
                    };// callResult.StatusCode.ToString() + " [" + Convert.ToInt32(callResult.StatusCode) + "]" } };

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                
                //Transforming the response body json to the regarding object
                var result = JsonSerializer.Deserialize<CleanResult<T>>(responseBody, options);
                if (result is not null)
                    if (result.IsSuccess)
                        return result.Value;
                    else
                        throw new ApiCallException { ErrorMessages = result.Errors.ToArray() };

                return null;
            }
            catch (ApiCallException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during calling the api.", ex);
            }
        }

        /// <summary>
        /// Calls the api service based on the http method without returning content
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="url">The api service url</param>
        /// <param name="content">the content should be sent to server</param>
        /// <returns>True if the service called successfully</returns>
        /// <exception cref="ApiCallException"></exception>
        /// <exception cref="Exception"></exception>
        private async Task<bool> CallAsync(HttpMethod httpMethod, string url, object? content = null)
        {
            try
            {
                var request = new HttpRequestMessage(httpMethod, url);

                if (content is not null)
                {
                    var jsonContent = JsonSerializer.Serialize(content);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                var callResult = await Client.SendAsync(request);

                string responseBody = await callResult.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseBody))
                    throw new ApiCallException { ErrorMessages = new string[] { callResult.StatusCode.ToString() } };

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<CleanResult>(responseBody, options);
                if (result is not null)
                    if (result.IsSuccess)
                        return true;
                    else
                        throw new ApiCallException { ErrorMessages = result.Errors.ToArray() };

                return false;
            }
            catch (ApiCallException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during calling the api.", ex);
            }
        }

        /// <summary>
        /// Calls api service with Get http method and returns content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<T?> GetAsync<T>(string url) where T : class
        {
            return CallAsync<T>(HttpMethod.Get, url);
        }


        /// <summary>
        /// Calls api service with Delete http method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(string url, object? content = null)
        {
            return CallAsync(HttpMethod.Delete, url);
        }

        /// <summary>
        /// Calls api service with Post http method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<bool> PostAsync(string url, object? content = null)
        {
            return CallAsync(HttpMethod.Post, url);
        }

        /// <summary>
        /// Calls api service with Delete http method and returns content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<T?> PostAsync<T>(string url, object? content = null) where T : class
        {
            return CallAsync<T>(HttpMethod.Post, url);
        }

        /// <summary>
        /// Calls api service with Put http method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<bool> PutAsync(string url, object content)
        {
            return CallAsync(HttpMethod.Put, url);
        }

        /// <summary>
        /// Calls api service with Delete http method and returns content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<T?> PutAsync<T>(string url, object content) where T : class
        {
            return CallAsync<T>(HttpMethod.Put, url);
        }

        /// <summary>
        /// Calls api service with Patch http method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<bool> PatchAsync(string url, object? content = null)
        {
            return CallAsync(HttpMethod.Patch, url);
        }

        /// <summary>
        /// Calls api service with Delete http method and returns content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<T?> PatchAsync<T>(string url, object? content = null) where T : class
        {
            return CallAsync<T>(HttpMethod.Patch, url);
        }
    }
}
