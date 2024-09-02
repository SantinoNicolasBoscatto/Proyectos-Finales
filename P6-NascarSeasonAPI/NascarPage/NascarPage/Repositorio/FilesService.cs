using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface IFilesService
    {
        Task Borrar(string? ruta, string contenedor);
        Task<string> GuardarImagen(string contenedor, IFormFile file);
        async Task<string> Editar(string? ruta, string contenedor, IFormFile file)
        {
            await Borrar(ruta, contenedor);
            return await GuardarImagen(contenedor, file);
        }
    }

    public class FilesService : IFilesService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public FilesService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GuardarImagen(string carpeta, IFormFile file)
        {
            var extensionFile = Path.GetExtension(file.FileName);
            var newFileName = $"{Guid.NewGuid()}{extensionFile}";
            string folder = Path.Combine(webHostEnvironment.WebRootPath, carpeta);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            string ruta = Path.Combine(folder, newFileName);
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }
            var url = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";
            var urlArchivo = Path.Combine(url, carpeta, newFileName).Replace('\\', '/');
            return urlArchivo;
        }

        public Task Borrar(string? ruta, string carpeta)
        {
            if (string.IsNullOrWhiteSpace(ruta)) return Task.CompletedTask;

            var fileName = Path.GetFileName(ruta);
            var directory = Path.Combine(webHostEnvironment.WebRootPath, carpeta, fileName);
            if (File.Exists(directory)) File.Delete(directory);
            return Task.CompletedTask;
        }
    }
}
