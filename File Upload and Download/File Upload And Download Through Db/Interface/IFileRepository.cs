using File_Upload_And_Download_Through_Db.Model;

namespace File_Upload_And_Download_Through_Db.Interface
{
    public interface IFileRepository
    {
        Task<FileEntity> GetByIdAsync(int id);
        Task<List<FileEntity>> GetAllAsync();
        Task AddAsync(FileEntity file);
        Task UpdateAsync(FileEntity file);
        Task DeleteAsync(int id);

    }
}
