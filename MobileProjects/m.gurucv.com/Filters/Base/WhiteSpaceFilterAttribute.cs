using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Macrosage.Mobile.GuruCV.Filters {
    public class WhiteSpaceFilterAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var response = filterContext.HttpContext.Response;
            response.Filter = new WhiteSpaceStreamFilter(response.Filter, htmlContents => {
                // Minify the contents
                htmlContents = MinifyHtml(htmlContents);

                // Re-add the @model declaration
                htmlContents = ReArrangeModelDeclaration(htmlContents);

                return htmlContents.Trim();
            });
        }


        /// <summary>
        /// Re-arranges the razor syntax with the @model declaration on its
        /// own line. It seems to break the razor engine if this isnt on
        /// it's own line.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ReArrangeModelDeclaration(string fileContents) {
            int modelPosition = fileContents.IndexOf("@model ", System.StringComparison.Ordinal);

            int position = 7;
            while (modelPosition >= 0) {
                // move one forward
                position += 1;
                string substring = fileContents.Substring(modelPosition, position);

                // check if it contains a whitespace at the end
                if (substring.EndsWith(" ") || substring.EndsWith(">")) {
                    // first replace the occurence
                    fileContents = fileContents.Replace(substring, "");

                    // Next move it to the top on its own line
                    fileContents = substring + Environment.NewLine + fileContents;

                    return fileContents;
                }
            }

            return fileContents;
        }

        /// <summary>
        /// Minifies the given HTML string.
        /// </summary>
        /// <param name="htmlContents">
        /// The html to minify.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string MinifyHtml(string htmlContents) {
            // Replace line comments
            htmlContents = Regex.Replace(htmlContents, @"// (.*?)\r?\n", "", RegexOptions.Singleline);

            // Replace spaces between quotes
            htmlContents = Regex.Replace(htmlContents, @"\s+", " ");

            // Replace line breaks
            htmlContents = Regex.Replace(htmlContents, @"\s*\n\s*", "\n");

            // Replace spaces between brackets
            htmlContents = Regex.Replace(htmlContents, @"\s*\>\s*\<\s*", "><");

            // Replace comments
            htmlContents = Regex.Replace(htmlContents, @"<!--(?!\[)(.*?)-->", "");

            // single-line doctype must be preserved 
            var firstEndBracketPosition = htmlContents.IndexOf(">", System.StringComparison.Ordinal);
            if (firstEndBracketPosition >= 0) {
                htmlContents = htmlContents.Remove(firstEndBracketPosition, 1);
                htmlContents = htmlContents.Insert(firstEndBracketPosition, ">");
            }
            return htmlContents.Trim();
        }

    }

    public class WhiteSpaceStreamFilter : Stream {
        private readonly Stream _shrink;
        private readonly Func<string, string> _filter;

        public WhiteSpaceStreamFilter(Stream shrink, Func<string, string> filter) {
            _shrink = shrink;
            _filter = filter;
        }

        public override bool CanRead { get { return true; } }
        public override bool CanSeek { get { return true; } }
        public override bool CanWrite { get { return true; } }
        public override void Flush() { _shrink.Flush(); }
        public override long Length { get { return 0; } }
        public override long Position { get; set; }
        public override int Read(byte[] buffer, int offset, int count) {
            return _shrink.Read(buffer, offset, count);
        }
        public override long Seek(long offset, SeekOrigin origin) {
            return _shrink.Seek(offset, origin);
        }
        public override void SetLength(long value) {
            _shrink.SetLength(value);
        }
        public override void Close() {
            _shrink.Close();
        }

        public override void Write(byte[] buffer, int offset, int count) {
            // capture the data and convert to string
            byte[] data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            string s = Encoding.UTF8.GetString(buffer);

            // filter the string
            s = _filter(s);

            // write the data to stream
            byte[] outdata = Encoding.UTF8.GetBytes(s);
            _shrink.Write(outdata, 0, outdata.GetLength(0));
        }
    }

}
