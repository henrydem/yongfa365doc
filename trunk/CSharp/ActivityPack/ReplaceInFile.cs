namespace TeamFoundation.Build.ActivityPack
{
    using System;
    using System.Activities;
    using System.IO;
    using System.Text.RegularExpressions;

    using Microsoft.TeamFoundation.Build.Client;

    /// <summary>
    /// Workflow activity that replaces all occurrences of a regular expression
    /// in a text file with the specified text.
    /// </summary>
    [BuildActivity(HostEnvironmentOption.Agent)]
    public sealed class ReplaceInFile : CodeActivity
    {
        #region Properties

        /// <summary>
        /// Specify the path of the file to replace occurences of the regular 
        /// expression with the replacement text
        /// </summary>
        [RequiredArgument]
        public InArgument<string> FilePath
        {
            get; set;
        }

        /// <summary>
        /// Regular expression to search for and replace in the specified
        /// text file.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> RegularExpression
        {
            get; set;
        }

        /// <summary>
        /// Text to replace occurrences of the specified regular expression with.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Replacement
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Executes the logic for this workflow activity
        /// </summary>
        /// <param name="context">Workflow context</param>
        /// <exception cref="ArgumentException">If the specified context does not
        /// contain a FilePath and a RegularExpression, an ArgumentException 
        /// is thrown.</exception>
        protected override void Execute(CodeActivityContext context)
        {
            // get the value of the FilePath in argument from the workflow context
            String filePath = FilePath.Get(context);

            // throw if the file path is null or empty
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException(
                    "Specify a path to replace text in", "FilePath");
            }

            // throw if the specified file path doesn't exist
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    "File not found", filePath);
            }

            // get the value of the RegularExpression in argument
            String regularExpression = context.GetValue(RegularExpression);

            // throw if the regular expression is null or empty
            if (String.IsNullOrEmpty(regularExpression))
            {
                throw new ArgumentException(
                    "Specify an expression to replace", "RegularExpression");
            }

            var regex = new Regex(regularExpression);
            var replacement = Replacement.Get(context) ?? String.Empty;

            // ensure that the file is writeable
            FileAttributes fileAttributes = File.GetAttributes(filePath);
            File.SetAttributes(filePath, fileAttributes & ~FileAttributes.ReadOnly);

            // perform the actual replacement
            String contents = regex.Replace(File.ReadAllText(filePath), replacement);

            File.WriteAllText(filePath, contents);

            // restore the file's original attributes
            File.SetAttributes(filePath, fileAttributes);
        }

        #endregion Methods
    }
}