using Project_X.Interface.Services;
using System.Text;

namespace Project_X.Sevice.Services
{
    public class PasswordService : IPasswordService
    {
        public PasswordService() { }

        public char[] chars = { 'f', 'f', 'x', '#', '$', 'f', 'f', 'x', '#', '$' };

        public string Codification(string password)
        {
               
            string chave = new string(chars, 0, 10);
            var dados = "*/*" + password + chave;

            byte[] textoAsBytes = Encoding.ASCII.GetBytes(dados);
            string resultado = System.Convert.ToBase64String(textoAsBytes);       

            return resultado;
        }

        public string Decode(string passaord )
        {
            byte[] dadosAsBytes = System.Convert.FromBase64String(passaord);
            string descodificado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);

            string stringchar = descodificado.TrimEnd(chars);
            var stringFinal = stringchar.Split("*/*");

            return stringFinal[1];
        }
    }
}
