using HelloMath.Models;
using Microsoft.AspNet.SignalR;

namespace HelloMath.Hubs
{
    public class ParabolaHub : Hub
    {
        public void Sviluppa(double? paramA, double? paramB, double? paramC)
        {
            var request = new ParabolaRequest
            {
                ParamA = paramA,
                ParamB = paramB,
                ParamC = paramC
            };

            var p = new Parabola(request);
            Clients.Caller.ParabolaUpdate();
        }
    }
}