namespace File_Upload_And_Download_Through_Db.Model
{
    public class FileEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
