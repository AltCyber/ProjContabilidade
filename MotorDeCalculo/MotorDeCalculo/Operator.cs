using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDeCalculo
{
    public class Operator
    {
        // declação de variavel
        private decimal total = 0;

        // declaração de propriedade
        public string GetErro { get; set; }

        /// <summary>
        /// Retorna o processamento de calculos
        /// </summary>
        /// <param name="numbers">Lista de numeros a serem calculados</param>
        /// <param name="sinals">Lista de sinais a serem calculados</param>
        /// <returns></returns>
        public decimal ReturnResult(List<decimal> numbers, List<string> sinals)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i > 0)
                {
                    MakeOperation(sinals[i - 1], numbers[i]);
                }
                else
                {
                    // na primeira volta igualamos o total ao 
                    // primeiro numero inserido e a partir
                    // da segunda fazemos a conta de acordo
                    // com o sinal.
                    total = numbers[i];
                }
            }

            return total;
        }

        /// <summary>
        /// Soma os valores
        /// </summary>
        /// <param name="valor1">valor 1 a ser somado</param>
        /// <param name="valor2">valor 2 a ser somado</param>
        /// <returns></returns>
        public decimal Sum(decimal valor1, decimal valor2)
        {
            return valor1 + valor2;
        }

        /// <summary>
        /// Realiza a operação
        /// </summary>
        /// <param name="operacao">Qual operacao realizar</param>
        /// <param name="number">qual numero sera usado no calculo</param>
        private decimal MakeOperation(string operacao, decimal number)
        {
            // tente fazer
            try
            {
                if (operacao == "+")
                {
                    total += number;
                }
                else if (operacao == "-")
                {
                    total = total - number;
                }
                else if (operacao == "/")
                {
                    if (number == 0)
                    {
                        total = total / number;
                    }
                    else
                    {
                        throw new Exception($"Não se divide por zero!");
                    }
                }
                else if (operacao == "*")
                {
                    total = total * number;
                }
                else if (operacao == "%")
                {
                    total = number * (total / 100);
                }
                else if (operacao == "=")
                {
                    return total;
                }
                else if (operacao == "EX")
                {
                    return (decimal)Math.Pow((double)total, (double)number);
                }

                return total;
            }
            catch (Exception ex)
            {
                // so passa se der erro
                throw new Exception($"ocorreu erro:{ex}");
            }
        }
    }
}
