﻿namespace Contact_Information.DTOs
{
    public class SaveUserDTO
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? LocationId { get; set; }
        public bool IsActive { get; set; }
    }
}
