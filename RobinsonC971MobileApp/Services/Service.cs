using RobinsonC971MobileApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobinsonC971MobileApp.Services
{
    public class Service
    {
        private static SQLiteAsyncConnection db;

        public Service(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Term>();
            db.CreateTableAsync<Course>();
            db.CreateTableAsync<Assessment>();
        }

        public Task<List<Course>> CourseList()
        {
            return db.Table<Course>().ToListAsync();
        }
        public Task<List<Assessment>> AssessmentList()
        {
            return db.Table<Assessment>().ToListAsync();
        }
        public Task<List<Term>> GetTermList()
        {
            return db.Table<Term>().ToListAsync();
        }

        public Task<int> AddTerm(Term term)
        {
            return db.InsertAsync(term);
        }

        public void EditTerm(Term term)
        {
            db.UpdateAsync(term);
        }

        public void DeleteTerm(Term term)
        {
            db.DeleteAsync(term);
        }
        public List<Course> GetCourses(Term term)
        {
            var list = db.Table<Course>().ToListAsync().Result;
            return list.Where(course => course.TermId == term.Id).ToList();
        }

        public Task<int> AddCourse(Course course)
        {
            return db.InsertAsync(course);
        }

        public void UpdateCourse(Course course)
        {
            db.UpdateAsync(course);
        }

        public void DropCourse(Course course)
        {
            db.DeleteAsync(course);
        }
        public void AddAssessment(Assessment assessment)
        {
             db.InsertAsync(assessment);
        }
        public List<Assessment> GetAssessments(int courseID)
        {
            var list = db.Table<Assessment>().ToListAsync();
            return list.Result.Where(assessment => assessment.CourseID == courseID).ToList();
        }

        public void UpdateAssessment(Assessment assessment)
        {
            db.UpdateAsync(assessment);
        }

        public void DeleteAssessment(Assessment assessment)
        {
            db.DeleteAsync(assessment);
        }
    }
}
