using Microsoft.AspNetCore.SignalR;

namespace SignalRImplementation.Utilities
{
    public class RealTimeHub : Hub
    {
        public async Task SendRealTimeData(string data)
        {
            try
            {
                if (data != null)
                {
                    if (Clients != null)
                    {
                        if (Clients.All != null)
                        {
                            await Clients.All.SendAsync("ReceiveRealTimeData", data);
                        }
                        else
                        {
                            Console.WriteLine("Clients.All is Null");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Client is null");
                    }
                }
                else
                {
                    Console.WriteLine("data is null");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
