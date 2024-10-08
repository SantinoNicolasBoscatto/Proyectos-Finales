namespace ServiPryntWeb.Models.Repositorio.Abstractas
{
    public interface IFileService
    {
        public Tuple<int, string> SaveFile(IFormFile File, string savePlace, string ext);
        public bool DeleteFile(string FileName, string savePlace);
    }
}
