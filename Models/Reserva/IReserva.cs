namespace DesafioProjetoHospedagem.Models
{
    public interface IReserva
    {
        /// <summary>
        /// Incluir a lista de hospedes na reserva.
        /// </summary>
        /// <param name="hospedes"></param>
        /// <exception cref="ArgumentNullException">Exception ocorre quando a lista de hospedes for nula ou com quantidade igual a 0 (zero).</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception ocorre quando a lista de hospedes possuir quantidade de hospedes além da capacidade da Suíte.</exception>
        public void CadastrarHospedes(IEnumerable<Pessoa> hospedes);

        /// <summary>
        /// Inclui a suíte na reserva.
        /// </summary>
        /// <param name="suite"></param>
        /// <exception cref="ArgumentNullException">Exception ocorre quando a lista for nula ou vazia.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception ocorre quando o estado da suíte for indisponível.</exception>
        public void CadastrarSuite(Suite suite);
        public int ObterQuantidadeHospedes();
        public decimal CalcularValorDiaria();        
    }
}