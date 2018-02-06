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
        public Double? EquazX1 { get; set; }
        public Double? EquazX2 { get; set; }
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

            // Se ho tutti e tre i parametri, è un'equazione di secondo grado completa
            // quindi calcolo il delta
            if (A != 0 && B != 0 && C != 0)
            {
                // Delta = B^2 - 4AB
                response.Delta = Math.Pow(B, 2) - 4 * A * C;

                if (response.Delta > 0)
                {
                    // Due soluzioni distinte
                    response.EquazX1 = (-B - Math.Sqrt(response.Delta)) / (2 * A);
                    response.EquazX2 = (-B + Math.Sqrt(response.Delta)) / (2 * A);
                }
                else
                {
                    if (response.Delta == 0)
                    {
                        // Due soluzioni coincidenti
                        response.EquazX1 = response.EquazX2 = -B / (2 * A);
                    }
                    else
                        // Nessuna soluzione possibile
                        response.EquazX1 = response.EquazX2 = null;
                }
            }
            else
            {
                if (B == 0 && C == 0)
                {
                    response.EquazX1 = response.EquazX2 = 0;
                }
                else
                {
                    if (B == 0)
                    {
                        if (-C / A > 0)
                        {
                            response.EquazX1 = -Math.Sqrt(B / A);
                            response.EquazX2 = Math.Sqrt(B / A);
                        }
                        else
                            // Nessuna soluzione possibile
                            response.EquazX1 = response.EquazX2 = null;
                    }
                    else
                    {
                        response.EquazX1 = 0;
                        response.EquazX2 = -B / A;
                    }
                }
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