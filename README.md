Simple console app that helps dealing with aottg custom logic (.acl) files.
With this console app you can split your custom logic into multiple .acl files, and
when you run this in the terminal, it will combine all of those .acl files into one
single .txt files that can then be used in the game.
.acl files can also contains comments that start with `//`, running this will remove
all the comments from the ouput text file.

# Install

To install:

- Clone the repository
- Extract the content
- Add `.\bin\Debug\net7.0\` to the system PATH
- Open a Terminal/Command Prompt and run `aclp`

# Usage

In the terminal, use `cd` to navigate to the folder where your .acl files are,
then run `aclp -b` or `aclp -b "Path/To/Output.txt"` to generate the output text file.
