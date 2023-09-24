﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSocialMediaServer.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; } = null!;

        public int ProfileViewCount { get; set; }
        
        public string? ImageFileName { get; set; }

        public static string ImageFilesDirectory { get; } = "Images/ProfileImages/";

        public string? ImagePath {
            get
            {
                if (ImageFileName == null)
                {
                    return null;
                }

                return ImageFilesDirectory + ImageFileName;
            }
        }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public Guid SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; } = null!;

        public User() { }

        public User(string name, Guid schoolId, string? imageFileName)
        {
            Name = name;
            ImageFileName = imageFileName;
            SchoolId = schoolId;
        }
    }
}
