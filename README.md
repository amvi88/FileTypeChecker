# File Type Checker

File Type Checker is a .Net file identification library allowing developers to the file's magic numbers/identifying bytes against a whitelist.  

The purpose of this code is to make it easier for people to add better file security functionality to their projects via a NuGet package.

## Usage

Using an IoC container, register the instance in the container

```C#
new List<FileType>
{
    new FileType("Portable Network Graphic", ".png",
        new ExactFileTypeMatcher(new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A})),
    new FileType("JPEG", ".jpg",
        new FuzzyFileTypeMatcher(new byte?[] {0xFF, 0xD, 0xFF, 0xE0, null, null, 0x4A, 0x46, 0x49, 0x46, 0x00})),
    new FileType("Portable Document Format", ".pdf", new RangeFileTypeMatcher(new ExactFileTypeMatcher(new byte[] { 0x25, 0x50, 0x44, 0x46 }), 1019))
}
```

Register the `FileTypeChecker` concrete implementation to the `IFileTypeChecker` interface.  Wherever you need the checker, dependency inject it and use it like below.
```C#
    // pdf is a stream containing a PDF
    var fileType = checker.GetFileType(pdf);
```


## Background

I have seen too many projects allow file uploads any the only validation that occurs is the filename extension.  This project exists because there needs to be a plug and play library that facilites mitigating this security issue.


## File Magic Number Resources 

For a list of file magic numbers, I have found these sites to be useful.  

* https://www.garykessler.net/library/file_sigs.html
* http://filext.com/
* https://en.wikipedia.org/wiki/List_of_file_signatures
* https://asecuritysite.com/forensics/magic


## Credits

Based on [mjolka](https://github.com/mjolka)'s answer to the Stack Overflow question [Guessing a file type based on its content](http://codereview.stackexchange.com/questions/85054/guessing-a-file-type-based-on-its-content).

This repo is forked from https://github.com/mjolka/filetypes and the original code can be found in the "original" branch (preserving for posterity).  I have changed the namespaces/project name to better describe the purpose. 