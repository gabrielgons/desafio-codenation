using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace desafio_codenation
{
    class DescriptografadorDeJulioCesar
    {
        private long Deslocamento;
        private string Texto;
        private List<char> Alfabeto = "abcdefghijklmnopqrstuvwxyz".ToList();
        public DescriptografadorDeJulioCesar(long deslocamento, string texto)
        {
            Texto = texto;
            Deslocamento = deslocamento;
        }

        public string Descriptografar()
        {
            string textoDescriptografado = string.Empty;

            foreach(var letra in Texto)
            {
                var posicao = Alfabeto.FindIndex(x => x == letra);
                textoDescriptografado += (posicao >= 0? Alfabeto[GetPosicao(posicao)] :  letra);
            }

            return textoDescriptografado;
        }

        private int GetPosicao(long posicaoAtual)
        {
            long posicao = posicaoAtual - Deslocamento;

            return (int)(posicao >= 0 ? posicao : Alfabeto.Count - (posicao * -1));
        }
    }
}
