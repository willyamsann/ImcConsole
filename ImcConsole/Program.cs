using ImcConsole.Models;
using System;
using System.Collections.Generic;

namespace ImcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IMC");

            
            var tam = 2;
            var listParticipante = new List<Participante>();


            for (var x =0; x< tam; x++)
            {
                var participante = new Participante();

                participante.Name = Console.ReadLine();
                participante.Altura = Convert.ToDouble(Console.ReadLine());
                participante.Peso = Convert.ToDouble(Console.ReadLine());
                participante.Imc = CalculateImc(participante.Peso, participante.Altura);

                listParticipante.Add(participante);
            }

            foreach(var alt in listParticipante)
            {
                Console.WriteLine("Participante: " + alt.Name + "Seu IMC foi: " + alt.Imc);
            }

            var results = ResultImc(listParticipante);

            foreach(var alt in results)
            {
                Console.WriteLine("Tipo: " + alt.TypeResult + "Imc: " + alt.Participante.Imc + "Nome: " + alt.Participante.Name);
            }
        }

        public static double CalculateImc(double peso, double altura)
        {
            var result = peso / (altura * altura);

            return result;
        }

        public static List<ResultImc> ResultImc(List<Participante> participantes)
        {
            double auxMenor = 0;
            double auxMaior = 0;

            var resultMenor = new ResultImc();
            var resultMaior = new ResultImc();

            foreach (var alt in participantes)
            {
                if (alt.Imc  >=  auxMaior)
                {
                    auxMaior = alt.Imc;
                    resultMaior.TypeResult = Models.ResultImc.Type.Maior;
                    resultMaior.Participante = alt;
                    
                }

                if (auxMenor == 0)
                {
                    auxMenor = alt.Imc;
                    resultMenor.TypeResult = Models.ResultImc.Type.Menor;
                    resultMenor.Participante = alt;
                }


                if (alt.Imc <= auxMenor)
                {
                    auxMenor = alt.Imc;
                    resultMenor.TypeResult = Models.ResultImc.Type.Menor;
                    resultMenor.Participante = alt;
                }


            }

            var results = new List<ResultImc>();

            results.Add(resultMenor);
            results.Add(resultMaior);

            return results;
        }
    }
}
