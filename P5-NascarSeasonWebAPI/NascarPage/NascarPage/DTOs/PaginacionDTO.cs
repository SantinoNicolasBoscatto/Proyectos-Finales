namespace NascarPage.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        public int RecordsPorPagina
        {
            get { return recordsPorPagina; }
            set { recordsPorPagina = value > maxrecordsPorPagina ? maxrecordsPorPagina : value; }
        }
        private int recordsPorPagina = 15;
        private readonly int maxrecordsPorPagina = 45;
    }
}
