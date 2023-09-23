namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public string TipoSuite { get; private set; }
        public uint Capacidade { get; private set; }
        public decimal ValorDiaria { get; private set; }
        public bool Disponivel { get; private set; }

        public Suite(string tipoSuite, uint capacidade, decimal valorDiaria, bool disponivel = true)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            Disponivel = disponivel;
        }

        public void RealizarCheckOut()
        {
            Disponivel = true;
        }
    }
}