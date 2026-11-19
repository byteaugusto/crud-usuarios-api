namespace MinhaPrimeiraApi.Results
{
    public class ResultadoAtualizacao
    {
        public string Message { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
        public TipoErroAtualizacao TipoErro { get; set; }
        public ResultadoAtualizacao(string message, Usuario? usuario, TipoErroAtualizacao tipoErro) 
        {
                this.Message = message;
                this.Usuario = usuario;
                this.TipoErro = tipoErro;
        }
        
    }
}
