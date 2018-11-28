using FileTypeChecker.Matchers;

namespace FileTypeChecker
{
    using System.IO;

    public class FileType
    {
        private readonly FileTypeMatcher fileTypeMatcher;

        public string Name { get; private set; }

        public string Extension { get; private set; }

        public static FileType Unknown { get; } = new FileType("unknown", string.Empty, null);

        public FileType(string name, string extension, FileTypeMatcher matcher)
        {
            this.Name = name;
            this.Extension = extension;
            this.fileTypeMatcher = matcher;
        }

        public bool Matches(Stream stream)
        {
            return this.fileTypeMatcher == null || this.fileTypeMatcher.Matches(stream);
        }
    }
}
