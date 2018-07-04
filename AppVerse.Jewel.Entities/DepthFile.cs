namespace AppVerse.Jewel.Entities
{
    public class DepthFile
    {
        public DepthFile(string filePath, string fileName,  FileFormat fileFormat)
        {
            FileLoadProgress= new AppProgress();
            FilePath = filePath;
            TopHorizon = new Horizon (16,26);
            FileLoadProgress.ProgressOf = fileName;
            FileLoadProgress.Max = 16 * 26;
            Format = fileFormat;
        }


        public string FilePath { get; set; }

        public FileFormat Format { get; set; }

        public AppProgress FileLoadProgress { get; set; }

        public Horizon TopHorizon { get; set; }

    }
}