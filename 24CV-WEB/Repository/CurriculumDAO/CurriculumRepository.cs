using _24CV_WEB.Models;

namespace _24CV_WEB.Repository.CurriculumDAO
{
    public class CurriculumRepository
    {
        private readonly ApplicationDbContext _context;

        public CurriculumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Curriculum> GetAll()
        {
            return _context.Curriculums.ToList();
        }

        public int Create(Curriculum model)
        {
            _context.Curriculums.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Curriculum model)
        {
            _context.Curriculums.Update(model); 
            return _context.SaveChanges();
        }

        public Curriculum GetById(int id)
        {
            var curriculum = _context.Curriculums.Find(id);

            return curriculum;
            //var curriculum = _context.Curriculums.FirstOrDefault(x => x.Id == id);
            //var curriculum = _context.Curriculums.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Delete(int id)
        {
			var curriculum = _context.Curriculums.Find(id);

            _context.Curriculums.Remove(curriculum);

            return _context.SaveChanges();  
		}
    }
}
