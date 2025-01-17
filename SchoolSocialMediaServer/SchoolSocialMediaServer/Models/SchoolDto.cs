﻿using SchoolSocialMediaServer.Entities;

namespace SchoolSocialMediaServer.Models
{
    public class SchoolDto
    {
        public Guid Id { get; set; }
        public string FullAddress { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImagePath { get; set; }
        public string NameWithAddress { get; set; } = null!;
        public ICollection<UserWithoutSchoolDto> Admins { get; set; } = new List<UserWithoutSchoolDto>();
    }
}
