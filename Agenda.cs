using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whatssapp_31
{
    public class Agenda : IAgenda
    {
        public List<Contato> contatos;
        private const string PATH = "Database/Contatos.CSV";

        public Agenda()
        {

        }

        /// <summary>
        /// Cadastra  o contato na linha do CSV
        /// </summary>
        /// <param name="ctt"></param>
        public void Cadastrar(Contato ctt)
        {
            var linha = new string[] {PrepararLinha(ctt)};
            File.AppendAllLines(PATH, linha);
        }


        public void Excluir(string excl)
        {
            List<string> linhas = new List<string>();

            using(StreamReader file = new StreamReader(PATH))
            {
                string Linha;
                while((Linha = file.ReadLine()) != null)
                {
                    linhas.Add(Linha);
                }
            }

            linhas.RemoveAll(l => l.Contains(excl));

            ReescreverCSV(linhas);
            
        }


        public List<Contato> Listar()
        {
            
            List<Contato> lista = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            lista = lista.OrderBy(x => x    .Nome).ToList();
            return lista;
        }

        private string PrepararLinha(Contato c)
        {
            return $"Nome: {c.Nome} ; Telefone: {c.Telefone}";
        }

             
        private void ReescreverCSV(List<string> lines)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }

    }
}