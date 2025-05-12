namespace todo_backend.Utils.Reponses
{
    /// <summary>
    /// Esta es la clase que se encarga de crear la respuesta de la API o internamente 
    /// haciendo que respuestas sean estandarizadas.
    public class Response
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public object? DataResponse { get; set; }
        public Response(bool status, string statusMessage, Object? dataResponse = null)
        {
            Status = status;
            StatusMessage = statusMessage;
            DataResponse = dataResponse;
        }
    }

}
