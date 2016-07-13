using System.ComponentModel.DataAnnotations;

namespace EFRepository.Tests.TestClasses
{
    /// <summary>
    /// TestData
    /// </summary>
    public class TestData : IEntity<int>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}