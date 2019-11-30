namespace P01.Stream_Progress
{
    public class File : IStream
    {
        public string Name { get; }

        public File(int length, int bytesSent)
        {
            this.Length = length;
            this.BytesSent = bytesSent;
        }        

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
