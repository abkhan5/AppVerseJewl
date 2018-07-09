namespace AppVerse.Jewel.Entities
{
    public class DepthFile
    {
        private  Reservoir _reservoir;

        public DepthFile(string filePath, string fileName,  FileFormat fileFormat)
        {
            FileLoadProgress= new AppProgress();
            FilePath = filePath;
            TopHorizon = new Horizon (16,26);
            FileLoadProgress.ProgressOf = fileName;
            FileLoadProgress.Max = 16 * 26;
            Format = fileFormat;
        }

        public string Volume { get; set; }
        public string FilePath { get; set; }

        public string FileName => FileLoadProgress?.ProgressOf;

        public FileFormat Format { get; set; }

        public AppProgress FileLoadProgress { get; set; }

        public Horizon TopHorizon { get; set; }


        public Reservoir Reservoir => _reservoir??(_reservoir= new Reservoir(TopHorizon));
    }
}