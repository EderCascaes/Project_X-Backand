using Project_X.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X.Domain.Static
{
    public static class Funcoes
    {


        public static bool ValidaCpf(this string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)

                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }

        public static string RetornaNumeros(this string alvo) => alvo.Replace(".", "").Replace("-", "").Replace("/", "").Replace("(", "").Replace(")", "");

        public static string FormatCPF(string CPF) => Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");       



        public static List<int> GetListaFuncoes(this int[] codigos)
        {
            var listaFuncooes = new List<int>();
            foreach (var item in codigos)
                    listaFuncooes.Add(item);
            
            return listaFuncooes;
        }

        public static  string AplicarMascaraTelefone(string strNumero)
        {
            // por omissão tem 10 ou menos dígitos
            string strMascara = "{0:(00)0000-0000}";
            // converter o texto em número
            long lngNumero = Convert.ToInt64(strNumero);

            if (strNumero.Length == 11)
                strMascara = "{0:(00)00000-0000}";

            return string.Format(strMascara, lngNumero);
        }

        public static string FormatarData(this string data)
        {
            var dia = data.Substring(0, 2);
            var mes = data.Substring(2, 2);
            var ano = data.Substring(4,4);

            return ano + "/" + mes + "/" + dia;
        }

        public static string ClearWord(this string word) => word.Replace("\\", "").Replace("\"", "").ToLower();
        
    }
}
