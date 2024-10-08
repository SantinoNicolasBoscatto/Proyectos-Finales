using ServiPryntWeb.Models.Repositorio.Abstractas;

namespace ServiPryntWeb.Models.Repositorio.Implementadas
{
    public class FileService : IFileService
    {

        private readonly IWebHostEnvironment env;
        public FileService(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public bool DeleteFile(string FileName, string savePlace)
        {
            var path = env.WebRootPath;
            path = Path.Combine(path, savePlace + "\\" + FileName);
            if (!File.Exists(path)) return false;
            File.Delete(path);
            return true;
        }

        public Tuple<int, string> SaveFile(IFormFile File, string savePlace, string extension)
        {
            var path = env.WebRootPath;
            path = Path.Combine(path, savePlace);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var ext = Path.GetExtension(File.FileName);
            var allowedExtensions = extension;
            if(!allowedExtensions.Contains(ext)) return new Tuple<int, string>(0, "Error Formato de Imagen Incorrecto");
            var fileNewName = Guid.NewGuid().ToString() + ext;
            var fileWithPath = Path.Combine(path, fileNewName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            File.CopyTo(stream);
            stream.Close();
            return new Tuple<int, string>(1, fileNewName);
        }
    }
}
