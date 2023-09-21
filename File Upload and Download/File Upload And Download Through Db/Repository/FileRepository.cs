using File_Upload_And_Download_Through_Db.Data;
using File_Upload_And_Download_Through_Db.Interface;
using File_Upload_And_Download_Through_Db.Model;
using Microsoft.EntityFrameworkCore;

namespace File_Upload_And_Download_Through_Db.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _dbContext;
        public FileRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FileEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Files.FindAsync(id);
        }

        public async Task<List<FileEntity>> GetAllAsync()
        {
            return await _dbContext.Files.ToListAsync();
        }

        public async Task AddAsync(FileEntity file)
        {
            _dbContext.Files.Add(file);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(FileEntity file)
        {
            _dbContext.Files.Update(file);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int fileId)
        {
            var file = await _dbContext.Files.FindAsync(fileId);
            if (file != null)
            {
                _dbContext.Files.Remove(file);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
