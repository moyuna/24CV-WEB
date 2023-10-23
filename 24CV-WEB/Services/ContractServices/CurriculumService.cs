using _24CV_WEB.Models;
using _24CV_WEB.Repository;
using _24CV_WEB.Repository.CurriculumDAO;
using _24CV_WEB.Services.Contracts;
using System.Reflection.Metadata;

namespace _24CV_WEB.Services.ContractServices
{
	public class CurriculumService : ICurriculumService
	{
		private CurriculumRepository _repository;

        public CurriculumService(ApplicationDbContext context)
        {
            _repository = new CurriculumRepository(context);
        }

        public async Task<ResponseHelper> Create(Curriculum model)
		{
			ResponseHelper responseHelper = new ResponseHelper();

			try
			{
				string filePath="";

                if (model.Foto != null && model.Foto.Length > 0)
				{
					string fileName = Path.GetFileName(model.Foto.FileName);
					filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Fotos", fileName);
				}

				model.RutaFoto = filePath;

				//Copia el archivo en un directorio
				using (var fileStream = new FileStream(filePath,FileMode.Create))
				{
					await model.Foto.CopyToAsync(fileStream);
				}

				if (_repository.Create(model) > 0)
				{
					responseHelper.Success = true;
					responseHelper.Message = $"Se agregó el curriculum de {model.Nombre} con éxito.";
				}
				else
				{
					responseHelper.Message = "Ocurrió un error al agregar el dato.";
				}
			}
			catch (Exception e)
			{
				responseHelper.Message = $"Ocurrió un error al agregar el dato. Error: {e.Message}";
			}


			return responseHelper;	
		}

		public ResponseHelper Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Curriculum> GetAll()
		{
			List<Curriculum> list = new List<Curriculum>();

			try
			{
				list = _repository.GetAll();
			}
			catch (Exception e)
			{

				throw;
			}

			return list;
		}

		public Curriculum GetById(int id)
		{
			throw new NotImplementedException();
		}

		public ResponseHelper Update(Curriculum model)
		{
			throw new NotImplementedException();
		}
	}
}
