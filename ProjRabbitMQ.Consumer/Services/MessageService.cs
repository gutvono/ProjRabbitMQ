using Newtonsoft.Json;
using ProjRabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjRabbitMQ.Consumer.Services
{
    public class MessageService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<Message> PostMessage(Message msg)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await MessageService._httpClient.PostAsync("https://localhost:7154/api/Messages", content);
                response.EnsureSuccessStatusCode();
                string msgReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message>(msgReturn);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
