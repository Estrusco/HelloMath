using System;
using System.Drawing;

namespace HelloMath.Models
{
    public class ParabolaRequest
    {
        public Double? ParamA { get; set; }
        public Double? ParamB { get; set; }
        public Double? ParamC { get; set; }
    }

    public class ParabolaResponse
    {
        public PointF Vertice { get; set; }
        public PointF Fuoco { get; set; }
        public Double Direttrice { get; set; }
        public Double Asse { get; set; }
        public Double Delta { get; set; }
    }

    public class Parabola
    {
        public ParabolaResponse Parametri { get; private set; }

        /// <summary>
        /// Parametro A = 
        /// </summary>
        private Double A = 0;
        private Double B = 0;
        private Double C = 0;

        public Parabola(ParabolaRequest request)
        {
            if (request.ParamA.HasValue)
                A = request.ParamA.Value;
            if (request.ParamB.HasValue)
                B = request.ParamB.Value;
            if (request.ParamC.HasValue)
                C = request.ParamC.Value;

            Parametri = Calcola();
        }

        public ParabolaResponse Calcola()
        {
            var response = new ParabolaResponse();

            // Se ho tutti e tre i parametri, è un'equazione di secondo grado normale
            // quindi calcolo il delta
            if (A != 0 && B != 0 && C != 0)
            {
                // Delta = B^2 - 4AB
                response.Delta = Math.Pow(B, 2) - 4 * A * C;
            }

            response.Vertice = new PointF
            {
                // X = -B / 2A
                X = -(float)B / (float)(2 * A),
                // Y = -Delta / 4A
                Y = -(float)response.Delta / (float)(4 * A)
            };

            response.Fuoco = new PointF
            {
                // X = -B / 2A
                X = response.Vertice.X,
                // Y = 1 - Delta / 4A
                Y = 1 - (float)response.Delta / (float)(4 * A)
            };

            // Y = -1 - Delta / 4A
            response.Direttrice = -1 - response.Delta / (4 * A);
            response.Asse = -B / (2 * A);

            Parametri = response;

            return response;
        }
    }
}